using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Miffy.MicroServices.Events;
using ModuleDomainService.Infrastructure.DAL;
using ModuleDomainService.Infrastructure.Repositories;

namespace ModuleDomainService.Application
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ModuleDomainServiceContext>(builder =>
            {
                builder.UseNpgsql(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING") ??
                                  throw new ArgumentNullException());
            });
            services.AddTransient<IEventPublisher, EventPublisher>();
            services.AddTransient<IEventStore, SQLEventStore>();
            services.AddTransient<IModuleRepository, ModuleRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}