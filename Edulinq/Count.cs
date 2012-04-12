using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Edulinq
{
    public static partial class Enumerable
    {
        public static int Count<TSource>(
            this IEnumerable<TSource> source)
        {
            if(source == null)
                throw new ArgumentNullException("source");
            
            var collection = source as ICollection<TSource>;
            if(collection != null)
                return collection.Count;

            var objectCollection = source as ICollection;
            if(objectCollection != null)
                return objectCollection.Count;

            int i = 0;

            foreach(var item in source)
            {
                i++;
            }
            return i;
        }

        public static int Count<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            if(source == null)
                throw new ArgumentNullException("source");
            if(predicate == null)
                throw new ArgumentNullException("predicate");

            int i = 0;

            foreach(var item in source)
            {
                if (predicate(item))
                {
                    i++;
                }
            }
            return i;
         }

        public static long LongCount<TSource>(
            this IEnumerable<TSource> source)
        {
            throw new NotImplementedException();
        }

        public static long LongCount<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
