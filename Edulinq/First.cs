using System;
using System.Collections.Generic;

namespace Edulinq
{
    public static partial class Enumerable
    {
        public static TSource First<TSource>(
            this IEnumerable<TSource> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            foreach(var item in source)
            {
                return item;
            }

            throw new InvalidOperationException("Sequence contains no elements.");
        }

        public static TSource First<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (predicate == null)
                throw new ArgumentNullException("predicate");

            foreach(var item in source)
            {
                if(predicate(item))
                    return item;
            }

            throw new InvalidOperationException("Sequence contains no elements.");
        }
    }
}
