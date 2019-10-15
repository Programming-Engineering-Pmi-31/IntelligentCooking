using InelligentCooking.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InelligentCooking.BLL.Interfaces
{
    public interface IDishService
    {
        Task<IEnumerable<DishPreviewDto>> GetDishesInfoAsync(MainGetDishDto getDish);

        Task<DishPreviewDto> AddDishAsync(AddDishDto addDish);

        Task<DishDto> FindByIdAsync(int id);
    }
}
