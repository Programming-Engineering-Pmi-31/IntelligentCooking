using FluentValidation.AspNetCore;
using InelligentCooking.BLL.Infrastructure.Validators;
using IntelligentCooking.Web.Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace IntelligentCooking.Web.Infrastructure.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
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
    }
}
