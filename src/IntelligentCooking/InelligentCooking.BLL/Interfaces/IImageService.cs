using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace InelligentCooking.BLL.Interfaces
{
    public interface IImageService
    {
        Task<string> UploadImageAsync(IFormFile file);

        Task<IEnumerable<string>> UploadRangeAsync(IEnumerable<IFormFile> file);
    }
}
