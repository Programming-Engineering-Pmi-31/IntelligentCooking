using InelligentCooking.BLL.Interfaces;
using InelligentCooking.BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace InelligentCooking.BLL.Infrastructure
{
    public static class DIRegisterExtensionsBLL
    {
        public static void AddBllLayerDependecies(this IServiceCollection services, string connectionString)
        {
            services.AddDataLayerDependecies(connectionString);
            services.AddScoped<IDishService, DishService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IIngredientService, IngredientService>();
        }
    }
}
