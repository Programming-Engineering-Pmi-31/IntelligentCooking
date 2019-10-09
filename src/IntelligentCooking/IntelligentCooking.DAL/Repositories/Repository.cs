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
    public abstract class Repository<TEntity> where TEntity: class
    {
        protected readonly IntelligentCookingContext Context;

        public Repository(IntelligentCookingContext context) => Context = context;

        public virtual TEntity Add(TEntity item) =>
            Context.Set<TEntity>()
                .Add(item)
                .Entity;

        public virtual void AddRange(IEnumerable<TEntity> items)
        {
            Context.Set<TEntity>()
                .AddRange(items);
        }

        public virtual void Remove(TEntity item)
        {
            Context.Set<TEntity>()
                .Remove(item);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> items)
        {
            Context.Set<TEntity>().RemoveRange(items);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }
    }
}
