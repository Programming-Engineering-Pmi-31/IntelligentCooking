using InelligentCooking.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InelligentCooking.BLL.Interfaces
{
    public interface IDishService
    {
        Task<IEnumerable<DishPreviewDto>> GetDishesInfo(MainGetDishDto getDish);

        Task<DishPreviewDto> AddDish(AddDishDto addDish);
    }
}
