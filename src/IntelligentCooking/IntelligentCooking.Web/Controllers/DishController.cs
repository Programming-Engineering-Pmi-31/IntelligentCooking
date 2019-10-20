using System.Collections.Generic;
using System.Threading.Tasks;
using InelligentCooking.BLL.DTOs;
using Microsoft.AspNetCore.Mvc;
using InelligentCooking.BLL.Interfaces;
using IntelligentCooking.Web.Models.RequestModels;

namespace IntelligentCooking.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private IDishService _dishService;

        public DishController(IDishService dishService)
        {
            _dishService = dishService;
        }

        [HttpGet]
        public async Task<IEnumerable<DishPreviewDto>> GetDishesInfo([FromQuery] GetDishRequest getDishRequest)
        {
            return await _dishService.GetDishesInfoAsync(getDishRequest.Skip, getDishRequest.Take);
        }

        [HttpPost]
        public async Task<DishDto> AddDish([FromForm]AddDishDto addDish)
        {
            return await _dishService.AddDishAsync(addDish);
        }

        [HttpGet("{id}")]
        public async Task<DishDto> GetDishById(int id)
        {
            return await _dishService.FindByIdAsync(id);
        }
    }
}