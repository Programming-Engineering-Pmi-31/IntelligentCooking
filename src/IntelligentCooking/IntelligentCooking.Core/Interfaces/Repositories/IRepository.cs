using System.Collections.Generic;
using System.Threading.Tasks;
using IntelligentCooking.Core.Interfaces.Infrastructure;

namespace IntelligentCooking.Core.Interfaces.Repositories
{
    public interface IRepository<TEntity, in TKey>
        where TEntity : class, IIdentifiable<TKey>
    {
        Task<TEntity> FindAsync(TKey key);

        Task<IEnumerable<TEntity>> GetAsync();

        TEntity Add(TEntity item);

        Task<int> CountAsync();

        void AddRange(IEnumerable<TEntity> items);

        void Remove(TEntity item);

        void RemoveRange(IEnumerable<TEntity> items);
    }
}
