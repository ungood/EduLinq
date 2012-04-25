using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Edulinq
{
    public static partial class Enumerable
    {
        public static IEnumerable<TSource> Union<TSource>( 
            this IEnumerable<TSource> first, 
            IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer = null)
        {
            var allItems = first.Concat(second);
            return allItems.Distinct(comparer);
        }
    }
}
