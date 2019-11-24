using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace IntelligentCooking.Web.Infrastructure.Installers
{
    public class SwaggerInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(
                c =>
                {
                    c.SwaggerDoc("v1", new Info { Title = "My Api", Version = "v1 " });
                    var security = new Dictionary<string, IEnumerable<string>>
                    {
                        { "Bearer", new string[0] }
                    };

                    c.AddSecurityDefinition(
                        "Bearer",
                        new ApiKeyScheme
                        {
                            Description = "JWT Authorization header",
                            Name = "Authorization",
                            In = "header",
                            Type = "apiKey"
                        });

                    c.AddSecurityRequirement(security);
                });
        }
    }
}
