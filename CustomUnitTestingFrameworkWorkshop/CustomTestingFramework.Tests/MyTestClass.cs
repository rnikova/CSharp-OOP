using System;

using CustomTestingFramework.Asserts;
using CustomTestingFramework.Attributes;

namespace CustomTestingFramework.Tests
{
    [TestClass]
    public class MyTestClass
    {
        [TestMethod]
        public void ShouldSumValues()
        {
            int a = 2;
            int b = 3;

            int actualSum = a + b;
            int expectedSum = 5;

            Assert.AreEqual(actualSum, expectedSum);
        }

        [TestMethod]
        public void ShouldSumValues2()
        {
            int a = 2;
            int b = 3;

            int actualSum = a + b;
            int expectedSum = 6;

            Assert.AreNotEqual(actualSum, expectedSum);
        }

        [TestMethod]
        public void ShouldSumValues3()
        {
            var a = new string[5];

            Assert.Throws<IndexOutOfRangeException>(() => a[12] == "lalala");
        }
    }
}
