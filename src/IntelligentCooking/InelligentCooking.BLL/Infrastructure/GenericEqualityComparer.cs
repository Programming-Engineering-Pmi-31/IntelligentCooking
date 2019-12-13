using System;
using System.Collections.Generic;

namespace InelligentCooking.BLL.Infrastructure
{
    public class GenericEqualityComparer<T>: IEqualityComparer<T>
    {
        private readonly Func<T, T, bool> _eqComparer;
        private readonly Func<T, int> _hashFunc;

        protected GenericEqualityComparer(Func<T, T, bool> eqComparer, Func<T, int> hashFunc)
        {
            _eqComparer = eqComparer;
            _hashFunc = hashFunc;
        }

        public static IEqualityComparer<T> GetEqualityComparer(Func<T, T, bool> eqComparer, Func<T, int> hashFunc)
        {
            return new GenericEqualityComparer<T>(eqComparer, hashFunc);
        }

        public bool Equals(T x, T y) => _eqComparer(x, y);

        public int GetHashCode(T obj) => _hashFunc(obj);
    }
}
