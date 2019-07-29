using NUnit.Framework;

namespace Chainblock.Tests
{
    public class ChainblockTests
    {
        Chainblock chainblock;
        Transaction mainTransaction;

        [SetUp]
        public void SetUp()
        {
            this.chainblock = new Chainblock();
            this.mainTransaction = new Transaction(5, TransactionStatus.Successfull, "Gosho", "Pesho", 23.54m);
        }

        [Test]
        public void Add_Method_Should_Increase_Count_With_One()
        {
            this.mainTransaction = new Transaction(5, TransactionStatus.Successfull, "Gosho", "Pesho", 23.54m);

            this.chainblock.Add(this.mainTransaction);

            Assert.That(1, Is.EqualTo(this.chainblock));
        }

        [Test]
        public void Add_Method_Should_Add_The_Correct_Transaction()
        {
            this.chainblock.Add(this.mainTransaction);

            foreach (var transaction in this.chainblock)
            {
                Assert.AreEqual(this.mainTransaction, transaction);
            }
        }

        [Test]
        public void Contains_Method_By_Id_Should_Return_True()
        {          
            this.chainblock.Add(mainTransaction);

            bool actual = this.chainblock.Contains(5);

            Assert.IsTrue(actual);
        }

        [Test]
        public void Contains_Method_By_Id_Should_Return_False()
        {
            this.chainblock.Add(mainTransaction);

            bool actual = this.chainblock.Contains(9);

            Assert.IsFalse(actual);
        }

        [Test]
        public void Contains_Method_By_Transaction_Should_Return_True()
        {
            this.chainblock.Add(mainTransaction);

            bool actual = this.chainblock.Contains(this.mainTransaction);

            Assert.IsTrue(actual);
        }

        [Test]
        public void Contains_Method_By_Transaction_Should_Return_False()
        {
            bool actual = this.chainblock.Contains(this.mainTransaction);

            Assert.IsFalse(actual);
        }
    }
}
