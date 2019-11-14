﻿using System.Linq;
using System.Threading.Tasks;
using IntelligentCooking.Core.Entities;
using IntelligentCooking.Core.Interfaces.Repositories;
using IntelligentCooking.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace IntelligentCooking.DAL.Repositories
{
    public class LikeRepository : Repository<Like, (int UserId, int DishId)>, ILikeRepository
    {
        public LikeRepository(IntelligentCookingContext context) : base(context) {}

        public async Task<double> AvgForDish(int dishId)
        {
            var count = await Context.Likes.CountAsync(x => x.DishId == dishId);
            var sum = await Context.Likes.SumAsync(x => x.Value);

            return count == 0 ? 0 : sum / count;
        }
            
    }
}
