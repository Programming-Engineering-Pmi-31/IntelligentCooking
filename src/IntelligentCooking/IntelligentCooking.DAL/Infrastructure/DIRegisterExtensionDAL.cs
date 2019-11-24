using IntelligentCooking.Core.Entities;
using IntelligentCooking.Core.Interfaces.UnitsOfWork;
using IntelligentCooking.DAL.Context;
using IntelligentCooking.DAL.UnitsOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DIRegisterExtensionDAL
    {
        public static void AddDataLayerDependecies(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<IntelligentCookingContext>(
                options => options.UseSqlServer(connectionString));

            services.AddIdentity<User, IdentityRole<int>>(options =>
                {
                    options.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<IntelligentCookingContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IIntelligentCookingUnitOfWork, IntelligentCookingUnitOfWork>();
        }
    }
}
