using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterDataSubmission.Data.Helpers
{
    public static class CompareExtentions
    {
        public static IComparer<T> ToComparer<T>(Func<T, T, int> compare) =>
            Comparer<T>.Create(new Comparison<T>(compare));

        public static IEqualityComparer<T> ToEqualityComparer<T>(Func<T, T, bool> equals, Func<T, int> hash = null) =>
            new EqualityComparerWrapper<T>(equals, hash);

    }
}
