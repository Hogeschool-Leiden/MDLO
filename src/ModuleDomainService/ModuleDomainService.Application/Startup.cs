using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Miffy.MicroServices.Events;
using ModuleDomainService.Infrastructure.DAL;
using ModuleDomainService.Infrastructure.Repositories;

namespace ModuleDomainService.Application
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddModuleDomainServiceDbContext();
            services.AddTransient<IEventPublisher, EventPublisher>();
            services.AddTransient<IEventStore, SQLEventStore>();
            services.AddTransient<IModuleRepository, ModuleRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            serviceScope.ServiceProvider.GetService<ModuleDomainServiceContext>().Database.EnsureDeleted();
            serviceScope.ServiceProvider.GetService<ModuleDomainServiceContext>().Database.EnsureCreated();
        }
    }
}