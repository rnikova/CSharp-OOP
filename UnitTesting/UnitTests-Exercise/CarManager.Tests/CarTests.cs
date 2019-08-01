using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class CarTests
    {
        Car car;

        [SetUp]
        public void Setup()
        {
            car = new Car("vw", "golf", 10.0, 100.00);
        }

        [Test]
        public void Car_Constuctor_Should_Sets_Correctly()
        {
            Assert.AreEqual("vw", car.Make);
            Assert.AreEqual("golf", car.Model);
            Assert.AreEqual(10.0, car.FuelConsumption);
            Assert.AreEqual(100.00, car.FuelCapacity);
            Assert.AreEqual(0, car.FuelAmount);
        }

        [Test]
        public void Make_Property_Should_Throws_Exception()
        {
            Assert.Throws<ArgumentException>(() => car = new Car("", "golf", 10, 100));
        }

        [Test]
        public void Model_Property_Should_Throws_Exception()
        {
            Assert.Throws<ArgumentException>(() => car = new Car("vw", "", 10, 100));
        }

        [Test]
        public void FuelConsumption_Property_Should_Throws_Exception()
        {
            Assert.Throws<ArgumentException>(() => car = new Car("vw", "golf", 0, 100));
        }

        [Test]
        public void FuelCapacity_Property_Should_Throws_Exception()
        {
            Assert.Throws<ArgumentException>(() => car = new Car("vw", "golf", 10, -1));
        }

        [Test]
        public void Refuel_Method_Should_Throws_Exception()
        {
            Assert.Throws<ArgumentException>(() => car.Refuel(0));
        }

        [Test]
        public void Refuel_Method_Should_Works_Correctly()
        {
            car.Refuel(10);

            Assert.AreEqual(10, car.FuelAmount);
        }

        [Test]
        public void Refuel_Method_Should_Works_Correctly_With_Max_Fuel()
        {
            car.Refuel(120);

            Assert.AreEqual(100, car.FuelAmount);
        }

        [Test]
        public void Drive_Method_Should_Works_Correctly()
        {
            car.Refuel(100);
            car.Drive(10);

            Assert.That(99, Is.EqualTo(car.FuelAmount));
        }

        [Test]
        public void Drive_Method_Should_Throws_Exception_With_Zero_Amount()
        {
            Assert.Throws<InvalidOperationException>(() => car.Drive(10));
        }

        [Test]
        public void Drive_Method_Should_Throws_Exception()
        {
            car.Refuel(100);

            Assert.Throws<InvalidOperationException>(() => car.Drive(4500));
        }
    }
}