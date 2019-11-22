using System;
using AutoMapper;
using InelligentCooking.BLL.Interfaces;
using InelligentCooking.BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace InelligentCooking.BLL.Infrastructure
{
    public static class DIRegisterExtensionsBLL
    {
        public static void AddBllDependecies(this IServiceCollection services, string connectionString)
        {
            services.AddDataLayerDependecies(connectionString);
            services.AddScoped<IDishService, DishService>();
            services.AddScoped<IImageService, CloudinaryService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IIngredientService, IngredientService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IRatingService, RatingService>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
