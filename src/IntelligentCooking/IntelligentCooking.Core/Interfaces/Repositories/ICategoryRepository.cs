using IntelligentCooking.Core.Entities;
using System.Threading.Tasks;

namespace IntelligentCooking.Core.Interfaces.Repositories
{
    public interface ICategoryRepository: IRepository<Category, int>
    {
        Task<Category> GetByNameAsync(string name);
    }
}
