using IntelligentCooking.Core.Interfaces.UnitsOfWork;
using IntelligentCooking.DAL.Context;
using IntelligentCooking.DAL.UnitsOfWork;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DIRegisterExtensionDAL
    {
        public static void AddDataLayerDependecies(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<IntelligentCookingContext>(
                options => options.UseSqlServer(connectionString));

            services.AddScoped<IIntelligentCookingUnitOfWork, IntelligentCookingUnitOfWork>();
        }
    }
}
