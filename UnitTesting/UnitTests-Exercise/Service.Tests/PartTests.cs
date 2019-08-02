using NUnit.Framework;
using Service.Models.Parts;
using System;

namespace Tests
{
    [TestFixture]
    public class PartTests
    {
        private LaptopPart laptopPart;
        private PCPart pcPart;

        [SetUp]
        public void Setup()
        {
            laptopPart = new LaptopPart("mouse", 2.3m, false);
            pcPart = new PCPart("mouse", 2.3m);
        }
        
        [Test]
        public void LaptopPart_Constructor_Should_Works_Correctly()
        {
            Assert.AreEqual("mouse", laptopPart.Name);
            Assert.AreEqual(3.45m, laptopPart.Cost);
            Assert.AreEqual(false, laptopPart.IsBroken);
        }

        [Test]
        public void PCPart_Constructor_Should_Works_Correctly()
        {
            Assert.AreEqual("mouse", pcPart.Name);
            Assert.AreEqual(2.76m, pcPart.Cost);
            Assert.AreEqual(false, pcPart.IsBroken);
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

        [Test]
        public void Repair_Method_Should_Works_Correctly()
        {
            laptopPart = new LaptopPart("mouse", 2.3m, true);
            laptopPart.Repair();

            Assert.IsFalse(laptopPart.IsBroken);
        }

        [Test]
        public void Report_Method_Should_Works_Correctly()
        {
            string report = $"mouse - 3.45${Environment.NewLine}Broken: False";

            Assert.AreEqual(report, laptopPart.Report());
        }
    }
}