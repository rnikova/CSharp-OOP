using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            arena = new Arena();
        }

        [Test]
        public void Construtor_Works_Correctly()
        {
            Assert.IsNotNull(arena);
        }

        [Test]
        public void Enroll_Method_Works_Correctly()
        {
            Warrior warrior = new Warrior("pesho", 10, 100);

            arena.Enroll(warrior);

            Assert.That(arena.Warriors, Has.Member(warrior));
        }

        [Test]
        public void Enroll_Method_Contains_Warrior()
        {
            Warrior warrior = new Warrior("pesho", 10, 100);

            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior));
        }

        [Test]
        public void Count_Property_Works_Correctly()
        {
            Warrior warrior = new Warrior("pesho", 10, 100);

            arena.Enroll(warrior);

            Assert.AreEqual(1, arena.Count);
        }

        [Test]
        public void Figth_Method_Works_Correctly()
        {
            Warrior attacker = new Warrior("pesho", 10, 100);
            Warrior defender = new Warrior("gosho", 5, 50);

            arena.Enroll(attacker);
            arena.Enroll(defender);

            arena.Fight(attacker.Name, defender.Name);

            Assert.AreEqual(95, attacker.HP);
            Assert.AreEqual(40, defender.HP);
        }

        [Test]
        public void Figth_Method_Should_Throws_Exception_With_Missing_Warrior()
        {
            Warrior attacker = new Warrior("pesho", 10, 100);
            Warrior defender = new Warrior("gosho", 5, 50);

            arena.Enroll(attacker);

            Assert.Throws<InvalidOperationException>(() => arena.Fight(attacker.Name, defender.Name));
        }
    }
}
