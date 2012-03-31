using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Edulinq.UnitTests
{
    [TestFixture]
    public class SelectTests
    {
        #region Argument Checking

        [Test]
        public void NullSourceThrowsNullArgumentException()
        {
            IEnumerable<int> source = null;
            Assert.Throws<ArgumentNullException>(() => source.Select(x => x + 1));
        }

        [Test]
        public void NullProjectionThrowsNullArgumentException()
        {
            int[] source = { 1, 3, 7, 9, 10 };
            Func<int, int> projection = null;
            Assert.Throws<ArgumentNullException>(() => source.Select(projection));
        }

        [Test]
        public void WithIndexNullSourceThrowsNullArgumentException()
        {
            IEnumerable<int> source = null;
            Assert.Throws<ArgumentNullException>(() => source.Select((x, index) => x + index));
        }

        [Test]
        public void WithIndexNullPredicateThrowsNullArgumentException()
        {
            int[] source = { 1, 3, 7, 9, 10 };
            Func<int, int, int> projection = null;
            Assert.Throws<ArgumentNullException>(() => source.Select(projection));
        }

        #endregion

        [Test]
        public void SimpleProjection()
        {
            Assert.Fail();
        }

        [Test]
        public void SimpleProjectionWithQueryExpression()
        {
            Assert.Fail();
        }

        [Test]
        public void SimpleProjectionToDifferentType()
        {
            Assert.Fail();
        }

        [Test]
        public void EmptySource()
        {
            Assert.Fail();
        }

        [Test]
        public void ExecutionIsDeferred()
        {
            ThrowingEnumerable.AssertDeferred(src => src.Select(x => x * 2));
        }

        [Test]
        public void SideEffectsInProjection()
        {
            int[] source = new int[3]; // Actual values won't be relevant
            int count = 0;
            var query = source.Select(x => count++);
            query.AssertSequenceEqual(0, 1, 2);
            query.AssertSequenceEqual(3, 4, 5);
            count = 10;
            query.AssertSequenceEqual(10, 11, 12);
        }

        #region With Index

        [Test]
        public void WithIndexSimpleProjection()
        {
            int[] source = { 1, 5, 2 };
            var result = source.Select((x, index) => x + index * 10);
            result.AssertSequenceEqual(1, 15, 22);
        }

        [Test]
        public void WithIndexEmptySource()
        {
            int[] source = new int[0];
            var result = source.Select((x, index) => x + index);
            result.AssertSequenceEqual();
        }

        [Test]
        public void WithIndexExecutionIsDeferred()
        {
            ThrowingEnumerable.AssertDeferred(src => src.Select((x, index) => x + index));
        }

        #endregion
    }
}
