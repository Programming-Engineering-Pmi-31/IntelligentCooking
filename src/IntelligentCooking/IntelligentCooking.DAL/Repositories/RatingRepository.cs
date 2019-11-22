using System.Linq;
using System.Threading.Tasks;
using IntelligentCooking.Core.Entities;
using IntelligentCooking.Core.Interfaces.Repositories;
using IntelligentCooking.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace IntelligentCooking.DAL.Repositories
{
    public class RatingRepository : Repository<Rating, (int UserId, int DishId)>, IRatingRepository
    {
        public RatingRepository(IntelligentCookingContext context) : base(context) {}

        public async Task<double> AvgForDish(int dishId)
        {
            var count = await Context.Ratings.CountAsync(x => x.DishId == dishId);
            var sum = await Context.Ratings.SumAsync(x => x.Rate);

            return count == 0 ? 0 : sum / count;
        }
            
    }
}
