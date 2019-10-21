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
        public async Task<IActionResult> GetDishesInfo([FromQuery] GetDishRequest getDishRequest)
        {
            return Ok(await _dishService.GetDishesInfoAsync(getDishRequest));
        }

        [HttpPost]
        public async Task<IActionResult> AddDish([FromForm]AddDishDto addDish)
        {
            return Ok(await _dishService.AddDishAsync(addDish));
        }

        [HttpGet("{id}")]
        public async Task<DishDto> GetDishById(int id)
        {
            return await _dishService.FindByIdAsync(id);
        }
    }
}