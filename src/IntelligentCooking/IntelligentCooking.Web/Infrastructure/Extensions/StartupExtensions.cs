using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IntelligentCooking.Web.Infrastructure.Extensions
{
    public static class StartupExtensions
    {
        public static void ConfigureCors(this IServiceCollection services, Startup startup)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("Default", policy =>
                {
                    var origins = startup.Configuration.GetSection("CorsOptions").GetSection("AllowedOrigins").Get<string[]>();
                    policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
        }

    }
}
