using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Miffy;
using Miffy.MicroServices.Commands;
using Miffy.MicroServices.Host;
using Miffy.RabbitMQBus;
using ModuleFrontend.Api.Services;
using Polly;
using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;

namespace ModuleFrontend.Api
{
    [ExcludeFromCodeCoverage]
    public static class IServiceCollectionExtensions
    {
        public static void UseRabbitMq(this IServiceCollection services)
        {
            var contextBuilder = new RabbitMqContextBuilder().ReadFromEnvironmentVariables();
            
            var context = Policy.Handle<BrokerUnreachableException>()
                .WaitAndRetryForever(sleepDurationProvider => TimeSpan.FromSeconds(5))
                .Execute(contextBuilder.CreateContext);

            services.AddSingleton(context);
            services.AddTransient<IModuleService, ModuleService>();
            services.AddSingleton<ICommandPublisher, CommandPublisher>();

        }

        public static void UseMicroserviceHost(this IServiceCollection services)
        {
            var context = services.BuildServiceProvider().GetService<IBusContext<IConnection>>();
            
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
                .CreateHost();
            
            services.AddSingleton(microserviceHost);

            services.AddHostedService<Miffy>();
        }
    }
}