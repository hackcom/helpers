using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterDataSubmission.Data.Helpers
{
    public static class FunctionalExtensions
    {
        public static IEnumerable<U> Map<T, U>(this IEnumerable<T> data, Func<T, U> func)
        {
            return data.Select(func).ToArray();
        }

        public static U Map<T, U>(this T data, Func<T, U> func)
        {
            return func(data);
        }

        public static U Reduce<T, U>(this IEnumerable<T> data, Func<U, T, U> func, U initialValue) where U: class
        {
            return data.Aggregate(initialValue, func);
        }

        public static Dictionary<TK, List<T>> ToListDictionary<TK, T>(this IEnumerable<T> data, Func<T, TK> keySelector)
        {
            return data.Reduce((acc, cur) =>
            {
                var key = keySelector(cur);
                if (!acc.ContainsKey(key))
                {
                    acc[key] = new List<T>();
                }
                acc[key].Add(cur);
                return acc;
            }, new Dictionary<TK, List<T>>());
        }

        public static IEnumerable<T> Zip<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            var firstIter = first.GetEnumerator();
            var secondIter = second.GetEnumerator();

            while (firstIter.MoveNext())
            {
                yield return firstIter.Current;
                if (secondIter.MoveNext())
                {
                    yield return secondIter.Current;
                }
            }
        }
    }
}
