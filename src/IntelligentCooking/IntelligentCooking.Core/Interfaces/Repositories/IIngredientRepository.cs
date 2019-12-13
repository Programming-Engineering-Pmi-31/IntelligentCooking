using IntelligentCooking.Core.Entities;
using System.Threading.Tasks;

namespace IntelligentCooking.Core.Interfaces.Repositories
{
    public interface IIngredientRepository: IRepository<Ingredient, int>
    {
        Task<Ingredient> GetByNameAsync(string name);
    }
}
