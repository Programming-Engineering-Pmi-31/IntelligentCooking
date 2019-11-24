using System.Collections.Generic;
using System.Threading.Tasks;
using InelligentCooking.BLL.DTOs;

namespace InelligentCooking.BLL.Interfaces
{
    public interface IIngredientService
    {
        Task<IEnumerable<IngredientDto>> GetIngredientsAsync();

        Task<IngredientDto> AddIngredientAsync(AddIngredientDto addIngredient);

        Task RemoveIngredientByIdAsync(int id);
    }
}
