namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class Tests
    {
        Phone phone;

        [SetUp]
        public void Setup()
        {
            phone = new Phone("samsung", "galaxy");
        }

        [Test]
        public void Constructor_Should_Works_Correctly()
        {
            Assert.IsNotNull(phone);
            Assert.AreEqual(0, phone.Count);
        }

        [Test]
        public void Make_Property_Should_Works_Correctly()
        {
            Assert.AreEqual("samsung", phone.Make);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void Make_Property_Should_Throws_Exception(string value)
        {
            Assert.Throws<ArgumentException>(() => phone = new Phone(value, "galaxy"));
        }

        [Test]
        public void Model_Property_Should_Works_Correctly()
        {
            Assert.AreEqual("galaxy", phone.Model);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void Model_Property_Should_Throws_Exception(string value)
        {
            Assert.Throws<ArgumentException>(() => phone = new Phone("samsung", value));
        }

        [Test]
        public void AddContact_Method_Should_Works_Correctly()
        {
            phone.AddContact("hp", "model");

            Assert.AreEqual(1, phone.Count);
        }

        [Test]
        public void AddContact_Method_Should_Throws_Exception()
        {
            phone.AddContact("hp", "model");

            Assert.Throws<InvalidOperationException>(() => phone.AddContact("hp", "model"));
        }

        [Test]
        public void Call_Method_Should_Works_Correctly()
        {
            phone.AddContact("hp", "model");

            Assert.AreEqual("Calling hp - model...", phone.Call("hp"));
        }

        [Test]
        public void Call_Method_Should_Throws_Exception()
        {
            phone.AddContact("hp", "model");

            Assert.Throws<InvalidOperationException>(() => phone.Call("samsung"));
        }
    }
}