using System;
using System.Collections.Generic;
using System.Text;
using IntelligentCooking.Core.Interfaces.Infrastructure;

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
