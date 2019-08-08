namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System;

    public class SoftParkTest
    {
        private Car car;
        private SoftPark parking;

        [SetUp]
        public void Setup()
        {
            car = new Car("make", "number");
            parking = new SoftPark();
        }

        [Test]
        public void Car_Constructor_Should_Works_Correctly()
        {
            Assert.AreEqual("make", car.Make);
            Assert.AreEqual("number", car.RegistrationNumber);
        }

        [Test]
        public void SoftPark_Constructor_Should_Works_Correctly()
        {
            Assert.AreEqual(12, parking.Parking.Count);
        }

        [Test]
        public void ParkCar_Method_Should_Works_Correctly()
        {
            parking.ParkCar("A1", car);

            Assert.AreEqual(car, parking.Parking["A1"]);
        }

        [Test]
        public void ParkCar_Method_Should_Throws_Exeption_With_Invalid_ParkSpot()
        {
            Assert.Throws<ArgumentException>(() => parking.ParkCar("T1", car));
        }

        [Test]
        public void ParkCar_Method_Should_Throws_Exeption_With_Taken_ParkSpot()
        {
            parking.ParkCar("B1", car);

            Assert.Throws<ArgumentException>(() => parking.ParkCar("B1", car));
        }

        [Test]
        public void ParkCar_Method_Should_Throws_Exeption_With_TakenExist_Car()
        {
            parking.ParkCar("B1", car);

            Assert.Throws<InvalidOperationException>(() => parking.ParkCar("C1", car));
        }

        [Test]
        public void RemoveCar_Method_Should_Works_Correctly()
        {
            parking.ParkCar("A1", car);
            parking.RemoveCar("A1", car);

            Assert.IsNull(parking.Parking["A1"]);
        }

        [Test]
        public void RemoveCar_Method_Should_Throws_Exeption_With_Invalid_ParkSpot()
        {
            Assert.Throws<ArgumentException>(() => parking.RemoveCar("T1", car));
        }

        [Test]
        public void RemoveCar_Method_Should_Throws_Exeption_With_Empty_ParkSpot()
        {
            Assert.Throws<ArgumentException>(() => parking.RemoveCar("C2", car));
        }
    }
}