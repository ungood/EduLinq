using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;
namespace Edulinq.UnitTests
{
    //using System.Linq;
    [TestFixture]
    public class SelectManyTests
    {
        // I'm bored of writing argument validation tests now.

        [Test]
        public void SimpleFlatten()
        {
            List<string> Test = new List<string>();
            Test.Add("Howdy");
            Test.Add("Pal");
            var result = Test.SelectMany(x => x.ToCharArray());
            result.AssertSequenceEqual('H', 'o', 'w', 'd', 'y', 'P', 'a', 'l' );
        }

        [Test]
        public void FlattenWithProjection()
        {
            var source = new[] {"A,B,C", "Hello,World"};
            var result = source.SelectMany(x => x.Split(','), (original, split) => split.ToUpper());
            result.AssertSequenceEqual("A", "B", "C", "HELLO", "WORLD");
        }

        [Test]
        public void SimpleFlattenWithIndex()
        {
            int[] numbers = { 3, 5, 20, 15 };
            // The ToCharArray is unnecessary really, as string implements IEnumerable<char>
            var query = numbers.SelectMany((x, index) => (x + index).ToInvariantString().ToCharArray());
            // 3 => '3'
            // 5 => '6'
            // 20 => '2', '2'
            // 15 => '1', '8'
            query.AssertSequenceEqual('3', '6', '2', '2', '1', '8');
        }

        [Test]
        public void FlattenWithProjectionAndIndex()
        {
            int[] numbers = { 3, 5, 20, 15 };
            var query = numbers.SelectMany((x, index) => (x + index).ToInvariantString().ToCharArray(),
                                           (x, c) => x + ": " + c);
            // 3 => "3: 3"
            // 5 => "5: 6"
            // 20 => "20: 2", "20: 2"
            // 15 => "15: 1", "15: 8"
            query.AssertSequenceEqual("3: 3", "5: 6", "20: 2", "20: 2", "15: 1", "15: 8");
        }
    }
}
