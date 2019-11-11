using IntelligentCooking.Core.Entities;
using IntelligentCooking.Core.Interfaces.Repositories;
using IntelligentCooking.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace IntelligentCooking.DAL.Repositories
{
    public class CategoryRepository : Repository<Category, int>, ICategoryRepository
    {
        public CategoryRepository(IntelligentCookingContext context) : base(context) { }

        public async Task<Category> GetByNameAsync(string name)
        {
            return await Context.Categories.FirstOrDefaultAsync(x => x.Name.Equals(name));
        }
    }
}
