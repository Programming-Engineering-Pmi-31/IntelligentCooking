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
    public static class DIRegisterExtension
    {
        //TODO Find way to register all repo dependencies like Add<IRepository<,>, Repository<,>>
        public static void AddDataLayerDependecies(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<IntelligentCookingContext>(
                options => options.UseSqlServer(connectionString));

            services.AddScoped<IRepository<Category, int>, Repository<Category, int>>();
            services.AddScoped<IRepository<Dish, int>, Repository<Dish, int>>();
            services
                .AddScoped<IRepository<DishCategory, (int DishId, int CategoryId)>,
                    Repository<DishCategory, (int DishId, int CategoryId)>>();

            services
                .AddScoped<IRepository<DishIngredient, (int DishId, int IngredientId)>,
                    Repository<DishIngredient, (int DishId, int IngredientId)>>();

            services.AddScoped<IRepository<Favourite, (int UserId, int DishId)>, Repository<Favourite, (int UserId, int DishId)>>();
            services.AddScoped<IRepository<Like, (int UserId, int DishId)>, Repository<Like, (int UserId, int DishId)>>();
            services.AddScoped<IRepository<User, int>, Repository<User, int>>();
            services.AddScoped<IRepository<Role, int>, Repository<Role, int>>();
            services.AddScoped<IRepository<UserRole, (int UserId, int RoleId)>, Repository<UserRole, (int UserId, int RoleId)>>();
            services
                .AddScoped<IRepository<UserToken, (int UserId, string LoginProvider, string Name)>,
                    Repository<UserToken, (int UserId, string LoginProvider, string Name)>>();

            services
                .AddScoped<IRepository<UserLogin, (string LoginProvider, string ProviderKey)>,
                    Repository<UserLogin, (string LoginProvider, string ProviderKey)>>();

            services.AddScoped<IRepository<UserClaim, int>, Repository<UserClaim, int>>();
            services.AddScoped<IRepository<RoleClaim, int>, Repository<RoleClaim, int>>();

            services.AddScoped<IIntelligentCookingUnitOfWork, IntelligentCookingUnitOfWork>();
        }
    }
}
