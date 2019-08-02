using NUnit.Framework;
using Service.Models.Parts;
using System;

namespace Tests
{
    [TestFixture]
    public class PartTests
    {
        LaptopPart laptopPart;

        [SetUp]
        public void Setup()
        {
            laptopPart = new LaptopPart("mouse", 2.3m, false);
        }

        [Test]
        public void Part_Constructor_Should_Works_Correctly()
        {
            Assert.AreEqual("mouse", laptopPart.Name);
            Assert.AreEqual(3.45m, laptopPart.Cost);
            Assert.AreEqual(false, laptopPart.IsBroken);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void Name_Property_Should_Throws_Exception(string value)
        {
            Assert.Throws<ArgumentException>(() => laptopPart = new LaptopPart(value, 2.3m, false));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-3)]
        public void Cost_Property_Should_Throws_Exception(decimal value)
        {
            Assert.Throws<ArgumentException>(() => laptopPart = new LaptopPart("mouse", value, false));
        }
    }
}