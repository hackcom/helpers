using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterDataSubmission.Data.Helpers
{
    public class EqualityComparerWrapper<T>: IEqualityComparer<T>
    {
        private readonly Func<T, T, bool> _equals;
        private readonly Func<T, int> _hash;

        public EqualityComparerWrapper(Func<T, T, bool> equals, Func<T, int> hash = null)
        {
            _equals = equals;
            _hash = hash ?? (value => value.GetHashCode());
        }

        public bool Equals(T x, T y) => _equals(x, y);
        public int GetHashCode(T obj) => _hash(obj);
    }
}
