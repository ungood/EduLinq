using System;
using System.Collections.Generic;

namespace Edulinq
{
    public static partial class Enumerable
    {
        public static IEnumerable<TSource> DefaultIfEmpty<TSource>(
            this IEnumerable<TSource> source)
        {
            // This will perform an appropriate test for source being null first. 
            return source.DefaultIfEmpty(default(TSource));
        }

        public static IEnumerable<TSource> DefaultIfEmpty<TSource>(
            this IEnumerable<TSource> source,
            TSource defaultValue)
        {
            if(source == null)
            {
                throw new ArgumentNullException("source");
            }

            using(var enumerator = source.GetEnumerator())
            {
                return enumerator.MoveNext() ? source : new[] {defaultValue};
            }
        }

    }
}
