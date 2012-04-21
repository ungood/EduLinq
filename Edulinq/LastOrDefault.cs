using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Edulinq
{
    public static partial class Enumerable
    {
        public static TSource LastOrDefault<TSource>(
            this IEnumerable<TSource> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            var list = source as IList<TSource>;
            if(list != null)
            {
                return list.Count == 0 ? default(TSource) : list[list.Count - 1];
            }

            TSource lastItem = default(TSource);
            bool found = false;    
            foreach(var item in source)
            {
                lastItem = item;
                found = true;
            }

            return found ? lastItem : default(TSource);
        }

        public static TSource LastOrDefault<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (predicate == null)
                throw new ArgumentNullException("predicate");

            TSource lastItem = default(TSource);
            bool found = false;    
            foreach(var item in source)
            {
                if(predicate(item))
                {
                    lastItem = item;
                    found = true;
                }
            }

            return found ? lastItem : default(TSource);
        }
    }
}
