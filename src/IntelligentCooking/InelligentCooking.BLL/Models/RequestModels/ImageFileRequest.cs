using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace InelligentCooking.BLL.Models.RequestModels
{
    public class ImageFileRequest: UpdateImageRequest
    {
        public IFormFile File { get; set; }
    }
}
