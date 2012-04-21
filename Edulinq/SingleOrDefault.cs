using System;
using System.Collections.Generic;
using System.Text;

namespace Edulinq
{
    public static partial class Enumerable
    {
        public static TSource SingleOrDefault<TSource>(
            this IEnumerable<TSource> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            var enumerator = source.GetEnumerator();
            if(!enumerator.MoveNext())
            {
                return default(TSource);
            }

            var firstItem = enumerator.Current;
            if(enumerator.MoveNext())
            {
                throw new InvalidOperationException("More than one element found.");
            }
            return firstItem;
        }

        public static TSource SingleOrDefault<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (predicate == null)
                throw new ArgumentNullException("predicate");


            //return source.Where(predicate).SingleOrDefault();
            var enumerator = source.GetEnumerator();
            bool found = false;
            while(enumerator.MoveNext())
            {
                if(predicate(enumerator.Current))
                {
                    found = true;
                    break;
                }
            }

            if(!found)
            {
                return default(TSource);
            }

            var firstItem = enumerator.Current;
            
            while(enumerator.MoveNext())
            {
                if(predicate(enumerator.Current))
                    throw new InvalidOperationException("More than one element found.");
            }
            
            
            return firstItem;
        }
    }
}
