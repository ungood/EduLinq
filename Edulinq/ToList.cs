using System;
using System.Collections.Generic;

namespace Edulinq
{
    public static partial class Enumerable
    {
        public static List<TSource> ToList<TSource>(
            this IEnumerable<TSource> source)
        {
            if(source == null)
                throw new ArgumentNullException("source");

            return new List<TSource>(source);
        }

        // What's the point, why use ToList() instead of new List()?
        // anonymous types, that's why.
    }
}
