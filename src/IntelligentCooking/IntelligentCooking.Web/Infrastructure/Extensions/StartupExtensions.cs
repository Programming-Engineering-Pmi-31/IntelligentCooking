using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation.AspNetCore;
using InelligentCooking.BLL.Infrastructure.Validators;
using InelligentCooking.BLL.Settings;
using IntelligentCooking.Web.Infrastructure.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;

namespace IntelligentCooking.Web.Infrastructure.Extensions
{
    public static class StartupExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(
                options =>
                {
                    options.AddPolicy(
                        "Default",
                        policy =>
                        {
                            policy.AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                        });
                });
        }

        public static void ConfigureMvcFeatures(this IServiceCollection services)
        {
            services.AddMvc(
                    options =>
                    {
                        options.Filters.Add(new ExceptionFilter());
                    })
                .AddFluentValidation(
                    options =>
                    {
                        options.RegisterValidatorsFromAssemblyContaining<AddDishValidator>();
                        options.ImplicitlyValidateChildProperties = true;
                    })
                .SetCompatibilityVersion(version: CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());
        }

        public static void ConfigureAuth(this IServiceCollection services, string secret)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromMinutes(0)
            };

            services.AddSingleton(tokenValidationParameters);

            services.AddAuthentication(
                    options =>
                    {
                        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; //?
                    })
                .AddJwtBearer(
                    options =>
                    {
                        options.TokenValidationParameters = tokenValidationParameters;
                    });
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(
                c =>
                {
                    c.SwaggerDoc("v1", new Info {Title = "My Api", Version = "v1 "});
                    var security = new Dictionary<string, IEnumerable<string>>
                    {
                        {"Bearer", new string[0]}
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

        public static void GetSettings(this IServiceCollection services, Startup startup)
        {
            services.Configure<CloudinarySettings>(startup.Configuration.GetSection("CloudinaryCredentials"));
            services.Configure<JwtSettings>(startup.Configuration.GetSection("JwtSettings"));
        }
    }
}
