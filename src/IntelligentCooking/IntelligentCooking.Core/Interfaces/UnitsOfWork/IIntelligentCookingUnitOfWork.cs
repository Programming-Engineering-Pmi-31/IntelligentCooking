using System;
using System.Threading.Tasks;
using IntelligentCooking.Core.Interfaces.Repositories;

namespace IntelligentCooking.Core.Interfaces.UnitsOfWork
{
    public interface IIntelligentCookingUnitOfWork: IDisposable
    {
        ICategoryRepository Categories { get; }
        IIngredientRepository Ingredients { get; }
        IDishRepository Dishes { get; }
        IDishCategoryRepository DishCategories { get; }
        IDishIngredientRepository DishIngredients { get; }
        IFavouriteRepository Favourites { get; }
        ILikeRepository Likes { get; }
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }
        IUserRoleRepository UserRoles { get; }
        IUserTokenRepository UserTokens { get; }
        IUserLoginRepository UserLogins { get; }
        IUserClaimRepository UserClaims { get; }
        IRoleClaimRepository RoleClaims { get; }

        Task CommitAsync();
    }
}
