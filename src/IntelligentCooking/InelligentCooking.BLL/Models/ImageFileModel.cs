using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace InelligentCooking.BLL.Models
{
    public class ImageFileModel: UpdateImageModel
    {
        public IFormFile File { get; set; }
    }
}
