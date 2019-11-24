using System.Collections.Generic;
using System.Threading.Tasks;
using InelligentCooking.BLL.DTOs;
using InelligentCooking.BLL.Models.ResponseModels;
using IntelligentCooking.Web.Models.RequestModels;

namespace InelligentCooking.BLL.Interfaces
{
    public interface IDishService
    {
        Task<DishPreviewResponse> GetDishesInfoAsync(GetDishRequest getDish);

        Task<DishDto> AddDishAsync(AddDishDto addDish);

        Task RemoveDishByIdAsync(int id);

        Task<DishDto> FindByIdAsync(int id);

        Task<DishDto> UpdateDishAsync(int id, UpdateDishDto updateDish);

        Task<IEnumerable<DishPreviewDto>> GetDishesByIngredients(FilterRequest filterRequest);
    }
}
