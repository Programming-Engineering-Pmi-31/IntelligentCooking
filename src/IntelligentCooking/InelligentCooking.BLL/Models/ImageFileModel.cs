using Microsoft.AspNetCore.Http;

namespace InelligentCooking.BLL.Models
{
    public class ImageFileModel : UpdateImageModel
    {
        public IFormFile File { get; set; }
    }
}
