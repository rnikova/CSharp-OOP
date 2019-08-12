namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class SpaceshipTests
    {
        Spaceship spaceship;
        Astronaut astronaut;

        [SetUp]
        public void Setup()
        {
            spaceship = new Spaceship("name", 10);
            astronaut = new Astronaut("name", 100.0);
        }

        [Test]
        public void Astronaut_Constuctor_Should_Sets_Correctly()
        {
            Assert.AreEqual("name", astronaut.Name);
            Assert.AreEqual(100.0, astronaut.OxygenInPercentage);
        }

        [Test]
        public void Spaceship_Constuctor_Should_Sets_Correctly()
        {
            Assert.AreEqual("name", spaceship.Name);
            Assert.AreEqual(10, spaceship.Capacity);
            Assert.AreEqual(0, spaceship.Count);
        }

        [Test]
        public void Count_Property_Should_Works_Correctly()
        {
            Assert.AreEqual(0, spaceship.Count);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void Name_Property_Should_Throws_Exception(string value)
        {
            Assert.Throws<ArgumentNullException>(() => spaceship = new Spaceship(value, 20), "Invalid spaceship name!");
        }

        [Test]
        [TestCase(0)]
        [TestCase(5)]
        public void Capacity_Property_Should_Works_Correctly(int value)
        {
            spaceship = new Spaceship("name", value);

            Assert.AreEqual(value, spaceship.Capacity);
        }

        [Test]
        public void Capacity_Property_Should_Throws_Exception()
        {
            Assert.Throws<ArgumentException>(() => spaceship = new Spaceship("name", -19), "Invalid capacity!");
        }

        [Test]
        public void Add_Method_Should_Works_Correctly()
        {
            spaceship.Add(astronaut);

            Assert.AreEqual(1, spaceship.Count);
        }

        [Test]
        public void Add_Method_Should_Throws_Exception_With_Full_Capacity()
        {
            for (int i = 0; i < spaceship.Capacity; i++)
            {
                astronaut = new Astronaut($"{i}", 10);
                spaceship.Add(astronaut);
            }

            astronaut = new Astronaut("name", 10);

            Assert.Throws<InvalidOperationException>(() => spaceship.Add(astronaut));
        }

        [Test]
        public void Add_Method_Should_Throws_Exception_With_Exist_Astronaut()
        {
            spaceship.Add(astronaut);

            Assert.Throws<InvalidOperationException>(() => spaceship.Add(astronaut));
        }

        [Test]
        public void Remove_Method_Should_Works_Correctly()
        {
            spaceship.Add(astronaut);
            bool isRemove = spaceship.Remove("name");

            Assert.AreEqual(0, spaceship.Count);
            Assert.IsTrue(isRemove);
        }

        [Test]
        public void Remove_Method_Should_Be_False()
        {
            spaceship.Add(astronaut);
            bool isRemove = spaceship.Remove("namename");

            Assert.IsFalse(isRemove);
            Assert.AreEqual(1, spaceship.Count);
        }
    }
}