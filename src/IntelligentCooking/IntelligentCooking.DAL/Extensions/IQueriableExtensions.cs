using System.Linq;

namespace IntelligentCooking.DAL.Extensions
{
    public static class IQueriableExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> query, int skip, int take)
        {
            return query.Skip(skip)
                .Take(take);
        }
    }
}
