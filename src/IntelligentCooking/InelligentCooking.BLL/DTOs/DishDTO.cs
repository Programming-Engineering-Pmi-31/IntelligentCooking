﻿using System.Collections.Generic;

namespace InelligentCooking.BLL.DTOs
{
    public class DishDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Recipe { get; set; }
        public int Rating { get; set; }
        public int Likes { get; set; }
        public string Time { get; set; }
        public int Servings { get; set; }
        public double Calories { get; set; }
        public double Proteins { get; set; }
        public double Fats { get; set; }
        public double Carbohydrates { get; set; }
        public string Description { get; set; }

        public IEnumerable<ImageDto> Images { get; set; }
        public IEnumerable<IngredientDto> Ingredients { get; set; }
        public IEnumerable<CategoryDto> Categories { get; set; }
    }
}
