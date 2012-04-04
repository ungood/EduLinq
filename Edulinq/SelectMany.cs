using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Edulinq
{
    public static partial class Enumerable
    {
        #region Simple

        public static IEnumerable<TResult> SelectMany<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, IEnumerable<TResult>> selector)
        {
            if (source == null) { throw new ArgumentNullException("source"); }
            if (selector == null) { throw new ArgumentNullException("selector"); }

            return SelectManyImpl(source, selector);
        }

        private static IEnumerable<TResult> SelectManyImpl<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, IEnumerable<TResult>> selector)
        {
            foreach(var inner in source)
            {
                foreach(var item in selector(inner))
                {
                    yield return item;
                }
            }
        }

        #endregion

        #region Simple with Index

        public static IEnumerable<TResult> SelectMany<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, int, IEnumerable<TResult>> selector)
        {
            if (source == null) { throw new ArgumentNullException("source"); }
            if (selector == null) { throw new ArgumentNullException("selector"); }

            return SelectManyImpl(source, selector);
        }

        private static IEnumerable<TResult> SelectManyImpl<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, int, IEnumerable<TResult>> selector)
        {
            int index = 0;
            foreach(var inner in source)
            {
                foreach(var item in selector(inner, index++))
                {
                    yield return item;
                }
            }
        }

        #endregion

        #region Projection

        public static IEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, IEnumerable<TCollection>> collectionSelector,
            Func<TSource, TCollection, TResult> resultSelector)
        {
            if (source == null) { throw new ArgumentNullException("source"); }
            if (collectionSelector == null) { throw new ArgumentNullException("collectionSelector"); }
            if (resultSelector == null) { throw new ArgumentNullException("resultSelector"); }

            return SelectManyImpl(source, collectionSelector, resultSelector);
        }

        private static IEnumerable<TResult> SelectManyImpl<TSource, TCollection, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, IEnumerable<TCollection>> collectionSelector,
            Func<TSource, TCollection, TResult> resultSelector)
        {
            foreach(var inner in source)
            {
                foreach(var item in collectionSelector(inner))
                {
                    yield return resultSelector(inner, item);
                }
            }            
        }

        #endregion

        #region  Projection with Index

        public static IEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, int, IEnumerable<TCollection>> collectionSelector,
            Func<TSource, TCollection, TResult> resultSelector)
        {
            if (source == null) { throw new ArgumentNullException("source"); }
            if (collectionSelector == null) { throw new ArgumentNullException("collectionSelector"); }
            if (resultSelector == null) { throw new ArgumentNullException("resultSelector"); }

            return SelectManyImpl(source, collectionSelector, resultSelector);
        }

        private static IEnumerable<TResult> SelectManyImpl<TSource, TCollection, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, int, IEnumerable<TCollection>> collectionSelector,
            Func<TSource, TCollection, TResult> resultSelector)
        {
            int index = 0;
            foreach(var inner in source)
            {
                foreach(var item in collectionSelector(inner, index++))
                {
                    yield return resultSelector(inner, item);
                }
            }            
        }

        #endregion
    }
}
