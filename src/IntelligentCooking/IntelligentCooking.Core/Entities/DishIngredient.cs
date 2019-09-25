using System;
using System.Collections.Generic;
using System.Text;
using IntelligentCooking.Core.Interfaces.Infrastructure;

namespace IntelligentCooking.Core.Entities
{
    public class DishIngredient: IIdentifiable<(int DishId, int IngredientId)>
    {
        public int DishId { get; set; }
        public Dish Dish { get; set; }
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
        public string Amount { get; set; }
        public (int DishId, int IngredientId) Id => (DishId, IngredientId);
    }
}
