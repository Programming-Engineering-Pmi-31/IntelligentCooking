using System.Collections.Generic;
using InelligentCooking.BLL.DTOs;

namespace InelligentCooking.BLL.Models.ResponseModels
{
    public class DishPreviewResponse
    {
        public IEnumerable<DishPreviewDto> Dishes { get; set; }
        public int Count { get; set; }
    }
}
