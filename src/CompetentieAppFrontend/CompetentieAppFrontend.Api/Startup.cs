using System.Diagnostics.CodeAnalysis;
using CompetentieAppFrontend.Infrastructure.DAL;
using CompetentieAppFrontend.Infrastructure.Repositories;
using CompetentieAppFrontend.Services.Abstractions;
using CompetentieAppFrontend.Services.Eventing;
using CompetentieAppFrontend.Services.Projections;
using CompetentieAppFrontend.Services.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CompetentieAppFrontend.Api
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCompetentieAppFrontendContext();
            
            services.AddTransient<IArchitectuurLaagRepository, ArchitectuurLaagRepository>();
            services.AddTransient<IActiviteitRepository, ActiviteitRepository>();
            services.AddTransient<ICompetentieRepository, CompetentieRepository>();
            services.AddTransient<IModuleRepository, ModuleRepository>();
            services.AddTransient<ICohortRepository, CohortRepository>();
            services.AddTransient<ISpecialisatieRepository, SpecialisatieRepository>();
            services.AddTransient<IPeriodeRepository, PeriodeRepository>();
            services.AddTransient<IStudiefaseRepository, StudiefaseRepository>();
            services.AddTransient<IBeheersingsNiveauRepository, BeheersingsNiveauRepository>();
            services.AddTransient<IEindeisRepository, EindeisRepository>();
            services.AddTransient<IAuditLogEntryRepository, AuditLogEntryRepository>();

            services.AddTransient<IEindcompetentieService, EindcompetentieService>();
            services.AddTransient<IModuleService, ModuleService>();
            services.AddTransient<IMatrixService<int>, NiveauMatrixService>();
            services.AddTransient<IMatrixService<Eindniveau>, EindcompetentieMatrixService>();
            services.AddTransient<ICompetentieService, CompetentieService>();
            services.AddTransient<IStudiefaseService, StudiefaseService>();
            services.AddTransient<IEindeisService, EindeisService>();
            services.AddTransient<IModuleEventsDeserializer, ModuleEventsDeserializer>();
            services.AddTransient<IAuditLogEntryService, AuditLogEntryService>();

            services.AddControllersWithViews();
            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp/dist"; });
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
                    pattern: "api/{controller}/{action=Index}/{id?}");
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