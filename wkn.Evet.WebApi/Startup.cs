using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;
using wkn.Evet.WebApi.Pipeline;

namespace wkn.Evet.WebApi
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
            // Adding Swagger UI for API Docs
            services.AddSwaggerGen(config =>
            {
                
                config.SwaggerDoc("EffectivErp", new OpenApiInfo()
                {
                    Description = "Effectiv ERP API Documentation", Title = "Effectiv ERP",
                    Version = "1",
                    License = new OpenApiLicense
                    {
                        Name = "Asom Services",
                        Url = new Uri("http://www.effectivonline.com")
                    }
                });
               
            });
            services.AddCors(opts =>
            {
                opts.AddPolicy("angularSpa", builder =>
                {
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                    builder.AllowAnyOrigin();
                    builder.Build();
                });
            });

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                opt.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                opt.DefaultSignOutScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            });
            services.AddMvc(options =>
            {
                // include options here
                new MvcServicePipeline(options)
                    .AddCsvOutputFormatters();
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddRouting(x => { x.LowercaseUrls = true; });
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCors("angularSpa");
            app.UseSwagger(opt => { });
            app.UseSwaggerUI(config =>
            {
                config.SwaggerEndpoint("/swagger/EffectivErp/swagger.json", "Effectiv Erp");
                config.RoutePrefix = "";
            });
            
            app.UseAuthentication();

            app.UseMvc(opt => { opt.MapRoute(name: "default", template: "{controller=RootApi}/{id?}"); });
        }
    }
}