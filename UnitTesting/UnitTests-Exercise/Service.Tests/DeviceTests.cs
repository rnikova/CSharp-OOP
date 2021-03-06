﻿using NUnit.Framework;
using Service.Models.Devices;
using Service.Models.Parts;
using System;

namespace Service.Tests
{
    [TestFixture]
    public class DeviceTests
    {
        private Laptop laptop;
        private PC pc;
        private Phone phone;

        [SetUp]
        public void Setup()
        {
            laptop = new Laptop("hp");
            pc = new PC("hp");
            phone = new Phone("hp");
        }

        [Test]
        public void Laptop_Constructor_Should_Set_Correctly()
        {
            Assert.IsNotNull(laptop);
            Assert.AreEqual("hp", laptop.Make);
            Assert.IsNotNull(laptop.Parts);
        }

        [Test]
        public void PC_Constructor_Should_Set_Correctly()
        {
            Assert.IsNotNull(pc);
            Assert.AreEqual("hp", pc.Make);
            Assert.IsNotNull(pc.Parts);
        }

        [Test]
        public void Phone_Constructor_Should_Set_Correctly()
        {
            Assert.IsNotNull(phone);
            Assert.AreEqual("hp", phone.Make);
            Assert.IsNotNull(phone.Parts);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Make_Property_Should_Throws_Exception_With_Null_Or_Empty_Value(string value)
        {
            Assert.Throws<ArgumentException>(() => laptop = new Laptop(value));
            Assert.Throws<ArgumentException>(() => pc = new PC(value));
            Assert.Throws<ArgumentException>(() => phone = new Phone(value));
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
            var parts = laptop.Parts;

            Assert.AreEqual(1, laptop.Parts.Count);
            Assert.That(parts, Has.Member(part));
        }

        [Test]
        public void AddPart_Method_Should_Throws_Exception_With_Existing_Part()
        {
            LaptopPart part = new LaptopPart("mouse", 23.3m, false);

            laptop.AddPart(part);

            Assert.Throws<InvalidOperationException>(() => laptop.AddPart(part));
        }

        [Test]
        public void RemovePart_Method_Should_Throws_Exception_With_Null_Or_Empty_Part()
        { 
            Assert.Throws<ArgumentException>(() => laptop.RemovePart(""));
        }

        [Test]
        public void RemovePart_Method_Should_Throws_Exception_With_Invalid_Part()
        {
            Assert.Throws<InvalidOperationException>(() => laptop.RemovePart("keyboard"));
        }

        [Test]
        public void RemovePart_Method_Should_Works_Correctly()
        {
            LaptopPart part = new LaptopPart("mouse", 23.3m, false);

            laptop.AddPart(part);
            laptop.RemovePart("mouse");

            Assert.AreEqual(0, laptop.Parts.Count);
        }

        [Test]
        public void RepairPart_Method_Should_Throws_Exception_With_Null_Or_Empty_Part()
        {
            Assert.Throws<ArgumentException>(() => laptop.RepairPart(""));
        }

        [Test]
        public void Repair_Method_Should_Throws_Exception_With_Invalid_Part()
        {
            Assert.Throws<InvalidOperationException>(() => laptop.RemovePart("keyboard"));
        }

        [Test]
        public void Repair_Method_Should_Throws_Exception_With_Not_Broken_Part()
        {
            Assert.Throws<InvalidOperationException>(() => laptop.RemovePart("mouse"));
        }        
    }
}
