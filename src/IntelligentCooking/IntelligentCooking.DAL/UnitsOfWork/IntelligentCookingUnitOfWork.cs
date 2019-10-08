using System;
using System.Threading.Tasks;
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
            Categories = new CategoryRepository(_context);
            Ingredients = new IngredientRepository(_context);
            Dishes = new DishRepository(_context);
            DishCategories = new DishCategoryRepository(_context);
            DishIngredients = new DishIngredientRepository(_context);
            Favourites = new FavouriteRepository(_context);
            Likes = new LikeRepository(_context);
            Users = new UserRepository(_context);
            Roles = new RoleRepository(_context);
            UserRoles = new UserRoleRepository(_context);
            UserTokens = new UserTokenRepository(_context);
            UserLogins = new UserLoginRepository(_context);
            UserClaims = new UserClaimRepository(_context);
            RoleClaims = new RoleClaimRepository(_context);
        }

        public ICategoryRepository Categories { get; }
        public IIngredientRepository Ingredients { get; }
        public IDishRepository Dishes { get; }
        public IDishCategoryRepository DishCategories { get; }
        public IDishIngredientRepository DishIngredients { get; }
        public IFavouriteRepository Favourites { get; }
        public ILikeRepository Likes { get; }
        public IUserRepository Users { get; }
        public IRoleRepository Roles { get; }
        public IUserRoleRepository UserRoles { get; }
        public IUserTokenRepository UserTokens { get; }
        public IUserLoginRepository UserLogins { get; }
        public IUserClaimRepository UserClaims { get; }
        public IRoleClaimRepository RoleClaims { get; }


        public async Task CommitAsync()
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
