using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Edulinq
{
    public static partial class Enumerable
    {
        public static IEnumerable<TSource> Take<TSource>(
            this IEnumerable<TSource> source,
            int count)
        {
            return TakeWhile(source, (source1, i) => i < count);
        }

        public static IEnumerable<TSource> TakeWhile<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException("predicate");
            return TakeWhile(source, (source1, i) => predicate(source1));
        }

        public static IEnumerable<TSource> TakeWhile<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, int, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if(predicate == null)
                throw new ArgumentNullException("predicate");

            return TakeWhileImpl(source, predicate);
        }

        private static IEnumerable<TSource> TakeWhileImpl<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, int, bool> predicate)
        {
            int i = 0;

            using (var enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (predicate(enumerator.Current, i))
                    {
                        yield return enumerator.Current;
                    }
                    else
                    {
                        break;
                    }
                    i++;
                }
            }
        }
    }
}
