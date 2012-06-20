using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Edulinq.UnitTests
{
    [TestFixture]
    public class ComparerTests
    {
        private readonly IComparer<string> firstLetter = new ProjectionComparer<string, char>(x => x[0], Comparer<char>.Default);
        private readonly IComparer<string> length = new ProjectionComparer<string, int>(x => x.Length, Comparer<int>.Default);
        
        private void LessThan(IComparer<string> comparer, string left, string right)
        {
            Assert.Less(comparer.Compare(left, right), 0);
        }

        private void GreaterThan(IComparer<string> comparer, string left, string right)
        {
            Assert.Greater(comparer.Compare(left, right), 0);
        }

        private void EqualTo(IComparer<string> comparer, string left, string right)
        {
            Assert.AreEqual(0, comparer.Compare(left, right));
        }

        [Test]
        public void ProjectionComparerTest()
        {
            LessThan(length, "apple", "banana");
            GreaterThan(length, "banana", "apple");
            EqualTo(length, "pear", "dart");

            LessThan(firstLetter,"apple", "banana");
            GreaterThan(firstLetter,"banana", "apple");
            EqualTo(firstLetter,"pear", "pineapple");
        }

        [Test]
        public void ReverseComparerTest()
        {
            var reverse = new ReverseComparer<string>(firstLetter);

            GreaterThan(reverse,"apple", "banana");
            LessThan( reverse,"banana", "apple");
            EqualTo(reverse,"pear", "pineapple");
        }

        [Test]
        public void CompoundComparerTest()
        {
            var comparer = new CompoundComparer<string>(firstLetter, length);

            LessThan(comparer,"appletree", "banana");
            GreaterThan(comparer,"banana", "appletree");
            LessThan(comparer,"pear", "pineapple");
            GreaterThan(comparer,"pineapple", "pear");
            EqualTo(comparer,"pear", "plum");
        }
    }
}
