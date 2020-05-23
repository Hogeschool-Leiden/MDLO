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
                configure.AddConsole().SetMinimumLevel(LogLevel.Error);
            });

            var contextBuilder = new RabbitMqContextBuilder()
                    .ReadFromEnvironmentVariables();

            bool connected = false;
            while (!connected)
            {
                try
                {
                    var tryContext = contextBuilder.CreateContext();
                    connected = true;
                }
                catch (BrokerUnreachableException)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("Retrying connection to message broker..");
                    continue;
                }
            }

            using var context = contextBuilder.CreateContext();

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
    }
}
