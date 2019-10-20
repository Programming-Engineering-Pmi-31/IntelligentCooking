using InelligentCooking.BLL.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InelligentCooking.BLL.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetCategoriesAsync();
    }
}
