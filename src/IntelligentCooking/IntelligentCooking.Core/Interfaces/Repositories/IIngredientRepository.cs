using System.Threading.Tasks;
using IntelligentCooking.Core.Entities;

namespace IntelligentCooking.Core.Interfaces.Repositories
{
    public interface IIngredientRepository : IRepository<Ingredient, int>
    {
        Task<Ingredient> GetByNameAsync(string name);
    }
}
