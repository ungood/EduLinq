using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Edulinq
{
    public static partial class Enumerable
    {
        public static IEnumerable<TSource> Distinct<TSource>( 
            this IEnumerable<TSource> source, 
            IEqualityComparer<TSource> comparer)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (comparer == null)
                throw new ArgumentNullException("comparer");

            comparer = comparer ?? EqualityComparer<TSource>.Default;

            throw new NotImplementedException();
        }
    }
}
