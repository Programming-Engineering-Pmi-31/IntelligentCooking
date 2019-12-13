using IntelligentCooking.Web.Infrastructure.Installers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IntelligentCooking.Web.Infrastructure.Extensions
{
    public static class StartupExtensions
    {
        public static void Install(this IServiceCollection services, IInstaller installer, IConfiguration configuration)
        {
            installer.InstallServices(services, configuration);
        }
    }
}
