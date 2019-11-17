using System;
using System.Collections.Generic;
using System.Text;

namespace InelligentCooking.BLL.Models.RequestModels
{
    public class ImageUrlRequest: UpdateImageRequest
    {
        public string Url { get; set; }
    }
}
