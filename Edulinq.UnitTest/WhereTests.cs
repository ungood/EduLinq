using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Edulinq.UnitTests
{
    [TestFixture]
    public class WhereTests
    {
        #region Argument Checking

        [Test]
        public void NullSourceThrowsNullArgumentException()
        {
            IEnumerable<int> source = null;
            Assert.Throws<ArgumentNullException>(() => source.Where(x => x % 2 == 0));
        }

        [Test]
        public void NullPredicateThrowsNullArgumentException()
        {
            var source = new[] {1, 2, 3, 4, 5};
            Func<int, bool> predicate = null;
            Assert.Throws<ArgumentNullException>(() => source.Where(predicate));
        }

        [Test]
        public void WithIndexNullSourceThrowsNullArgumentException()
        {
            IEnumerable<int> source = null;
            Assert.Throws<ArgumentNullException>(() => source.Where((x, index) => x > 5));
        }

        [Test]
        public void WithIndexNullPredicateThrowsNullArgumentException()
        {
            int[] source = { 1, 3, 7, 9, 10 };
            Func<int, int, bool> predicate = null;
            Assert.Throws<ArgumentNullException>(() => source.Where(predicate));
        }

        #endregion

        [Test]
        public void SimpleFiltering()
        {
            var source = new[] {1, 2, 3, 4, 5};
            var result = source.Where(x => x % 2 == 0);
            result.AssertSequenceEqual(2, 4);
        }

        [Test]
        public void SimpleFilteringWithQueryExpression()
        {
            var source = new[] {1, 2, 3, 4, 5};
            var result = (from p in source where p % 2 == 0 select p);
            result.AssertSequenceEqual(2, 4);
        }

        [Test]
        public void EmptySource()
        {
            IEnumerable<int> source = new List<int>();
            var result = source.Where(x => true);
            result.AssertSequenceEqual();
        }

        [Test]
        public void ExecutionIsDeferred()
        {
            ThrowingEnumerable.AssertDeferred(src => src.Where(x => true));
        }

        #region With Index

        [Test]
        public void WithIndexSimpleFiltering()
        {
            int[] source = { 1, 3, 4, 2, 8, 1 };
            var result = source.Where((x, index) => x < index);
            result.AssertSequenceEqual(2, 1);
        }

        [Test]
        public void WithIndexEmptySource()
        {
            int[] source = new int[0];
            var result = source.Where((x, index) => x < 4);
            result.AssertSequenceEqual();
        }

        [Test]
        public void WithIndexExecutionIsDeferred()
        {
            ThrowingEnumerable.AssertDeferred(src => src.Where((x, index) => x > 0));
        }

        #endregion
    }
}
