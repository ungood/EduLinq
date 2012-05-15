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

            throw new NotImplementedException();
        }
    }
}
