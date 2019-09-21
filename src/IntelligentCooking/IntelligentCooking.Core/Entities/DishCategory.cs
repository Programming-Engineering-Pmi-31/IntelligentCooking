using System;
using System.Collections.Generic;
using System.Text;

namespace IntelligentCooking.Core.Entities
{
    public class DishCategory
    {
        public int DishId { get; set; }
        public Dish Dish { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
