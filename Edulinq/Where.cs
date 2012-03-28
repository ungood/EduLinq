using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Edulinq
{
    public static partial class Enumerable
    {
        public static IEnumerable<TSource> Where<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            if (source == null) { throw new ArgumentNullException("source"); }
            if (predicate == null) { throw new ArgumentNullException("predicate"); }

            return WhereImpl(source, predicate);
        }

        private static IEnumerable<TSource> WhereImpl<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            //return new WhereEnumerable<TSource>(source, predicate);
            foreach(var item in source)
            {
                if(predicate(item))
                    yield return item;
            }
        }

        public static IEnumerable<TSource> Where<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, int, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
