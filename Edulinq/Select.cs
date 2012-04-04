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
            return SelectImpl(source, selector);
        }

        private static IEnumerable<TResult> SelectImpl<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, TResult> selector)
        {
            foreach(var item in source)
            {
                yield return selector(item);
            }
        }

        public static IEnumerable<TResult> Select<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, int, TResult> selector)
        {
            if (source == null) { throw new ArgumentNullException("source"); }
            if (selector == null) { throw new ArgumentNullException("selector"); }
            return SelectImpl(source, selector);
        }

        private static IEnumerable<TResult> SelectImpl<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, int, TResult> selector)
        {
            var index = 0;
            foreach(var item in source)
            {
                yield return selector(item, index);
                index++;
            }
        }
    }
}
