using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Edulinq.UnitTests
{
    [TestFixture]
    public class RepeatTest
    {
        [Test]
        public void SimpleRepeat()
        {
            Enumerable.Repeat("foo", 3).AssertSequenceEqual("foo", "foo", "foo");
        }

        [Test]
        public void EmptyRepeat()
        {
            Enumerable.Repeat("foo", 0).AssertSequenceEqual();
        }

        [Test]
        public void NullElement()
        {
            Enumerable.Repeat<string>(null, 2).AssertSequenceEqual(null, null);
        }

        [Test]
        public void NegativeCount()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Enumerable.Repeat("foo", -1));
        }

        [Test]
        public void RepeatIsDeferred()
        {
            Enumerable.Repeat(0, int.MaxValue);
            Assert.Pass(); // Assume it's alright if it doesn't throw an OutOfMemoryException
        }
    }
}
