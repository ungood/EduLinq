using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Edulinq.Collections
{
    internal sealed class Grouping<TKey, TElement> : IGrouping<TKey, TElement>, ICollection<TElement>
    {
        private readonly TKey key;
        private readonly TElement[] elements;

        internal Grouping(TKey key, IEnumerable<TElement> elements)
        {
            this.key = key;
            this.elements = elements.ToArray();
        }

        #region Implementation of IGrouping<TKey, TElement>

        public TKey Key
        {
            get { return key; }
        }

        public IEnumerator<TElement> GetEnumerator()
        {
            return ((IEnumerable<TElement>)elements).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region Implementation of ICollection<TElement>

        public void Add(TElement item)
        {
            throw new InvalidOperationException("Grouping is immutable.");
        }

        public void Clear()
        {
            throw new InvalidOperationException("Grouping is immutable.");
        }

        public bool Contains(TElement item)
        {
            throw new InvalidOperationException("Grouping is immutable.");
        }

        public void CopyTo(TElement[] array, int arrayIndex)
        {
            Array.Copy(elements, 0, array, arrayIndex, elements.Length);
        }

        public bool Remove(TElement item)
        {
            throw new InvalidOperationException("Grouping is immutable.");
        }

        public int Count
        {
            get { return elements.Length; }
        }

        public bool IsReadOnly
        {
            get { return true; }
        }

        #endregion
    }
}
