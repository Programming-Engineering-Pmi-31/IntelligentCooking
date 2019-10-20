using InelligentCooking.BLL.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InelligentCooking.BLL.Interfaces
{
    public interface IDishService
    {
        Task<IEnumerable<DishPreviewDto>> GetDishesInfoAsync(int? skip, int? take);

        Task<DishDto> AddDishAsync(AddDishDto addDish);

        Task<DishDto> FindByIdAsync(int id);
    }
}
