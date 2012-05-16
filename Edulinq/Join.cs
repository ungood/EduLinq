using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Edulinq
{
    public static partial class Enumerable
    {
        /// <summary>
        /// For each item in outer, and each item in inner, if innerKey equals outerKey, return a result
        /// </summary>
        public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(
            this IEnumerable<TOuter> outer,
            IEnumerable<TInner> inner,
            Func<TOuter, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TOuter, TInner, TResult> resultSelector,
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

            // For each item in outer and each item in inner, if innerKey and outerKey are equal, return a result.

            comparer = comparer ?? EqualityComparer<TKey>.Default;

            return JoinImpl(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);
        }

        private static IEnumerable<TResult> JoinImpl<TOuter, TInner, TKey, TResult>(
            this IEnumerable<TOuter> outer,
            IEnumerable<TInner> inner,
            Func<TOuter, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TOuter, TInner, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
        {

            var innerLookup = ToLookup(inner, innerKeySelector, comparer);

            foreach(var outerItem in outer)
            {
                var outerKey = outerKeySelector(outerItem);
                if (outerKey != null)
                {
                    foreach (var innerItem in innerLookup[outerKey])
                    {
                        yield return resultSelector(outerItem, innerItem);
                    }
                }
            }
        }
    }
}
