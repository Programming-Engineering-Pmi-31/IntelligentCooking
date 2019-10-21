using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntelligentCooking.Core.Entities;
using IntelligentCooking.Core.Interfaces.Repositories;
using IntelligentCooking.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace IntelligentCooking.DAL.Repositories
{
    public class IngredientRepository: Repository<Ingredient, int>, IIngredientRepository
    {
        public IngredientRepository(IntelligentCookingContext context) : base(context) {}
    }
}
