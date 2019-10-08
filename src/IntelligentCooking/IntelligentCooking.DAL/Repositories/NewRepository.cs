using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using IntelligentCooking.Core.Interfaces.Infrastructure;
using IntelligentCooking.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace IntelligentCooking.DAL.Repositories
{
    public abstract class NewRepository
    {
        protected readonly IntelligentCookingContext Context;

        public NewRepository(IntelligentCookingContext context) => Context = context;
    }
}
