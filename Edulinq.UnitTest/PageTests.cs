using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Edulinq.UnitTests
{
    [TestFixture]
    public class PageTests
    {
        [Test]
        public void SimpleTest()
        {
            var source = new[] {1, 2, 3, 4, 5, 6, 7};
            
            source.Page(0, 2).AssertSequenceEqual(1, 2);
            source.Page(1, 2).AssertSequenceEqual(3, 4);
            source.Page(2, 2).AssertSequenceEqual(5, 6);
            source.Page(3, 2).AssertSequenceEqual(7);
            source.Page(4, 2).AssertSequenceEqual();
        }
    }
}
