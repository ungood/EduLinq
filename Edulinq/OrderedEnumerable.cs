using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Edulinq
{
    public class OrderedEnumerable<T> : IOrderedEnumerable<T>
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
            var projectionComparer = new ProjectionComparer<T, TKey>(keySelector, comparer);
            if (descending)
            {
                var reverseComparer = new ReverseComparer<T>(projectionComparer);
                var compoundComparer = new CompoundComparer<T>(currentComparer, reverseComparer);
                return new OrderedEnumerable<T>(source, compoundComparer);
            }
            else
            {
                var compoundComparer = new CompoundComparer<T>(currentComparer, projectionComparer);
                return new OrderedEnumerable<T>(source, compoundComparer);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            // This is a truly sucky way of implementing it. It's the simplest I could think of to start with. 
            // We'll come back to it! 
            List<T> elements = source.ToList();
            while (elements.Count > 0)
            {
                T minElement = elements[0];
                int minIndex = 0;
                for (int i = 1; i < elements.Count; i++)
                {
                    if (currentComparer.Compare(elements[i], minElement) < 0)
                    {
                        minElement = elements[i];
                        minIndex = i;
                    }
                }
                elements.RemoveAt(minIndex);
                yield return minElement;
            } 
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
