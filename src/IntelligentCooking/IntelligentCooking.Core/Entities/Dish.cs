using System;
using System.Collections.Generic;
using System.Text;

namespace IntelligentCooking.Core.Entities
{
    public class Dish
    {
        public int DishId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Recipe { get; set; }
        public DateTime Time { get; set; }
        public int Servings { get; set; }
        public int Stars { get; set; }
        public double? Proteins { get; set; }
        public double? Fats { get; set; }
        public double? Carbohydrates { get; set; }
        public int? Calories { get; set; }
        public string Description { get; set; }

        public ICollection<DishIngredient> DishIngredients { get; set; }
        public ICollection<DishCategory> DishCategories { get; set; }
        public ICollection<Like> Likes { get; set; }
        public ICollection<Favourite> Favourites { get; set; }
    }
}
