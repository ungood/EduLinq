using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Edulinq.UnitTests
{
    using System.Linq;

    [TestFixture]
    public class ModifiedClosureTests
    {
        [Test]
        public void AccessToModifiedClosure()
        {
            var source = Enumerable.Range(1, 10);
            var multiplesOf = new List<IEnumerable<int>>();
            
            // 0 has no multiples.
            multiplesOf.Add(Enumerable.Empty<int>());

            // Find all values in source that are divisible by 1, 2, ..., 5
            foreach(var divisor in Enumerable.Range(1, 5))
            {
                multiplesOf.Add(source.Where(value => value % divisor == 0));
            }

            // What I expect
            // multiplesOf[0].AssertSequenceEqual();
            // multiplesOf[1].AssertSequenceEqual(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            // multiplesOf[2].AssertSequenceEqual(2, 4, 6, 8, 10);
            // multiplesOf[3].AssertSequenceEqual(3, 6, 9);
            // multiplesOf[4].AssertSequenceEqual(4, 8);
            // multiplesOf[5].AssertSequenceEqual(5, 10);

            // What is true
            multiplesOf[0].AssertSequenceEqual();
            multiplesOf[1].AssertSequenceEqual(5, 10);
            multiplesOf[2].AssertSequenceEqual(5, 10);
            multiplesOf[3].AssertSequenceEqual(5, 10);
            multiplesOf[4].AssertSequenceEqual(5, 10);
            multiplesOf[5].AssertSequenceEqual(5, 10);

            // HUH WHA?!
        }

        [Test]
        public void AccessToCopiedEnumeratorCurrent()
        {
            var source = Enumerable.Range(1, 10);
            var multiplesOf = new List<IEnumerable<int>>();
            
            // 0 has no multiples.
            multiplesOf.Add(Enumerable.Empty<int>());

            // Find all values in source that are divisible by 1, 2, ..., 5
            foreach(var divisor in Enumerable.Range(1, 5))
            {
                var localDivisor = divisor;
                multiplesOf.Add(source.Where(value => value % localDivisor == 0));
            }

            multiplesOf[0].AssertSequenceEqual();
            multiplesOf[1].AssertSequenceEqual(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            multiplesOf[2].AssertSequenceEqual(2, 4, 6, 8, 10);
            multiplesOf[3].AssertSequenceEqual(3, 6, 9);
            multiplesOf[4].AssertSequenceEqual(4, 8);
            multiplesOf[5].AssertSequenceEqual(5, 10);
        }

        [Test]
        public void AccessToModifiedClosureExecuteImmediate()
        {
            var source = Enumerable.Range(1, 10);
            var multiplesOf = new List<IEnumerable<int>>();
            
            // 0 has no multiples.
            multiplesOf.Add(Enumerable.Empty<int>());

            // Find all values in source that are divisible by 1, 2, ..., 5
            foreach(var divisor in Enumerable.Range(1, 5))
            {
                multiplesOf.Add(source.Where(value => value % divisor == 0).ToList());
            }

            multiplesOf[0].AssertSequenceEqual();
            multiplesOf[1].AssertSequenceEqual(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            multiplesOf[2].AssertSequenceEqual(2, 4, 6, 8, 10);
            multiplesOf[3].AssertSequenceEqual(3, 6, 9);
            multiplesOf[4].AssertSequenceEqual(4, 8);
            multiplesOf[5].AssertSequenceEqual(5, 10);
        }
    }
}
