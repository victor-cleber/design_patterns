using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System.IO;

using Company.Fleet.Domain;
using Company.Fleet.Infra.Singleton;
using Company.Fleet.Infra.Repository;
using Company.Fleet.Infra.Repository.EF;
using Company.Fleet.Infra.Facade;

using Microsoft.EntityFrameworkCore;

namespace Company.Fleet.API
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

            services.AddControllers();

            //Register the Swagger generator
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo 
                { 
                    Title = "Company.Fleet.API",
                    Description="API - Fleet of vehicles",
                    Version = "v1" 
                });
            });

            services.AddSingleton<SingletonContainer>();

            //services.AddSingleton<IVehicleRepository, InMemoryRepository>();
            services.AddTransient<IVehicleRepository, FleetRepository>();

            services.AddDbContext<FleetContext>(opt => opt.UseInMemoryDatabase("Fleet"));

            services.Configure<DetranOptions>(Configuration.GetSection("DetranOptions"));

            services.AddHttpClient();

            services.AddTransient<IVehicleDetran, VehicleDetranFacade>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }
            //Enable middleware to serve generated Swagger as a Json Endpoint
            app.UseSwagger();

            //Enable middleware to serve swagger-ui specifying the Swagger JSON endpoint
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fleet API v1"));

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
