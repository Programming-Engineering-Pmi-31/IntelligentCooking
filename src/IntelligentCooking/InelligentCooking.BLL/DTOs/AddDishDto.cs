using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace InelligentCooking.BLL.DTOs
{
    public class AddDishDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile Image { get; set; }
        public string Recipe { get; set; }
        public DateTime Time { get; set; }
        public int Servings { get; set; }
        public int Rating { get; set; }
        public double? Proteins { get; set; }
        public double? Fats { get; set; }
        public double? Carbohydrates { get; set; }
        public int? Calories { get; set; }
        public string Description { get; set; }

        public IEnumerable<int> Ingredients { get; set; }
        public IEnumerable<int> Categories { get; set; }
    }
}
