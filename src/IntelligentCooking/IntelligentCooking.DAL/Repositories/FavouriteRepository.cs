using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntelligentCooking.Core.Entities;
using IntelligentCooking.Core.Interfaces.Repositories;
using IntelligentCooking.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace IntelligentCooking.DAL.Repositories
{
    public class FavouriteRepository: Repository<Favourite, (int UserId, int DishId)>, IFavouriteRepository
    {
        public FavouriteRepository(IntelligentCookingContext context) : base(context) {}

        public async Task<IEnumerable<Favourite>> GetWithDishesAsync(int userId)
        {
            return await Context.Favourites.Include(f => f.Dish)
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }
    }
}
