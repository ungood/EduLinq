using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Edulinq.Collections
{
    internal sealed class Lookup<TKey, TElement> : ILookup<TKey, TElement>
    {
        private Lookup(IEqualityComparer<TKey> comparer)
        {
            
        }

        #region Implementation of ILookup<TKey, TElement>

        public IEnumerator<IGrouping<TKey, TElement>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool Contains(TKey key)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable<TElement> this[TKey key]
        {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }
}
