namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    public class Tests
    {
        Phone phone;

        [SetUp]
        public void Setup()
        {
            phone = new Phone("make", "model");
        }

        [Test]
        public void Phone_Constructor_Should_Works_Correctly()
        {
            Assert.IsNotNull(phone);
            Assert.AreEqual("make", phone.Make);
            Assert.AreEqual("model", phone.Model);
            Assert.AreEqual(0, phone.Count);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Make_Property_Should_Throws_Exception(string value)
        {
            Assert.Throws<ArgumentException>(() => phone = new Phone(value, "model"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Model_Property_Should_Throws_Exception(string value)
        {
            Assert.Throws<ArgumentException>(() => phone = new Phone("make", value));
        }

        [Test]
        public void AddContact_Method_Should_Works_Correctly()
        {
            phone.AddContact("name", "phone");

            Assert.AreEqual(1, phone.Count);
        }

        [Test]
        public void AddContact_Method_Should_Throws_Exception()
        {
            phone.AddContact("name", "phone");

            Assert.Throws<InvalidOperationException>(() => phone.AddContact("name", "phone"));
        }

        [Test]
        public void Call_Method_Should_Works_Correctly()
        {
            phone.AddContact("name", "phone");

            Assert.AreEqual("Calling name - phone...", phone.Call("name"));
        }

        [Test]
        public void Call_Method_Should_Throws_Exception()
        {
            Assert.Throws<InvalidOperationException>(() => phone.Call("phone"));
        }
    }
}