using DatabaseProblem;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {
        private Database database;

        [SetUp]
        public void Setup()
        {
            this.database = new Database(1, 2, 3, 4, 5, 6);
        }

        [Test]
        public void AddMethodShouldThrowExceptionWithInvalidParameter()
        {
            for (int i = 0; i < 10; i++)
            {
                this.database.Add(7);
            }

            Assert.Throws<InvalidOperationException>(() => this.database.Add(11));
        }

        [Test]
        public void AddMethodShouldWorkCorrectly()
        {
            for (int i = 0; i < 6; i++)
            {
                this.database.Add(7);
            }

            Assert.That(12, Is.EqualTo(this.database.DatabaseElements.Length));
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionWithEmptyDatabase()
        {
            for (int i = 0; i < 6; i++)
            {
                this.database.Remove();
            }

            Assert.Throws<InvalidOperationException>(() => this.database.Remove());
        }

        [Test]
        public void RemoveMethodShoultRemoveOneElement()
        {
            this.database.Remove();

            Assert.That(5, Is.EqualTo(this.database.DatabaseElements.Length));
        }

        [Test]
        public void ConstructorShoultInitialiazeCorrectly()
        {
            this.database = new Database(1, 2, 3, 4);

            Assert.That(4, Is.EqualTo(this.database.DatabaseElements.Length));
        }

        [Test]
        public void ConstructorShoultThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => this.database = new Database());
        }

        [Test]
        public void PropertyDatabaseElementsShoultSetCorrectly()
        {
            var collection = new List<int> { 1, 2, 3, 4, 5, 6 };

            CollectionAssert.AreEqual(collection, this.database.DatabaseElements);
        }

        [Test]
        public void PropertyDatabaseElementsShoultGetCorrectly()
        {
            Assert.That(6, Is.EqualTo(this.database.DatabaseElements.Length));
        }
    }
}