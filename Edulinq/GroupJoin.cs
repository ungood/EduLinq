using System;
using System.Collections.Generic;

namespace Edulinq
{
    public static partial class Enumerable
    {
        /// <summary>
        /// For each item in outer, return a group of all elements in inner with a matching key.
        /// </summary>
        public static IEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(
            this IEnumerable<TOuter> outer,
            IEnumerable<TInner> inner,
            Func<TOuter, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TOuter, IEnumerable<TInner>, TResult> resultSelector,
            IEqualityComparer<TKey> comparer = null)
        {
            if(outer == null)
                throw new ArgumentNullException("outer");
            if(inner == null)
                throw new ArgumentNullException("inner");
            if(outerKeySelector == null)
                throw new ArgumentNullException("outerKeySelector");
            if(innerKeySelector == null)
                throw new ArgumentNullException("innerKeySelector");
            if(resultSelector == null)
                throw new ArgumentNullException("resultSelector");

            comparer = comparer ?? EqualityComparer<TKey>.Default;

            return GroupJoinImpl(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);
        }

        private static IEnumerable<TResult> GroupJoinImpl<TOuter, TInner, TKey, TResult>(
            this IEnumerable<TOuter> outer,
            IEnumerable<TInner> inner,
            Func<TOuter, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TOuter, IEnumerable<TInner>, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
        {
            var innerLookup = ToLookup(inner, innerKeySelector, comparer);

            foreach (var outerItem in outer)
            {
                var outerKey = outerKeySelector(outerItem);
                var innerNoNulls = innerLookup[outerKey].Where(innerItem => innerKeySelector(innerItem) != null);
                yield return resultSelector(outerItem, innerNoNulls);
            }
        }
    }
}
