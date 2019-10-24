using IntelligentCooking.Web.Infrastructure.Extensions;
using IntelligentCooking.Web.Infrastructure.Installers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            services.Install(new OptionsInstaller(), Configuration);
            services.Install(new AuthInstaller(), Configuration);
            services.Install(new MvcInstaller(), Configuration);
            services.Install(new CorsInstaller(), Configuration);
            services.Install(new BLLInstaller(), Configuration);
            services.Install(new SwaggerInstaller(), Configuration);
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
