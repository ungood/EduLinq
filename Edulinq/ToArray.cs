using System;
using System.Collections.Generic;

namespace Edulinq
{
    public static partial class Enumerable
    {
        public static TSource[] ToArray<TSource>(
            this IEnumerable<TSource> source)
        {
            if(source == null)
                throw new ArgumentNullException("source");

            return new List<TSource>(source).ToArray();
        } 
    }
}
