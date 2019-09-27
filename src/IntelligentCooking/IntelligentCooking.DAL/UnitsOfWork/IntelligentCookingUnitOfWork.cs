using System;
using System.Threading.Tasks;
using IntelligentCooking.Core.Entities;
using IntelligentCooking.Core.Interfaces.Repositories;
using IntelligentCooking.Core.Interfaces.UnitsOfWork;
using IntelligentCooking.DAL.Context;

namespace IntelligentCooking.DAL.UnitsOfWork
{
    public class IntelligentCookingUnitOfWork : IIntelligentCookingUnitOfWork
    {
        private bool _disposed = false;

        private readonly IntelligentCookingContext _context;

        //TODO Think about passing repos into ctor
        public IntelligentCookingUnitOfWork(
            IntelligentCookingContext context,
            IRepository<Dish, int> dishes,
            IRepository<DishCategory, (int DishId, int CategoryId)> dishCategories,
            IRepository<DishIngredient, (int DishId, int IngredientId)> dishIngredients,
            IRepository<Favourite, (int UserId, int DishId)> favourites,
            IRepository<Like, (int UserId, int DishId)> likes,
            IRepository<User, int> users,
            IRepository<Role, int> roles,
            IRepository<UserRole, (int UserId, int RoleId)> userRoles,
            IRepository<UserToken, (int UserId, string LoginProvider, string Name)> userTokens,
            IRepository<UserLogin, (string LoginProvider, string ProviderKey)> userLogins,
            IRepository<UserClaim, int> userClaims,
            IRepository<RoleClaim, int> roleClaims)
        {
            _context = context;
            Dishes = dishes;
            DishCategories = dishCategories;
            DishIngredients = dishIngredients;
            Favourites = favourites;
            Likes = likes;
            Users = users;
            Roles = roles;
            UserRoles = userRoles;
            UserTokens = userTokens;
            UserLogins = userLogins;
            UserClaims = userClaims;
            RoleClaims = roleClaims;
        }

        public IRepository<Category, int> Categories { get; }
        public IRepository<Dish, int> Dishes { get; }
        public IRepository<DishCategory, (int DishId, int CategoryId)> DishCategories { get; }
        public IRepository<DishIngredient, (int DishId, int IngredientId)> DishIngredients { get; }
        public IRepository<Favourite, (int UserId, int DishId)> Favourites { get; }
        public IRepository<Like, (int UserId, int DishId)> Likes { get; }
        public IRepository<User, int> Users { get; }
        public IRepository<Role, int> Roles { get; }
        public IRepository<UserRole, (int UserId, int RoleId)> UserRoles { get; }
        public IRepository<UserToken, (int UserId, string LoginProvider, string Name)> UserTokens { get; }
        public IRepository<UserLogin, (string LoginProvider, string ProviderKey)> UserLogins { get; }
        public IRepository<UserClaim, int> UserClaims { get; }
        public IRepository<RoleClaim, int> RoleClaims { get; }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _context.Dispose();
            }

            _disposed = true;
        }

        ~IntelligentCookingUnitOfWork()
        {
            Dispose(false);
        }
    }
}
