﻿using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Edulinq.UnitTests
{
    using System.Linq;

    [TestFixture]
    public class AsEnumerableTests
    {
        [Test]
        public void NullSourceIsPermitted()
        {
            IEnumerable<string> source = null;
            Assert.IsNull(source.AsEnumerable());
        }

        [Test]
        public void DoesNotCallGetEnumerator()
        {
            var source = new ThrowingEnumerable();
            Assert.AreSame(source, source.AsEnumerable());
        }

        [Test]
        public void NormalSequence()
        {
            var range = Enumerable.Range(0, 10);
            Assert.AreSame(range, range.AsEnumerable());
        }

        [Test]
        public void AnonymousType()
        {
            var array = new[] {
                new {FirstName = "Jon", Surname = "Skeet"},
                new {FirstName = "Holly", Surname = "Skeet"}
            };

            // Can't create a List<T> because T is anonymous
            var list = array.ToList();

            // We can't cast to IEnumerable<T> as we can't express T.
            var sequence = list.AsEnumerable();
            // This will now use Enumerable.Contains instead of List.Contains
            Assert.IsFalse(sequence.Contains(new { FirstName = "Tom", Surname = "Skeet" }));
        }
    }
}
