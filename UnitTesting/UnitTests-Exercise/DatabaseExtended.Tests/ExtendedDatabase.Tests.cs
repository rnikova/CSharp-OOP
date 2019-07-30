namespace Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase database;
        private Person person;

        [SetUp]
        public void Setup()
        {
            this.person = new Person(1, "gosho");
            Person[] persons = new Person[1] { person };
            this.database = new ExtendedDatabase(persons);
        }

        [Test]
        public void PersonConstructorShouldSetsCorrectly()
        {
            Assert.That(this.person, Is.InstanceOf<Person>());
        }

        [Test]
        public void ExtendedDatabaseConstructorShouldSetCorrectly()
        {
            Assert.That(this.database, Is.InstanceOf<ExtendedDatabase>());
        }

        [Test]
        public void ExtendedDatabaseShouldAddCorrectlyPerson()
        {
            this.person = new Person(2, "pesho");
            this.database.Add(person);

            Assert.That(2, Is.EqualTo(this.database.Count));
        }

        [Test]
        public void ExtendedDatabaseShouldThrowsExceptionWithExistsId()
        {
            Person newPerson = new Person(1, "pesho");

            Assert.Throws<InvalidOperationException>(() => this.database.Add(newPerson));
        }

        [Test]
        public void ExtendedDatabaseShouldThrowsExceptionWithExistsUsername()
        {
            Person newPerson = new Person(2, "gosho");

            Assert.Throws<InvalidOperationException>(() => this.database.Add(newPerson));
        }

        [Test]
        public void ExtendedDatabaseShouldThrowsExceptionWithMoreThan16Persons()
        {
            for (int i = 2; i <= 16; i++)
            {
                Person person = new Person(i, $"{i}");
                this.database.Add(person);
            }

            Person anotherPerson = new Person(20, "mimi");

            Assert.Throws<InvalidOperationException>(() => this.database.Add(anotherPerson));
        }

        [Test]
        public void ExtendedDatabaseShouldRemoveCorrectly()
        {
            this.database.Remove();

            Assert.That(0, Is.EqualTo(this.database.Count));
        }

        [Test]
        public void ExtendedDatabaseShouldThrowsExceptionByRemoveMethod()
        {
            this.database.Remove();

            Assert.Throws<InvalidOperationException>(() => this.database.Remove());
        }

        [Test]
        public void ExtendedDatabaseShouldFindByIdCorrectly()
        {
            var actualcPerson = this.database.FindById(1);
            Person expectedPerson = new Person(1, "gosho");

            Assert.That(expectedPerson.Id, Is.EqualTo(actualcPerson.Id));
        }

        [Test]
        public void ExtendedDatabaseShouldThrowsExceptionWith0Id()
        {
            Assert.Throws<InvalidOperationException>(() => this.database.FindById(0));
        }

        [Test]
        public void ExtendedDatabaseShouldThrowsExceptionWithInvalidId()
        {
            Assert.Throws<InvalidOperationException>(() => this.database.FindById(100));
        }

        [Test]
        public void ExtendedDatabaseShouldFindByUsernameCorrectly()
        {
            var actualcPerson = this.database.FindByUsername("gosho");
            Person expectedPerson = new Person(1, "gosho");

            Assert.That(expectedPerson.UserName, Is.EqualTo(actualcPerson.UserName));
        }

        [Test]
        public void ExtendedDatabaseShouldThrowsExceptionWithNullUsuername()
        {
            Assert.Throws<ArgumentNullException>(() => this.database.FindByUsername(null));
        }

        [Test]
        public void ExtendedDatabaseShouldThrowsExceptionWithEmptyUsername()
        {
            Assert.Throws<ArgumentNullException>(() => this.database.FindByUsername(string.Empty));
        }

        [Test]
        public void ExtendedDatabaseShouldThrowsExceptionWithInvalidUsername()
        {
            Assert.Throws<InvalidOperationException>(() => this.database.FindByUsername("koko"));
        }
    }
}