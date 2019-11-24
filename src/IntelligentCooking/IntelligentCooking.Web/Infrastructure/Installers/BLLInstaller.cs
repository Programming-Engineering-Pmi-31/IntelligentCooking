using InelligentCooking.BLL.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IntelligentCooking.Web.Infrastructure.Installers
{
    public class BLLInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddBllDependecies(configuration.GetConnectionString("IntelligentCookingDb"));
        }
    }
}
