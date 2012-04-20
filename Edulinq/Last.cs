using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Edulinq
{
    public static partial class Enumerable
    {
        public static TSource Last<TSource>(
            this IEnumerable<TSource> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            TSource lastItem = default(TSource);
            bool found = false;    
            foreach(var item in source)
            {
                lastItem = item;
                found = true;
            }

            if (!found)
            {
                throw new InvalidOperationException("asdf");
            }

            return lastItem;
        }

        public static TSource Last<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (predicate == null)
                throw new ArgumentNullException("predicate");

            throw new NotImplementedException();
        }
    }
}
