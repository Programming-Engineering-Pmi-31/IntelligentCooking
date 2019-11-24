using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace InelligentCooking.BLL.DTOs
{
    public class AddDishDto
    {
        public string Name { get; set; }

        public string Recipe { get; set; }

        public string Time { get; set; }

        public int Servings { get; set; }

        public double Proteins { get; set; }

        public double Fats { get; set; }

        public double Carbohydrates { get; set; }

        public double Calories { get; set; }

        public string Description { get; set; }

        public IEnumerable<IFormFile> Images { get; set; }

        public IEnumerable<int> Ingredients { get; set; }

        public IEnumerable<string> IngredientAmounts { get; set; }

        public IEnumerable<int> Categories { get; set; }
    }
}
