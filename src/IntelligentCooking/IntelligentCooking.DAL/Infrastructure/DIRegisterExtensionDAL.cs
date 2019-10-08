using System;
using IntelligentCooking.Core.Entities;
using IntelligentCooking.Core.Interfaces.Repositories;
using IntelligentCooking.Core.Interfaces.UnitsOfWork;
using IntelligentCooking.DAL.Context;
using IntelligentCooking.DAL.Repositories;
using IntelligentCooking.DAL.UnitsOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DIRegisterExtensionDAL
    {
        //TODO Find way to register all repo dependencies like Add<IRepository<,>, Repository<,>>
        public static void AddDataLayerDependecies(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<IntelligentCookingContext>(
                options => options.UseSqlServer(connectionString));

            services.AddScoped<IIntelligentCookingUnitOfWork, IntelligentCookingUnitOfWork>();
        }
    }
}
