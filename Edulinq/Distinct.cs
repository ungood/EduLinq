using System;
using System.Collections.Generic;

namespace Edulinq
{
    public static partial class Enumerable
    {
        public static IEnumerable<TSource> Distinct<TSource>( 
            this IEnumerable<TSource> source, 
            IEqualityComparer<TSource> comparer = null)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            comparer = comparer ?? EqualityComparer<TSource>.Default;

            return DistinctImpl(source, comparer);
        }

         private static IEnumerable<TSource> DistinctImpl<TSource>( 
            this IEnumerable<TSource> source, 
            IEqualityComparer<TSource> comparer = null)
         {
             var hashSet = new HashSet<TSource>(comparer);

             foreach(var item in source)
             {
                 if (hashSet.Add(item))
                 {
                     yield return item;
                 }
             }
         }
    }
}
