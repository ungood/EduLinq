using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Edulinq
{
    public static partial class Enumerable
    {
        #region Overloads

        public static IEnumerable<TResult> GroupBy<TSource, TKey, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TKey, IEnumerable<TSource>, TResult> resultSelector,
            IEqualityComparer<TKey> comparer = null)
        {
            return GroupBy(source, keySelector, item => item, resultSelector, comparer);
        }

        public static IEnumerable<IGrouping<TKey, TSource>> GroupBy<TSource, TKey>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            IEqualityComparer<TKey> comparer = null)
        {
            return GroupBy(source, keySelector, item => item, comparer);
        }

        #endregion

        /// <summary>
        /// For each distinct key in source, return an IGrouping.
        /// </summary>
        public static IEnumerable<IGrouping<TKey, TElement>> GroupBy<TSource, TKey, TElement>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            IEqualityComparer<TKey> comparer = null)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (keySelector == null)
                throw new ArgumentNullException("keySelector");
            if (elementSelector == null)
                throw new ArgumentNullException("elementSelector");

            comparer = comparer ?? EqualityComparer<TKey>.Default;
            return GroupByImpl(source, keySelector, elementSelector, comparer);
        }

        private static IEnumerable<IGrouping<TKey, TElement>> GroupByImpl<TSource, TKey, TElement>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            IEqualityComparer<TKey> comparer)
        {
            var lookup = source.ToLookup(keySelector, elementSelector, comparer);
            foreach(var item in lookup)
            {
                yield return item;
            }
        }

        /// <summary>
        /// For each IGrouping, return a projected result.
        /// </summary>
        public static IEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            Func<TKey, IEnumerable<TElement>, TResult> resultSelector,
            IEqualityComparer<TKey> comparer = null)
        {
            if (resultSelector == null)
                throw new ArgumentNullException("resultSelector");

            return GroupByImpl(source, keySelector, elementSelector, comparer).Select(x => resultSelector(x.Key, x));
        }

    }
}
