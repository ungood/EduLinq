using NUnit.Framework;

namespace Edulinq.UnitTests
{
    [TestFixture]
    public class SelectManyTests
    {
        // I'm bored of writing argument validation tests now.

        [Test]
        public void SimpleFlatten()
        {
            Assert.Fail();
        }

        

        [Test]
        public void FlattenWithProjection()
        {
            Assert.Fail();
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
