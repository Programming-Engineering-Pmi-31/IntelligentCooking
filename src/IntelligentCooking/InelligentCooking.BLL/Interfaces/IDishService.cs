﻿using InelligentCooking.BLL.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using IntelligentCooking.Web.Models.RequestModels;

namespace InelligentCooking.BLL.Interfaces
{
    public interface IDishService
    {
        Task<IEnumerable<DishPreviewDto>> GetDishesInfoAsync(GetDishRequest getDish);

        Task<DishDto> AddDishAsync(AddDishDto addDish);

        Task<DishDto> FindByIdAsync(int id);
    }
}
