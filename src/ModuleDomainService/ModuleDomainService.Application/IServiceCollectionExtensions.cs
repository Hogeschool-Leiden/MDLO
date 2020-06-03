using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Miffy.MicroServices.Host;
using Miffy.RabbitMQBus;
using Polly;
using RabbitMQ.Client.Exceptions;

namespace ModuleDomainService.Application
{
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
                Enum.TryParse(Environment.GetEnvironmentVariable("LOG_LEVEL"), out LogLevel logLevel);
                configure.AddConsole().SetMinimumLevel(logLevel);
            });
            
            var microserviceHost = new MicroserviceHostBuilder()
                .SetLoggerFactory(loggerFactory)
                .RegisterDependencies(services)
                .WithQueueName(Environment.GetEnvironmentVariable("BROKER_QUEUE_NAME"))
                .WithBusContext(context)
                .UseConventions()
                .CreateHost();
            
            services.AddSingleton(context);
            services.AddSingleton(microserviceHost);
            services.AddHostedService<Miffy>();
        }
    }
}