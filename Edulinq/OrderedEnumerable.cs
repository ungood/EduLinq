using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Edulinq
{
    internal class OrderedEnumerable<T> : IOrderedEnumerable<T>
    {
        private readonly IEnumerable<T> source;
        private readonly IComparer<T> currentComparer;

        public OrderedEnumerable(IEnumerable<T> source, IComparer<T> comparer)
        {
            this.source = source;
            currentComparer = comparer;
        }

        public IOrderedEnumerable<T> CreateOrderedEnumerable<TKey>(
            Func<T, TKey> keySelector,
            IComparer<TKey> comparer,
            bool descending)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
