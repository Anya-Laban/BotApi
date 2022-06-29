using API.Clients.Hotel_Cl;
using API.Clients.Places_Cl;
using API.Clients.Restoraunt_Cl;
using API.Clients.Weather_Cl;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
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
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            //});
            //services.AddSwaggerGen(options =>
            //{
            //    options.CustomSchemaIds(type => type.FullName);
            //});
            services.AddSwaggerGen(options =>
            {
                options.CustomSchemaIds(type => type.FullName.Replace("+", "_"));
            }); 
            services.AddSingleton<HotelsClient>();
            services.AddSingleton<HotelsCityIdClient>();

            services.AddSingleton<RestaurantsIDClient>();
            services.AddSingleton<RestaurantsClient>();

            services.AddSingleton<PlacesCityClient>();
            services.AddSingleton<PlacesClient>();

            services.AddSingleton<WeatherClient>();
            
            services.AddSingleton<WishListPlaceClient>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));

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
