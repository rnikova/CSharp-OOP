namespace Tests
{
    using System;
    using Database;
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void Setup()
        {
            this.database = new Database(1, 2, 3, 4, 5, 6);
        }

        [Test]
        public void AddMethodShouldThrowExceptionWithInvalidParameters()
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

            Assert.That(12, Is.EqualTo(this.database.Count));
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

            Assert.That(5, Is.EqualTo(this.database.Count));
        }

        [Test]
        public void ConstructorShoultInitialiazeCorrectly()
        {
            this.database = new Database(1, 2, 3, 4);

            Assert.That(4, Is.EqualTo(this.database.Count));
        }

        [Test]
        public void ConstructorShoultThrowExceptionWithInvalidParameters()
        {
            Assert.Throws<InvalidOperationException>(
                () => this.database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16));
        }

        [Test]
        public void FechMethodShoultReturnCorrectArray()
        {
            int[] actualDatabase = this.database.Fetch();
            int[] expectedDatabase = new int[] { 1, 2, 3, 4, 5, 6 };

            Assert.That(actualDatabase, Is.EqualTo(expectedDatabase));
        }
    }
}