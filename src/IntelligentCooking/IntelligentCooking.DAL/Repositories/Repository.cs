using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using IntelligentCooking.Core.Interfaces.Infrastructure;
using IntelligentCooking.Core.Interfaces.Repositories;
using IntelligentCooking.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace IntelligentCooking.DAL.Repositories
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class, IIdentifiable<TKey>
    {
        protected readonly IntelligentCookingContext Context;

        public Repository(IntelligentCookingContext context) => Context = context;

        public async Task<TEntity> FindAsync(TKey key, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return await Include(includeProperties)
                .FirstOrDefaultAsync(x => x.Id.Equals(key));
        }

        public TEntity Add(TEntity item) =>
            Context.Set<TEntity>()
                .Add(item)
                .Entity;

        public void AddRange(IEnumerable<TEntity> items)
        {
            Context.Set<TEntity>()
                .AddRange(items);
        }

        public void Remove(TEntity item)
        {
            Context.Set<TEntity>()
                .Remove(item);
        }

        public void RemoveRange(IEnumerable<TEntity> items)
        {
            Context.Set<TEntity>().RemoveRange(items);
        }


        public async Task<TEntity> GetOne(
            Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return await Include(includeProperties)
                .FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<TEntity>> Get(
            Expression<Func<TEntity, bool>> predicate = null,
            int? skip = null,
            int? take = null,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = Include(includeProperties);

            if(predicate != null)
            {
                query = query.Where(predicate);
            }

            if(skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if(take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return await query.ToListAsync();
        }

        protected IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = Context.Set<TEntity>().AsQueryable();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}
