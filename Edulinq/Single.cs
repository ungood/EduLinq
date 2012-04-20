using System;
using System.Collections.Generic;
using System.Text;

namespace Edulinq
{
    public static partial class Enumerable
    {
        public static TSource Single<TSource>(
            this IEnumerable<TSource> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            var enumerator = source.GetEnumerator();
            if(!enumerator.MoveNext())
            {
                throw new InvalidOperationException("No elements in sequence");                
            }
            var firstItem = enumerator.Current;
            if(enumerator.MoveNext())
            {
                throw new InvalidOperationException("More than one element in sequence");                
            }
            return firstItem;
        }

        public static TSource Single<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (predicate == null)
                throw new ArgumentNullException("predicate");

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

            var firstItem = enumerator.Current;
            
            while(enumerator.MoveNext())
            {
                if(predicate(enumerator.Current))
                    throw new InvalidOperationException("More than one matching element in sequence");                
            }
            
            if(!found)
            {
                throw new InvalidOperationException("No items found in sequence.");
            }
            return firstItem;
        }

    }
}
