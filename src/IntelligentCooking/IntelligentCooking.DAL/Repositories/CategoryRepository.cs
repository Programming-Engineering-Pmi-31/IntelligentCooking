using System.Collections.Generic;
using System.Threading.Tasks;
using IntelligentCooking.Core.Entities;
using IntelligentCooking.Core.Interfaces.Repositories;
using IntelligentCooking.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace IntelligentCooking.DAL.Repositories
{
    public class CategoryRepository : NewRepository, ICategoryRepository
    {
        public CategoryRepository(IntelligentCookingContext context) : base(context) { }

        public async Task<IEnumerable<Category>> GetAsync()
        {
            return await Context.Categories.ToListAsync();
        }    
    }
}
