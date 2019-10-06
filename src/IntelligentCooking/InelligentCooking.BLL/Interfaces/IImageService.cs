using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace InelligentCooking.BLL.Interfaces
{
    public interface IImageService
    {
        Task<string> UploadImageAsync(IFormFile file);
    }
}
