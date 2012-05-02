using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Edulinq
{
    internal sealed class Grouping<TKey, TElement> : IGrouping<TKey, TElement>, ICollection<TElement>
    {
        private readonly TKey key;
        private readonly IList<TElement> elements;

        internal Grouping(TKey key)
        {
            this.key = key;
            elements = new List<TElement>();
        }

        internal void AddInternal(TElement element)
        {
            elements.Add(element);
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
            elements.CopyTo(array, arrayIndex);
        }

        public bool Remove(TElement item)
        {
            throw new InvalidOperationException("Grouping is immutable.");
        }

        public int Count
        {
            get { return elements.Count; }
        }

        public bool IsReadOnly
        {
            get { return true; }
        }

        #endregion
    }
}
