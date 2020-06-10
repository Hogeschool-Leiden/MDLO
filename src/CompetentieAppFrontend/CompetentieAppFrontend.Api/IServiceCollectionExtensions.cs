using System;
using System.Diagnostics.CodeAnalysis;
using CompetentieAppFrontend.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;
using CompetentieAppFrontend.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Miffy;
using Miffy.MicroServices.Host;
using Miffy.RabbitMQBus;
using Polly;
using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;

namespace CompetentieAppFrontend.Api
{
    [ExcludeFromCodeCoverage]
    public static class IServiceCollectionExtensions
    {
        public static void AddCompetentieAppFrontendContext(this IServiceCollection services)
        {
            services.AddDbContext<CompetentieAppFrontendContext>(builder =>
            {
                var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
                if (connectionString == null)
                    throw new ArgumentNullException($"{nameof(connectionString)} can not be null");
                builder.UseNpgsql(connectionString);
            });
        }

        public static void UseMicroserviceHost(this IServiceCollection services)
        {
            Enum.TryParse(Environment.GetEnvironmentVariable("LOG_LEVEL"), out LogLevel logLevel);
            
            var contextBuilder = new RabbitMqContextBuilder().ReadFromEnvironmentVariables();
            
            var context = Policy.Handle<BrokerUnreachableException>()
                .WaitAndRetryForever(sleepDurationProvider => TimeSpan.FromSeconds(5))
                .Execute(contextBuilder.CreateContext);
            
            var loggerFactory = LoggerFactory.Create(configure =>
            {
                configure.AddConsole().SetMinimumLevel(logLevel);
            });
            
            var microserviceHost = new MicroserviceHostBuilder()
                .SetLoggerFactory(loggerFactory)
                .RegisterDependencies(services)
                .WithQueueName(Environment.GetEnvironmentVariable("BROKER_QUEUE_NAME"))
                .WithBusContext(context)
                .UseConventions()
                .CreateHost();

            services.AddLogging(builder => builder.AddConsole().SetMinimumLevel(logLevel));
            services.AddSingleton(context);
            services.AddSingleton(microserviceHost);
            services.AddHostedService<Miffy>();
        }
    }
}