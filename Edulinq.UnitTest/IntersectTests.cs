﻿using System;
using NUnit.Framework;

namespace Edulinq.UnitTests
{
    [TestFixture]
    public class IntersectTests
    {
        [Test]
        public void SimpleIntersect()
        {
            var first = new[] {1, 2, 3, 4, 4};
            var second = new[] {3, 4, 4, 5, 6};

            var intersect = first.Intersect(second);
            intersect.AssertSequenceEqual(3, 4);
        }

        [Test]
        public void NullFirstWithoutComparer()
        {
            string[] first = null;
            string[] second = { };
            Assert.Throws<ArgumentNullException>(() => first.Intersect(second));
        }

        [Test]
        public void NullSecondWithoutComparer()
        {
            string[] first = { };
            string[] second = null;
            Assert.Throws<ArgumentNullException>(() => first.Intersect(second));
        }

        [Test]
        public void NullFirstWithComparer()
        {
            string[] first = null;
            string[] second = { };
            Assert.Throws<ArgumentNullException>(() => first.Intersect(second, StringComparer.Ordinal));
        }

        [Test]
        public void NullSecondWithComparer()
        {
            string[] first = { };
            string[] second = null;
            Assert.Throws<ArgumentNullException>(() => first.Intersect(second, StringComparer.Ordinal));
        }

        [Test]
        public void NoComparerSpecified()
        {
            string[] first = { "A", "a", "b", "c", "b" };
            string[] second = { "b", "a", "d", "a" };
            first.Intersect(second).AssertSequenceEqual("a", "b");
        }

        [Test]
        public void NullComparerSpecified()
        {
            string[] first = { "A", "a", "b", "c", "b" };
            string[] second = { "b", "a", "d", "a" };
            first.Intersect(second, null).AssertSequenceEqual("a", "b");
        }

        [Test]
        public void CaseInsensitiveComparerSpecified()
        {
            string[] first = { "A", "a", "b", "c", "b" };
            string[] second = { "b", "a", "d", "a" };
            first.Intersect(second, StringComparer.OrdinalIgnoreCase).AssertSequenceEqual("A", "b");
        }

        [Test]
        public void NoSequencesUsedBeforeIteration()
        {
            var first = new ThrowingEnumerable();
            var second = new ThrowingEnumerable();
            // No exceptions!
            var query = first.Union(second);
            // Still no exceptions... we're not calling MoveNext.
            using (var iterator = query.GetEnumerator())
            {
            }
        }

        [Test]
        public void SecondSequenceReadFullyOnFirstResultIteration()
        {
            int[] first = { 1 };
            var secondQuery = new[] { 10, 2, 0 }.Select(x => 10 / x);

            var query = first.Intersect(secondQuery);
            using (var iterator = query.GetEnumerator())
            {
                Assert.Throws<DivideByZeroException>(() => iterator.MoveNext());
            }
        }

        [Test]
        public void FirstSequenceOnlyReadAsResultsAreRead()
        {
            var firstQuery = new[] { 10, 2, 0, 2 }.Select(x => 10 / x);
            int[] second = { 1 };

            var query = firstQuery.Intersect(second);
            using (var iterator = query.GetEnumerator())
            {
                // We can get the first value with no problems
                Assert.IsTrue(iterator.MoveNext());
                Assert.AreEqual(1, iterator.Current);

                // Getting at the *second* value of the result sequence requires
                // reading from the first input sequence until the "bad" division
                Assert.Throws<DivideByZeroException>(() => iterator.MoveNext());
            }
        }
    }
}
