using System;
using NUnit.Framework;

namespace Edulinq.UnitTests
{
    [TestFixture]
    public class GroupJoinTests
    {
        [Test]
        public void SimpleGroupJoin()
        {
            var outer = new[] { "paul", "adam", "alex", "victor" };
            var inner = new[] { "apple", "banana", "orange", "pineapple", "pear" };

            var result = outer.GroupJoin(inner,
                person => person[0],
                fruit => fruit[0],
                (person, fruits) => person + ":" + string.Join(",", fruits));
            result.AssertSequenceEqual("paul:pineapple,pear", "adam:apple", "alex:apple", "victor:");
        }

        [Test]
        public void ExecutionIsDeferred()
        {
            var outer = new ThrowingEnumerable();
            var inner = new ThrowingEnumerable();
            outer.GroupJoin(inner, x => x, y => y, (x, y) => x + y.Count());
        }

        
        [Test]
        public void CustomComparer()
        {
            // We're going to match the start of the outer sequence item
            // with the end of the inner sequence item, in a case-insensitive manner
            string[] outer = { "ABCxxx", "abcyyy", "defzzz", "ghizzz" };
            string[] inner = { "000abc", "111gHi", "222333", "333AbC" };

            var query = outer.GroupJoin(inner,
                                   outerElement => outerElement.Substring(0, 3),
                                   innerElement => innerElement.Substring(3),
                                   (outerElement, innerElements) => outerElement + ":" + StringEx.Join(";", innerElements),
                                   StringComparer.OrdinalIgnoreCase);
            // ABCxxx matches 000abc and 333AbC
            // abcyyy matches 000abc and 333AbC
            // defzzz doesn't match anything
            // ghizzz matches 111gHi
            query.AssertSequenceEqual("ABCxxx:000abc;333AbC", "abcyyy:000abc;333AbC", "defzzz:", "ghizzz:111gHi");
        }

        [Test]
        public void DifferentSourceTypes()
        {
            int[] outer = { 5, 3, 7, 4 };
            string[] inner = { "bee", "giraffe", "tiger", "badger", "ox", "cat", "dog" };

            var query = outer.GroupJoin(inner,
                                   outerElement => outerElement,
                                   innerElement => innerElement.Length,
                                   (outerElement, innerElements) => outerElement + ":" + StringEx.Join(";", innerElements));
            query.AssertSequenceEqual("5:tiger", "3:bee;cat;dog", "7:giraffe", "4:");
        }

        // Note that LINQ to Objects ignores null keys for Join and GroupJoin
        [Test]
        public void NullKeys()
        {
            string[] outer = { "first", null, "second" };
            string[] inner = { "first", "null", "nothing" };
            var query = outer.GroupJoin(inner,
                                   outerElement => outerElement,
                                   innerElement => innerElement.StartsWith("n") ? null : innerElement,
                                   (outerElement, innerElements) => outerElement + ":" + StringEx.Join(";", innerElements));
            // No matches for the null outer key
            query.AssertSequenceEqual("first:first", ":", "second:");
        }
    }
}
