using System;
using System.Threading.Tasks;
using IntelligentCooking.Core.Entities;
using IntelligentCooking.Core.Interfaces.Repositories;
using IntelligentCooking.Core.Interfaces.UnitsOfWork;
using IntelligentCooking.DAL.Context;
using IntelligentCooking.DAL.Repositories;

namespace IntelligentCooking.DAL.UnitsOfWork
{
    public class IntelligentCookingUnitOfWork : IIntelligentCookingUnitOfWork
    {
        private bool _disposed = false;

        private readonly IntelligentCookingContext _context;

        public IntelligentCookingUnitOfWork(IntelligentCookingContext context)
        {
            _context = context;
            Categories = new Repository<Category, int>(_context);
            Dishes = new Repository<Dish, int>(_context);
            DishCategories = new Repository<DishCategory, (int DishId, int CategoryId)>(_context);
            DishIngredients = new Repository<DishIngredient, (int DishId, int IngredientId)>(_context);
            Favourites = new Repository<Favourite, (int UserId, int DishId)>(_context);
            Likes = new Repository<Like, (int UserId, int DishId)>(_context);
            Users = new Repository<User, int>(_context);
            Roles = new Repository<Role, int>(_context);
            UserRoles = new Repository<UserRole, (int UserId, int RoleId)>(_context);
            UserTokens = new Repository<UserToken, (int UserId, string LoginProvider, string Name)>(_context);
            UserLogins = new Repository<UserLogin, (string LoginProvider, string ProviderKey)>(_context);
            UserClaims = new Repository<UserClaim, int>(_context);
            RoleClaims = new Repository<RoleClaim, int>(_context);
        }

        public IRepository<Category, int> Categories { get; }
        public IRepository<Ingredient, int> Ingredients { get; set; }
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
