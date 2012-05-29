using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Edulinq
{
    public static partial class Enumerable
    {
        public static TAccumulate Aggregate<TSource, TAccumulate>(
            this IEnumerable<TSource> source,
            TAccumulate seed,
            Func<TAccumulate, TSource, TAccumulate> func)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (func == null)
                throw new ArgumentNullException("func");
            
            var current = seed;

            foreach (var item in source)
            {
                current = func(current, item);
            }

            return current;
        }

        public static TResult Aggregate<TSource, TAccumulate, TResult>(
            this IEnumerable<TSource> source,
            TAccumulate seed,
            Func<TAccumulate, TSource, TAccumulate> func,
            Func<TAccumulate, TResult> resultSelector)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (func == null)
                throw new ArgumentNullException("func");
            if (resultSelector == null)
                throw new ArgumentNullException("resultSelector");

            return resultSelector(Aggregate(source, seed, func));
        }

        public static TSource Aggregate<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, TSource, TSource> func)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (func == null)
                throw new ArgumentNullException("func");

            using(var enumerator = source.GetEnumerator())
            {
                if(!enumerator.MoveNext())
                    throw new InvalidOperationException("Empty sequence");

                var accumulator = enumerator.Current;
                while (enumerator.MoveNext())
                    accumulator = func(accumulator, enumerator.Current);
                return accumulator;
            }

            //var current = source.First();

            //foreach(var item in source)
            //{
            //    current = func(current, item);
            //}

            //return current;
        }
    }
}
