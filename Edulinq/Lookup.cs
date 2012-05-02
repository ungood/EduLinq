using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Edulinq
{
    internal sealed class Lookup<TKey, TElement> : ILookup<TKey, TElement>
    {
        private readonly IList<Grouping<TKey, TElement>> groupings;
        private readonly IEqualityComparer<TKey> comparer;
        
        internal Lookup(IEqualityComparer<TKey> comparer)
        {
            groupings = new List<Grouping<TKey, TElement>>();
            this.comparer = comparer;
        }

        internal void Add(TKey key, TElement element)
        {
            var grouping = GetGrouping(key);

            if(grouping == null)
            {
                grouping = new Grouping<TKey, TElement>(key);
                groupings.Add(grouping);
            }
            
            grouping.AddInternal(element);
        }

        private Grouping<TKey, TElement> GetGrouping(TKey key)
        {
            return groupings.FirstOrDefault(group => comparer.Equals(group.Key, key));
        }

        #region Implementation of ILookup<TKey, TElement>

        public IEnumerator<IGrouping<TKey, TElement>> GetEnumerator()
        {
            return groupings.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool Contains(TKey key)
        {
            return groupings.Any(g => comparer.Equals(key, g.Key));
        }

        public int Count
        {
            get { return groupings.Count; }
        }

        public IEnumerable<TElement> this[TKey key]
        {
            get
            {
                var first = groupings.FirstOrDefault(g => comparer.Equals(g.Key, key));
                return first ?? Enumerable.Empty<TElement>();
            }
        }

        #endregion
    }
}
