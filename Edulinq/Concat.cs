using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Edulinq
{
    public partial class Enumerable
    {
        public static IEnumerable<TSource> Concat<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second)
        {
            if (first == null)
                throw new ArgumentNullException("first");
            if (second == null)
                throw new ArgumentNullException("second");

            return ConcatImp(first, second);
        }
        private static IEnumerable<TSource> ConcatImp<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second)
        {
            foreach(var source in first)
            {
                yield return source;
            }
            foreach(var source in second)
            {
                yield return source;
            }
        }
    }
}
