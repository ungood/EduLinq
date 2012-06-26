using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Edulinq
{
    public static partial class Enumerable
    {
        public static bool SequenceEqual<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer = null)
        {
            if(first == null)
                throw new ArgumentNullException("first");
            if(second == null)
                throw new ArgumentNullException("second");

            comparer = comparer ?? EqualityComparer<TSource>.Default;

            throw new NotImplementedException();
        }
    }
}
