using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Edulinq.UnitTests
{
    [TestFixture]
    public class OrderedEnumerableTests
    {
        [Test]
        public void GetEnumeratorShouldSortSource()
        {
            var source = new int[] {8, 4, 42, 23, 15, 16};
            var orderedEnumerable = new OrderedEnumerable<int>(source, Comparer<int>.Default);

            orderedEnumerable.AssertSequenceEqual(4, 8, 15, 16, 23, 42);
        }
    }
}
