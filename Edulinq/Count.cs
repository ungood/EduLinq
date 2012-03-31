using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Edulinq
{
    public static partial class Enumerable
    {
        public static int Count<TSource>(
            this IEnumerable<TSource> source)
        {
             throw new InvalidOperationException();
        }

        public static int Count<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            throw new InvalidOperationException();
        }

        public static long LongCount<TSource>(
            this IEnumerable<TSource> source)
        {
            throw new InvalidOperationException();
        }

        public static long LongCount<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            throw new InvalidOperationException();
        }
    }
}
