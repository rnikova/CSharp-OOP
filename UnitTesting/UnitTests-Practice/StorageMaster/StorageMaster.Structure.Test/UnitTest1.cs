using NUnit.Framework;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Vehicles;
using System;
using System.Linq;

namespace Tests
{
    public class Tests
    {
        private Vehicle van;

        [SetUp]
        public void Setup()
        {
            this.van = new Van();
        }

        [Test]
        public void LoadProductShouldAddProductCorrectly()
        {
            Product product = new Ram(2.3);

            this.van.LoadProduct(product);

            var expectedCount = 1;

            Assert.That(expectedCount, Is.EqualTo(this.van.Trunk.Count));
            Assert.That(product, Is.EqualTo(this.van.Trunk.Last()));
        }

        [Test]
        public void LoadProductShouldThrowsException()
        {
            Product product = new Ram(2.3);

            for (int i = 0; i < 20; i++)
            {
                this.van.LoadProduct(product);
            }


            var expectedCount = 20;

            Assert.That(expectedCount, Is.EqualTo(this.van.Trunk.Count));
            Assert.Throws<InvalidOperationException>(() => this.van.LoadProduct(product));
        }

        [Test]
        public void UnloadProductShouldThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => this.van.Unload());
        }

        [Test]
        public void UnloadProductShouldWorksCorrectly()
        {
            Product product = new Ram(2.3);
            Product productToRemove = new Gpu(2.3);

            this.van.LoadProduct(product);
            this.van.LoadProduct(productToRemove);
            var result = this.van.Unload();

            var expectedCount = 1;

            Assert.That(expectedCount, Is.EqualTo(this.van.Trunk.Count));
            Assert.AreSame(productToRemove, result);
        }

        [Test]
        public void IsEmptyReturnsTrue()
        {
            var result = this.van.IsEmpty;

            Assert.IsTrue(result);
        }

        [Test]
        public void IsEmptyReturnsFalse()
        {
            Product product = new Ram(2.34);

            this.van.LoadProduct(product);

            var result = this.van.IsEmpty;

            Assert.IsFalse(result);
        }

        [Test]
        public void IsFullReturnsTrue()
        {
            Product product = new HardDrive(2.34);

            this.van.LoadProduct(product);
            this.van.LoadProduct(product);

            var result = this.van.IsFull;

            Assert.IsTrue(result);
        }

        [Test]
        public void IsFullReturnsFalse()
        {
            var result = this.van.IsFull;

            Assert.IsFalse(result);
        }

        [Test]
        public void CapacityIsSetCorrectly()
        {
            Assert.That(this.van.Capacity == 2);
        }
    }
}