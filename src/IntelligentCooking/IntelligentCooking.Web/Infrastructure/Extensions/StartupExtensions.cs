using FluentValidation.AspNetCore;
using InelligentCooking.BLL.Infrastructure.Validators;
using InelligentCooking.BLL.Settings;
using IntelligentCooking.Web.Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

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

        public static void GetSettings(this IServiceCollection services, Startup startup)
        {
            services.Configure<CloudinarySettings>(startup.Configuration.GetSection("CloudinaryCredentials"));
        }
    }
}
