using System;
using CompetentieAppFrontend.Infrastructure.DAL;
using CompetentieAppFrontend.Infrastructure.Repositories;
using CompetentieAppFrontend.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CompetentieAppFrontend.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CompetentieAppFrontendContext>(builder =>
            {
                builder.UseNpgsql(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING") ??
                                  throw new ArgumentNullException());
            });
            services.AddTransient<IArchitectuurLaagRepository, ArchitectuurLaagRepository>();
            services.AddTransient<IActiviteitRepository, ActiviteitRepository>();
            services.AddTransient<ICompetentieRepository, CompetentieRepository>();
            services.AddTransient<IEindcompetentieService, EindcompetentieService>();
            services.AddTransient<IModuleRepository, ModuleRepository>();
            services.AddTransient<IModuleService, ModuleService>();
            services.AddTransient<IMatrixService<int>, NiveauMatrixService>();
            services.AddTransient<IMatrixService<Eindniveau>, EindcompetentieMatrixService>();
            services.AddControllersWithViews();
            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp/dist"; });
            services.UseRabbitMq();
            services.UseMicroserviceHost();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            serviceScope.ServiceProvider.GetService<CompetentieAppFrontendContext>().Database.EnsureDeleted();
            serviceScope.ServiceProvider.GetService<CompetentieAppFrontendContext>().Database.EnsureCreated();
            serviceScope.ServiceProvider.GetService<CompetentieAppFrontendContext>().EnsureDataSeeded();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}