using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor_Works_Correctly()
        {
            Warrior warrior = new Warrior("pesho", 15, 100);

            Assert.AreEqual("pesho", warrior.Name);
            Assert.AreEqual(15, warrior.Damage);
            Assert.AreEqual(100, warrior.HP);
        }

        [Test]
        public void Constructor_Throws_Exception_With_Empty_Name()
        {
            Assert.Throws<ArgumentException>(() => { Warrior warrior = new Warrior("   ", 15, 100); });
        }

        [Test]
        [TestCase(0)]
        [TestCase(-15)]
        public void Constructor_Throws_Exception_With_Negative_Or_Zero_Damage(int value)
        {
            Assert.Throws<ArgumentException>(() => { Warrior warrior = new Warrior("pesho", value, 100); });
        }

        [Test]
        public void Constructor_Throws_Exception_With_Negative_HP()
        {
            Assert.Throws<ArgumentException>(() => { Warrior warrior = new Warrior("pesho", 15, -3); });
        }

        [Test]
        public void Attack_Method_Should_Works_Correctly()
        {
            Warrior attacker = new Warrior("pesho", 10, 100);
            Warrior defender = new Warrior("gosho", 5, 90);

            attacker.Attack(defender);

            Assert.AreEqual(95, attacker.HP);
            Assert.AreEqual(80, defender.HP);
        }

        [Test]
        public void Attack_Method_With_Low_Hp_Should_Throws_Exception()
        {
            Warrior attacker = new Warrior("pesho", 10, 25);
            Warrior defender = new Warrior("gosho", 5, 45);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }

        [Test]
        public void Attack_Method_With_Low_Hp__Defender_Should_Throws_Exception()
        {
            Warrior attacker = new Warrior("pesho", 10, 45);
            Warrior defender = new Warrior("gosho", 5, 25);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }

        [Test]
        public void Attack_Method_Should_Throws_Exception_With_Stronger_Enemy()
        {
            Warrior attacker = new Warrior("pesho", 10, 35);
            Warrior defender = new Warrior("gosho", 40, 100);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }

        [Test]
        public void Attack_Method_Killing_Enemy()
        {
            Warrior attacker = new Warrior("pesho", 50, 100);
            Warrior defender = new Warrior("gosho", 45, 40);

            attacker.Attack(defender);

            Assert.AreEqual(55, attacker.HP);
            Assert.AreEqual(0, defender.HP);
        }
    }
}