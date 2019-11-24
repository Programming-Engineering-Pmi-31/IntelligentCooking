using System;
using System.Threading.Tasks;
using IntelligentCooking.Core.Interfaces.Repositories;

namespace IntelligentCooking.Core.Interfaces.UnitsOfWork
{
    public interface IIntelligentCookingUnitOfWork : IDisposable
    {
        ICategoryRepository Categories { get; }

        IIngredientRepository Ingredients { get; }

        IDishRepository Dishes { get; }

        IDishCategoryRepository DishCategories { get; }

        IDishIngredientRepository DishIngredients { get; }

        IFavouriteRepository Favourites { get; }

        IRatingRepository Ratings { get; }

        IUserRepository Users { get; }

        IRefreshTokenRepository RefreshTokens { get; }

        Task CommitAsync();
    }
}
