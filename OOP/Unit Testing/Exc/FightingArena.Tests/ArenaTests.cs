using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        private Warrior warrior;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Ctor_ArenaSeetingCountProperly()
        {
            arena = new Arena();
            Assert.That(arena.Count, Is.EqualTo(0));
        }

        [Test]
        public void EnrollWorkingProperly()
        {
            Warrior warrior = new Warrior("Ivan", 50, 50);
            arena = new Arena();
            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior));
        }
    }
}
