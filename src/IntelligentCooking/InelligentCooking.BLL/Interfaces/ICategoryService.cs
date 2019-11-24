using System.Collections.Generic;
using System.Threading.Tasks;
using InelligentCooking.BLL.DTOs;

namespace InelligentCooking.BLL.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetCategoriesAsync();

        Task<CategoryDto> AddCategoryAsync(AddCategoryDto addCategory);

        Task RemoveCategoryByIdAsync(int id);
    }
}
