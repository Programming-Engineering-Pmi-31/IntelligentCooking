using System.Collections.Generic;

namespace InelligentCooking.BLL.Infrastructure.Extensions
{
    public static class CollectionExtensions
    {
        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> data)
        {
            if(data != null)
            {
                foreach(var d in data)
                {
                    collection.Add(d);
                }
            }
        }
    }
}
