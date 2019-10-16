using System;
using System.Collections.Generic;
using System.Text;

namespace InelligentCooking.BLL.DTOs
{
    public class MainGetDishDto
    {
        public int? Skip { get; set; }
        public int? Take { get; set; }
        public bool ByTime { get; set; } = false;
        public bool ByCalories { get; set; } = false;
    }
}
