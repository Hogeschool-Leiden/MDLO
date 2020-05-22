using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Miffy;
using Miffy.MicroServices.Events;
using Miffy.MicroServices.Host;
using Miffy.RabbitMQBus;
using ModuleDomeinService.Api.Messages.Events;
using Org.BouncyCastle.Asn1.Cms;
using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;

namespace ModuleDomeinService.Api
{
    public class Program
    {
        private const string QueueName = "ModuleDomeinService";
        public static void Main(string[] args)
        {

            using ILoggerFactory loggerFactory = LoggerFactory.Create(configure =>
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

            using IBusContext<IConnection> context = contextBuilder.CreateContext();

            var builder = new MicroserviceHostBuilder()
                .SetLoggerFactory(loggerFactory)
                .RegisterDependencies(services =>
                {
                    services.AddDbContext<ModuleDomeinContext>(opts => opts.UseNpgsql(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")));
                })
                .WithQueueName(QueueName)
                .WithBusContext(context)
                .UseConventions();

            using IMicroserviceHost host = builder.CreateHost();
            host.Start();
            host.Pause();


            host.Resume();
            var exampleEvent = new ExampleEvent() { ExampleData = "ExampleData event payload" };
            var publisher = new EventPublisher(context);
            publisher.PublishAsync(exampleEvent);
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
