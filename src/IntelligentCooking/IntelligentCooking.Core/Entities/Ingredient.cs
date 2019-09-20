using System;
using System.Collections.Generic;
using System.Text;

namespace IntelligentCooking.Core.Entities
{
    public class Ingredient
    {
        public int IngnredientId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<DishIngredient> DishIngredients { get; set; }
    }
}
