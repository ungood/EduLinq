using System;
using System.Collections.Generic;

namespace Edulinq
{
    public class ProjectionComparer<T, TKey> : IComparer<T>
    {
        private readonly Func<T, TKey> selector;
        private readonly IComparer<TKey> comparer;

        public ProjectionComparer(Func<T, TKey> selector, IComparer<TKey> comparer)
        {
            this.selector = selector;
            this.comparer = comparer;
        }

        public int Compare(T x, T y)
        {
            return comparer.Compare(selector(x), selector(y));
        }
    }

    public class ReverseComparer<T> : IComparer<T>
    {
        private readonly IComparer<T> forwardComparer;

        public ReverseComparer(IComparer<T> forwardComparer)
        {
            this.forwardComparer = forwardComparer;
        }

        public int Compare(T x, T y)
        {
            return forwardComparer.Compare(y, x);
        }
    }

    public class CompoundComparer<T> : IComparer<T>
    {
        private readonly IComparer<T> firstComparer;
        private readonly IComparer<T> secondComparer;

        public CompoundComparer(IComparer<T> firstComparer, IComparer<T> secondComparer)
        {
            this.firstComparer = firstComparer;
            this.secondComparer = secondComparer;
        }

        public int Compare(T x, T y)
        {
            var result = firstComparer.Compare(x, y);
            if (result == 0)
                result = secondComparer.Compare(x, y);

            return result;
        }
    }
}
