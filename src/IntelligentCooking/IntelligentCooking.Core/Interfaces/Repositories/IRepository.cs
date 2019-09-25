using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IntelligentCooking.Core.Interfaces.Repositories
{
    public interface IRepository<TEntity, in TKey> where TEntity: class
    {
        TEntity Add(TEntity item);
        void AddRange(IEnumerable<TEntity> items);
        void Remove(TEntity item);
        void RemoveRange(IEnumerable<TEntity> items);
        Task<TEntity> FindAsync(TKey key, params Expression<Func<TEntity, object>>[] includeProperties);
        Task<TEntity> GetOne(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);

        Task<IEnumerable<TEntity>> Get(
            Expression<Func<TEntity, bool>> predicate = null,
            int? skip = null,
            int? take = null,
            params Expression<Func<TEntity, object>>[] includeProperties);

    }
}
