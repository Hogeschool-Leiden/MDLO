using System;
using System.Threading;
using CompetentieAppFrontend.Infrastructure.DAL;
using CompetentieAppFrontend.Infrastructure.Repositories;
using CompetentieAppFrontend.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Miffy;
using Miffy.MicroServices.Host;
using Miffy.RabbitMQBus;
using Polly;
using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;

namespace CompetentieAppFrontend.Api
{
    public static class Program
    {
        private const string QueueName = "CompetentieAppFrontend";
        public static void Main(string[] args)
        {
            using var loggerFactory = LoggerFactory.Create(configure =>
            {
                Enum.TryParse(Environment.GetEnvironmentVariable("LOG_LEVEL"), out LogLevel logLevel);
                configure.AddConsole().SetMinimumLevel(logLevel);
            });

            var contextBuilder = new RabbitMqContextBuilder()
                    .ReadFromEnvironmentVariables();

            using var context = CreateRabbitMqConnection(contextBuilder);

            var builder = new MicroserviceHostBuilder()
                .SetLoggerFactory(loggerFactory)
                .RegisterDependencies(services =>
                {
                    services.AddDbContext<CompetentieAppFrontendContext>(builder =>
                    {
                        builder.UseNpgsql(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING") ??
                                          throw new ArgumentNullException());
                    });
                    services.AddTransient<IArchitectuurLaagRepository, ArchitectuurLaagRepository>();
                    services.AddTransient<IActiviteitRepository, ActiviteitRepository>();
                    services.AddTransient<IEindCompetentieRepository, EindCompetentieRepository>();
                    services.AddTransient<IEindCompetentieMatrixService, EindCompetentieMatrixService>();
                })
                .WithQueueName(QueueName)
                .WithBusContext(context)
                .UseConventions();

            using var host = builder.CreateHost();
            
            host.Start();
            
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static IBusContext<IConnection> CreateRabbitMqConnection(RabbitMqContextBuilder contextBuilder)
        {
            return Policy.Handle<BrokerUnreachableException>()
                .WaitAndRetryForever(sleepDurationProvider => TimeSpan.FromSeconds(5))
                .Execute(contextBuilder.CreateContext);
        }
    }
}
