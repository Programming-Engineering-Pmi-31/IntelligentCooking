﻿using System;
using System.Collections.Generic;
using System.Text;
using IntelligentCooking.Core.Interfaces.Infrastructure;

namespace IntelligentCooking.Core.Entities
{
    public class Ingredient
    {
        public Ingredient()
        {
            DishIngredients = new HashSet<DishIngredient>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<DishIngredient> DishIngredients { get; set; }
    }
}
