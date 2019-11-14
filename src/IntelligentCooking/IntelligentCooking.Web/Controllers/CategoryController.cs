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
<<<<<<< HEAD
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
||||||| merged common ancestors
<<<<<<<<< Temporary merge branch 1
   // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
||||||||| merged common ancestors
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
=========
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
>>>>>>>>> Temporary merge branch 2
=======
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
>>>>>>> 69c9461f09edacf08622d073eca781a64aacc3a9
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
<<<<<<< HEAD
<<<<<<< HEAD
||||||| merged common ancestors
        [Authorize(Roles="User")]
=======
      //  [Authorize(Roles="User")]
>>>>>>> b0a998eca93ee776c8333ed287df14f2764d7871
||||||| merged common ancestors
<<<<<<<<< Temporary merge branch 1
      //  [Authorize(Roles="User")]
||||||||| merged common ancestors
        [Authorize(Roles="User")]
=========
>>>>>>>>> Temporary merge branch 2
=======
>>>>>>> 69c9461f09edacf08622d073eca781a64aacc3a9
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