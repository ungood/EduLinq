using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Edulinq
{
    public static partial class Enumerable
    {
        public static ILookup<TKey, TSource> ToLookup<TSource, TKey>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            IEqualityComparer<TKey> comparer = null)
        {
            return ToLookup(source, keySelector, item => item, comparer);
        }

        public static ILookup<TKey, TElement> ToLookup<TSource, TKey, TElement>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            IEqualityComparer<TKey> comparer = null)
        {
            if(source == null)
                throw new ArgumentNullException("source");
            if(keySelector == null)
                throw new ArgumentNullException("keySelector");
            if(elementSelector == null)
                throw new ArgumentNullException("elementSelector");

            comparer = comparer ?? EqualityComparer<TKey>.Default;

            var result = new Lookup<TKey, TElement>(comparer);
            foreach(var item in source)
            {
                result.Add(keySelector(item), elementSelector(item));
            }
            return result;
        }
    }
}
