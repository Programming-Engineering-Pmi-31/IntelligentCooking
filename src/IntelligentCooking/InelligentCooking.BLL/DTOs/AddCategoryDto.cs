using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace InelligentCooking.BLL.DTOs
{
    public class AddCategoryDto
    {
        public string Name { get; set; }
        public IFormFile Image { get; set; }
    }
}
