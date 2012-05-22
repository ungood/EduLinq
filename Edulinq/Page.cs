using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Edulinq
{
    public static partial class Enumerable
    {
        public static IEnumerable<TSource> Page<TSource>(
            this IEnumerable<TSource> source,
            int pageNumber,
            int pageSize)
        {
            if(source == null)
                throw new ArgumentNullException("source");

            throw new NotImplementedException();
        }
    }
}
