using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using NUnit.Framework;

namespace Edulinq.UnitTests
{
    [TestFixture]
    public class NullComparisonTests
    {
        private static class NullComparer
        {
            public static bool WithEqualityOperator<T>(T item)
            {
                return item == null;
            }

            public static bool WithInequalityOperator<T>(T item)
            {
                return !(item != null);
            } 

            public static bool WithEqualsMethod<T>(T item)
            {
                return item.Equals(null);
            }

            public static bool WithDefaultEqualityComparer<T>(T item)
                where T : class
            {
                return EqualityComparer<T>.Default.Equals(item, null);
            }

            /// <summary>
            /// Sneakily force a null into the int equality comparer... This fails for reasons unknown.
            /// </summary>
            public static bool WithDefaultEqualityComparerByReflection<T>(T item)
            {
                var comparerType = typeof(EqualityComparer<T>);
                var defaultComparerPi = comparerType.GetProperty("Default");
                var defaultComparer = defaultComparerPi.GetValue(null, null);
                var equalsMethod = comparerType.GetMethod("Equals", BindingFlags.Public | BindingFlags.Instance, null, new[] {typeof(T), typeof(T)}, null);
                return (bool)equalsMethod.Invoke(defaultComparer, new object[] {item, null});
            }
        }

        [Test]
        public void CompareValueTypeToNull()
        {
            Assert.IsFalse(NullComparer.WithEqualityOperator(0));
            Assert.IsFalse(NullComparer.WithInequalityOperator(0));
            Assert.IsFalse(NullComparer.WithEqualsMethod(0));
            
            // This wont work because int is not a reference type:
            // Assert.IsFalse(NullComparer.WithDefaultEqualityComparer(0));
            
            // I would expect this to be false... but it is not.
            //Assert.IsFalse(NullComparer.WithDefaultEqualityComparerByReflection(0));
        }

        private class Widget {}

        [Test]
        public void CompareNullReferenceTypeToNull()
        {
            Widget nullWidget = null;
            
            Assert.IsTrue(NullComparer.WithDefaultEqualityComparer(nullWidget));
            Assert.IsTrue(NullComparer.WithInequalityOperator(nullWidget));
            // Not good to call Equals on a null reference...
            Assert.Throws<NullReferenceException>(() => NullComparer.WithEqualsMethod(nullWidget));
            Assert.IsTrue(NullComparer.WithDefaultEqualityComparer(nullWidget));
            Assert.IsTrue(NullComparer.WithDefaultEqualityComparerByReflection(nullWidget));
        }


        [Test]
        public void CompareReferenceTypeToNull()
        {
            var widget = new Widget();
            Assert.IsFalse(NullComparer.WithDefaultEqualityComparer(widget));
            Assert.IsFalse(NullComparer.WithInequalityOperator(widget));
            Assert.IsFalse(NullComparer.WithEqualsMethod(widget));
            Assert.IsFalse(NullComparer.WithDefaultEqualityComparer(widget));
            Assert.IsFalse(NullComparer.WithDefaultEqualityComparerByReflection(widget));
        }
    }
}
