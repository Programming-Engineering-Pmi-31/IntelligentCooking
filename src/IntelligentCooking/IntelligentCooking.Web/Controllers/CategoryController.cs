using System.Threading.Tasks;
using InelligentCooking.BLL.DTOs;
using InelligentCooking.BLL.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IntelligentCooking.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Authorize()]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(await _categoryService.GetCategoriesAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromForm]AddCategoryDto addCategory)
        {
            return Ok(await _categoryService.AddCategoryAsync(addCategory));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCategoryById(int id)
        {
            await _categoryService.RemoveCategoryByIdAsync(id);

            return Ok();
        }
    }
}