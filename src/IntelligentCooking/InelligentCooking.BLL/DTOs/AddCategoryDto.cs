using Microsoft.AspNetCore.Http;

namespace InelligentCooking.BLL.DTOs
{
    public class AddCategoryDto
    {
        public string Name { get; set; }

        public IFormFile Image { get; set; }
    }
}
