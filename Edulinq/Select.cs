using System;
using System.Collections.Generic;
using System.Text;

namespace Edulinq
{
    public static partial class Enumerable
    {
        public static IEnumerable<TResult> Select<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, TResult> selector)
        {
            if (source == null) { throw new ArgumentNullException("source"); }
            if (selector == null) { throw new ArgumentNullException("selector"); }

            throw new NotImplementedException();
        }

        public static IEnumerable<TResult> Select<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, int, TResult> selector)
        {
            if (source == null) { throw new ArgumentNullException("source"); }
            if (selector == null) { throw new ArgumentNullException("selector"); }

            throw new NotImplementedException();
        }
    }
}
