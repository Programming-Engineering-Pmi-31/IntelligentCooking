using System.Threading.Tasks;
using InelligentCooking.BLL.DTOs;
using InelligentCooking.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IntelligentCooking.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private IIngredientService _ingredientService;

        public IngredientController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetIngredients()
        {
            return Ok(await _ingredientService.GetIngredientsAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddIngredient([FromForm]AddIngredientDto addIngredient)
        {
            return Ok(await _ingredientService.AddIngredientAsync(addIngredient));
        }
    }
}