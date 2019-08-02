using NUnit.Framework;
using Service.Models.Devices;
using Service.Models.Parts;
using System;

namespace Service.Tests
{
    [TestFixture]
    public class DeviceTests
    {
        Laptop laptop;

        [SetUp]
        public void Setup()
        {
            laptop = new Laptop("hp");
        }

        [Test]
        public void Device_Constructor_Should_Set_Correctly()
        {
            Assert.IsNotNull(laptop);
            Assert.AreEqual("hp", laptop.Make);
            Assert.IsNotNull(laptop.Parts);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Make_Property_Should_Throws_Exception_With_Null_Or_Empty_Value(string value)
        {
            Assert.Throws<ArgumentException>(() => laptop = new Laptop(value));
        }

        [Test]
        public void AddPart_Method_Should_Throws_Exception_With_Wrong_Part()
        {
            PCPart part = new PCPart("mouse", 23.3m, false);

            Assert.Throws<InvalidOperationException>(() => laptop.AddPart(part));
        }

        [Test]
        public void AddPart_Method_Should_Work_Correctly()
        {
            LaptopPart part = new LaptopPart("mouse", 23.3m, false);

            laptop.AddPart(part);

            Assert.AreEqual(1, laptop.Parts.Count);
        }

        [Test]
        public void AddPart_Method_Should_Throws_Exception_With_Existing_Part()
        {
            LaptopPart part = new LaptopPart("mouse", 23.3m, false);

            laptop.AddPart(part);

            Assert.Throws<InvalidOperationException>(() => laptop.AddPart(part));
        }
    }
}
