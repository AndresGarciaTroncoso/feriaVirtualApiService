using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
//using FrutosMaipo.Feria.Service.Config;
using FrutosMaipo.Feria.Service.Infrastructure.Entities;
using FrutosMaipo.Feria.Service.Infrastructure.Interfaces;
using FrutosMaipo.Feria.Service.Infrastructure.Repositories;
using FrutosMaipo.Feria.Service.Services;
using FrutosMaipo.Feria.Service.Config;

namespace FrutosMaipo.Feria.Service
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<FMaipoBDContext>(options => options.UseSqlServer(Configuration.GetConnectionString("PaVoDB")));
            //services.AddHttpClient<IWeatherService, WeatherService>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IProductoRepository, ProductoRepository>();

            services.AddHttpClient<IAuthUserManangementServices, AuthUserManagementService>();
            services.Configure<Auth0ManagementApiConfig>(Configuration.GetSection("Auth0"));
            //services.Configure<WeatherApiConfig>(Configuration.GetSection("WeatherApiService"));

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCors("AllowAll");
            app.UseMvc();
        }
    }
}
