using System;
using System.Threading.Tasks;
using IntelligentCooking.Core.Entities;
using IntelligentCooking.Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;

namespace IntelligentCooking.Core.Interfaces.UnitsOfWork
{
    public interface IIntelligentCookingUnitOfWork: IDisposable
    {
        ICategoryRepository Categories { get; }
        IIngredientRepository Ingredients { get; }
        IDishRepository Dishes { get; }
        IRepository<DishCategory, (int DishId, int CategoryId)> DishCategories { get; }
        IRepository<DishIngredient, (int DishId, int IngredientId)> DishIngredients { get; }
        IRepository<Favourite, (int UserId, int DishId)> Favourites { get; }
        IRepository<Like, (int UserId, int DishId)> Likes { get; }
        IRepository<User, int> Users { get; }
        IRepository<Role, int> Roles { get; }
        IRepository<UserRole, (int UserId, int RoleId)> UserRoles { get; }
        IRepository<UserToken, (int UserId, string LoginProvider, string Name)> UserTokens { get; }
        IRepository<UserLogin, (string LoginProvider, string ProviderKey)> UserLogins { get; }
        IRepository<UserClaim, int> UserClaims { get; }
        IRepository<RoleClaim, int> RoleClaims { get; }

        Task CommitAsync();
    }
}
