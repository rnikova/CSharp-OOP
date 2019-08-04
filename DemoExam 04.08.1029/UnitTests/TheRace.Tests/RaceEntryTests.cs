using NUnit.Framework;
using System;

namespace TheRace.Tests
{
    [TestFixture]
    public class RaceEntryTests
    {
        RaceEntry race;
        UnitRider rider;
        UnitMotorcycle motorcycle;

        [SetUp]
        public void Setup()
        {
            race = new RaceEntry();
            motorcycle = new UnitMotorcycle("model", 100, 100);
            rider = new UnitRider("rider", motorcycle);
        }

        [Test]
        public void Constructor_Should_Works_Correctly()
        {
            Assert.IsNotNull(race);
            Assert.AreEqual(0, race.Counter);
        }

        [Test]
        public void UnitRider_Should_Works_Correctly()
        {
            Assert.IsNotNull(rider);
        }

        [Test]
        public void UnitRider_Should_Throws_Exception()
        {
            Assert.Throws<ArgumentNullException>(() => rider = new UnitRider(null, motorcycle));
        }

        [Test]
        public void UnitMotorcycle_Should_Work_Correctly()
        {
            Assert.IsNotNull(motorcycle);
        }

        [Test]
        public void AddRider_Should_Works_Correctly()
        {
            race.AddRider(rider);

            Assert.AreEqual(1, race.Counter);
        }

        [Test]
        public void AddRider_Should_Throws_Exception_With_Null_Rider()
        {
            Assert.Throws<InvalidOperationException>(() => race.AddRider(null));
        }

        [Test]
        public void AddRider_Should_Throws_Exception_With_Exist_Rider()
        {
            race.AddRider(rider);

            Assert.Throws<InvalidOperationException>(() => race.AddRider(rider));
        }

        [Test]
        public void CalculateAverageHorsePower_Should_Throws_Exception()
        {
            race.AddRider(rider);

            Assert.Throws<InvalidOperationException>(() => race.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateAverageHorsePower_Should_Works_Correctly()
        {
            race.AddRider(rider);

            rider = new UnitRider("rider2", motorcycle);

            race.AddRider(rider);

            var actualAverageHorsePower = race.CalculateAverageHorsePower();

            Assert.AreEqual(100, actualAverageHorsePower);
        }
    }
}