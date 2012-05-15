using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Edulinq
{
    public static partial class Enumerable
    {
        public static IEnumerable<TSource> Except<TSource>( 
            this IEnumerable<TSource> first, 
            IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer = null)
        {
            if (first == null)
                throw new ArgumentNullException("first");

            if (second == null)
                throw new ArgumentNullException("second");

            comparer = comparer ?? EqualityComparer<TSource>.Default;

            return ExceptImpl(first, second, comparer);
        }

            public static IEnumerable<TSource> ExceptImpl<TSource>( 
            this IEnumerable<TSource> first, 
            IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer = null)
            {
                var hashSet = new HashSet<TSource>(second, comparer);

                foreach(var item in first)
                {
                    if (hashSet.Add(item))
                    {
                        yield return item;
                    }
                }
            }

    }
}
