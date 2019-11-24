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

        [HttpPost("search")]
        public async Task<IActionResult> GetDishesByIngredients(FilterRequest filterRequest)
        {
            return Ok(await _dishService.GetDishesByIngredients(filterRequest));
        }

        [HttpPost]
        public async Task<IActionResult> AddDish([FromForm]AddDishDto addDish)
        {
            return Ok(await _dishService.AddDishAsync(addDish));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveDishById(int id)
        {
            await _dishService.RemoveDishByIdAsync(id);

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDishById(int id)
        {
            return Ok(await _dishService.FindByIdAsync(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDish([FromRoute]int id, [FromForm]UpdateDishDto updateDish)
        {
            return Ok(await _dishService.UpdateDishAsync(id, updateDish));
        }

        [HttpGet("top")]
        public async Task<IActionResult> GetTopDishesInfo([FromForm]int amount)
        {
            return Ok(await _dishService.GetTopDishesInfoAsync(amount));
        }
    }
}