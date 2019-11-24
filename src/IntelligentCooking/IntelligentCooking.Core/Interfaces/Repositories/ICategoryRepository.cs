using System.Threading.Tasks;
using IntelligentCooking.Core.Entities;

namespace IntelligentCooking.Core.Interfaces.Repositories
{
    public interface ICategoryRepository : IRepository<Category, int>
    {
        Task<Category> GetByNameAsync(string name);
    }
}
