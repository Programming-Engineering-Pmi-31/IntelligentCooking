using InelligentCooking.BLL.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IntelligentCooking.Web.Infrastructure.Installers
{
    public class OptionsInstaller: IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration) 
        {
            services.Configure<CloudinarySettings>(configuration.GetSection("CloudinaryCredentials"));
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
        }
    }
}
