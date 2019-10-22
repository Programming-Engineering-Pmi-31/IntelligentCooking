using System.Collections.Generic;
using InelligentCooking.BLL.Infrastructure;
using IntelligentCooking.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

//TODO Think over this https://marcin-chwedczuk.github.io/repository-pattern-my-way
//AND This https://enterprisecraftsmanship.com/posts/specification-pattern-c-implementation/
namespace IntelligentCooking.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath: env.ContentRootPath)
                .AddJsonFile("Settings/cloudinary_settings.json", false, true)
                .AddJsonFile("Settings/jwt_settings.json", false, true)
                .AddJsonFile("appsettings.json", false, true);

            Configuration = configuration.Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        { 
            services.GetSettings(this);
            services.ConfigureMvcFeatures();
            services.ConfigureAuth(Configuration["JwtSettings:Secret"]);
            services.ConfigureSwagger();
            services.AddBllDependecies(Configuration.GetConnectionString("IntelligentCookingDb"));
            services.ConfigureCors();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseAuthentication();

            app.UseCors("Default");
            app.UseSwagger();
            app.UseSwaggerUI(
                c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Api V1");
                });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
