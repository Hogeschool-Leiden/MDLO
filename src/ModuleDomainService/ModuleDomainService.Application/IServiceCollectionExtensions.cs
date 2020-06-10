using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Miffy.MicroServices.Host;
using Miffy.RabbitMQBus;
using ModuleDomainService.Application.Constants;
using ModuleDomainService.Infrastructure.DAL;
using Polly;
using RabbitMQ.Client.Exceptions;

namespace ModuleDomainService.Application
{
    [ExcludeFromCodeCoverage]
    public static class IServiceCollectionExtensions
    {
        public static void UseMicroserviceHost(this IServiceCollection services)
        {
            var contextBuilder = new RabbitMqContextBuilder().ReadFromEnvironmentVariables();
            
            var context = Policy.Handle<BrokerUnreachableException>()
                .WaitAndRetryForever(sleepDurationProvider => TimeSpan.FromSeconds(5))
                .Execute(contextBuilder.CreateContext);

            var loggerFactory = LoggerFactory.Create(configure =>
            {
                Enum.TryParse(Environment.GetEnvironmentVariable(EnvironmentNames.LogLevel), out LogLevel logLevel);
                configure.AddConsole().SetMinimumLevel(logLevel);
            });
            
            var microserviceHost = new MicroserviceHostBuilder()
                .SetLoggerFactory(loggerFactory)
                .RegisterDependencies(services)
                .WithQueueName(Environment.GetEnvironmentVariable(EnvironmentNames.BrokerExchangeName))
                .WithBusContext(context)
                .UseConventions()
                .CreateHost();
            
            services.AddSingleton(context);
            services.AddSingleton(microserviceHost);
            services.AddHostedService<Miffy>();
        }

        public static IServiceCollection AddModuleDomainServiceDbContext(this IServiceCollection services)
        {
            return services.AddDbContext<ModuleDomainServiceContext>(builder =>
            {
                var connectionString = Environment.GetEnvironmentVariable(EnvironmentNames.DbConnectionString);
                
                if (connectionString == null) throw new ArgumentNullException($"{nameof(connectionString)} can not be null");

                builder.UseNpgsql(connectionString);
            });
        }
    }
}