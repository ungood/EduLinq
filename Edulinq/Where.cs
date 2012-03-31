using System;
using System.Collections;
using System.Collections.Generic;

namespace Edulinq
{
    public static partial class Enumerable
    {
        public static IEnumerable<TSource> Where<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            if (source == null) { throw new ArgumentNullException("source"); }
            if (predicate == null) { throw new ArgumentNullException("predicate"); }

            return new WhereEnumerable<TSource>(source, predicate);
        }

        private static IEnumerable<TSource> WhereImpl<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            foreach(var item in source)
            {
                if(predicate(item))
                    yield return item;
            }
        }

        public static IEnumerable<TSource> Where<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, int, bool> predicate)
        {
            if (source == null) { throw new ArgumentNullException("source"); }
            if (predicate == null) { throw new ArgumentNullException("predicate"); }

            return WhereImpl(source, predicate);
        }

        private static IEnumerable<TSource> WhereImpl<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, int, bool> predicate)
        {
            int index = 0;
            foreach(var item in source)
            {
                if(predicate(item, index++))
                    yield return item;
            }
        }


        private class WhereEnumerable<TSource> : IEnumerable<TSource>
        {
            private readonly IEnumerable<TSource> source;
            private readonly Func<TSource, bool> predicate;

            public WhereEnumerable(IEnumerable<TSource> source, Func<TSource, bool> predicate)
            {
                this.source = source;
                this.predicate = predicate;
            }

            public IEnumerator<TSource> GetEnumerator()
            {
                return new WhereEnumerator<TSource>(source, predicate);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        private class WhereEnumerator<TSource> : IEnumerator<TSource>
        {
            private readonly IEnumerable<TSource> source;
            private readonly Func<TSource, bool> predicate;

            public WhereEnumerator(IEnumerable<TSource> source, Func<TSource, bool> predicate)
            {
                this.source = source;
                this.predicate = predicate;
            }

            private IEnumerator<TSource> enumerator;
            private IEnumerator<TSource> Enumerator
            {
                get
                {
                    if(enumerator == null)
                        enumerator = source.GetEnumerator();
                    return enumerator;
                }
            }

            public void Dispose()
            {
                if(enumerator != null)
                    enumerator.Dispose();
            }

            public bool MoveNext()
            {
                while(Enumerator.MoveNext())
                {
                    if(predicate(Enumerator.Current))
                    {
                        Current = Enumerator.Current;
                        return true;
                    }
                }

                return false;
            }

            public void Reset()
            {
                Enumerator.Reset();
            }

            public TSource Current { get; private set; }

            object IEnumerator.Current
            {
                get { return Current; }
            }
        }
    }
}
