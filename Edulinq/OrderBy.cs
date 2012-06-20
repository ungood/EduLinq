using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Edulinq
{
    public static partial class Enumerable
    {
        public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            IComparer<TKey> comparer = null)
        {
            if(source == null)
                throw new ArgumentNullException("source");
            if(keySelector == null)
                throw new ArgumentNullException("keySelector");

            comparer = comparer ?? Comparer<TKey>.Default;

            var newComparer = new ProjectionComparer<TSource, TKey>(keySelector, comparer);
            return new OrderedEnumerable<TSource>(source, newComparer);
        }

        public static IOrderedEnumerable<TSource> OrderByDescending<TSource, TKey>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            IComparer<TKey> comparer = null)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (keySelector == null)
                throw new ArgumentNullException("keySelector");

            comparer = comparer ?? Comparer<TKey>.Default;

            var projectionComparer = new ProjectionComparer<TSource, TKey>(keySelector, comparer);
            var reverseComparer = new ReverseComparer<TSource>(projectionComparer);
            return new OrderedEnumerable<TSource>(source, reverseComparer);
        }

        public static IOrderedEnumerable<TSource> ThenBy<TSource, TKey>(
            this IOrderedEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            IComparer<TKey> comparer = null)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (keySelector == null)
                throw new ArgumentNullException("keySelector");

            comparer = comparer ?? Comparer<TKey>.Default;

            return source.CreateOrderedEnumerable(keySelector, comparer, false);
        }

        public static IOrderedEnumerable<TSource> ThenByDescending<TSource, TKey>(
            this IOrderedEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            IComparer<TKey> comparer = null)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (keySelector == null)
                throw new ArgumentNullException("keySelector");

            comparer = comparer ?? Comparer<TKey>.Default;

            return source.CreateOrderedEnumerable(keySelector, comparer, true);
        }
    }
}
