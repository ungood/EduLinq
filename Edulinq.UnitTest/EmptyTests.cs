using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Edulinq.UnitTests
{
    [TestFixture]
    public class EmptyTest
    {
        [Test]
        public void EmptyContainsNoElements()
        {
            using (var empty = Enumerable.Empty<int>().GetEnumerator())
            {
                Assert.IsFalse(empty.MoveNext());
            }
        }

        [Test]
        public void EmptyIsASingletonPerElementType()
        {
            Assert.AreSame(Enumerable.Empty<int>(), Enumerable.Empty<int>());
            Assert.AreSame(Enumerable.Empty<long>(), Enumerable.Empty<long>());
            Assert.AreSame(Enumerable.Empty<string>(), Enumerable.Empty<string>());
            Assert.AreSame(Enumerable.Empty<object>(), Enumerable.Empty<object>());

            Assert.AreNotSame(Enumerable.Empty<long>(), Enumerable.Empty<int>());
            Assert.AreNotSame(Enumerable.Empty<string>(), Enumerable.Empty<object>());
        }

        [Test]
        public void EmptyIsImmutable()
        {
            var empty = Enumerable.Empty<int>();

            var collection = empty as ICollection<int>;
            if(collection == null)
                Assert.Pass(); // If it's not a collection, it's not a problem.

            // Adding elements to our empty enumerable would be... strange.
            Assert.Throws<NotSupportedException>(() => collection.Add(3));
        }
    }
}
