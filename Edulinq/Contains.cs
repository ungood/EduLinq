using System;
using System.Collections.Generic;

namespace Edulinq
{
    public static partial class Enumerable
    {
        public static bool Contains<TSource>(
            this IEnumerable<TSource> source,
            TSource value)
        {
            throw new NotImplementedException();
        }

        public static bool Contains<TSource>(
            this IEnumerable<TSource> source,
            TSource value,
            IEqualityComparer<TSource> comparer)
        {
            throw new NotImplementedException();
        }
    }
}
