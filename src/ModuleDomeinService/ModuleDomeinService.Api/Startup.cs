using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Miffy;
using Miffy.MicroServices.Events;
using Miffy.MicroServices.Host;
using Miffy.RabbitMQBus;
using ModuleDomeinService.Api.Messages.Events;
using RabbitMQ.Client;

namespace ModuleDomeinService.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            string DbAddress = Environment.GetEnvironmentVariable("DATABASE_ADDRESS");
            string DbPass = Environment.GetEnvironmentVariable("DATABASE_PASS");
            string DbUser = Environment.GetEnvironmentVariable("DATABASE_USER");
            string DbName = Environment.GetEnvironmentVariable("DATABASE_NAME");

            services.AddControllers();

            services.AddDbContext<ModuleDomeinContext>(opts => opts.UseMySQL($"Server={DbAddress};Database={DbName};Uid={DbUser};Pwd={DbPass};"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
