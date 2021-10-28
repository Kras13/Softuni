using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Ctor_UnitDriverTest()
        {
            var unitCar = new UnitCar("Audi", 239, 3000);
            var unitDriver = new UnitDriver("Pesho", unitCar);
            Assert.That(unitDriver.Name, Is.EqualTo("Pesho"));
            Assert.That(unitDriver.Car, Is.EqualTo(unitCar));
        }

        [Test]
        public void UnproperlySttingName_UnitDriver()
        {
            var unitCar = new UnitCar("Audi", 239, 3000);
            Assert.Throws<ArgumentNullException>(() => new UnitDriver(null, unitCar));
        }

        [Test]
        public void Ctor_UnitCarTest()
        {
            var unitCar = new UnitCar("VW", 150, 2000);
            Assert.That(unitCar.Model, Is.EqualTo("VW"));
            Assert.That(unitCar.HorsePower, Is.EqualTo(150));
            Assert.That(unitCar.CubicCentimeters, Is.EqualTo(2000));
        }

        [Test]
        public void RaceEntryAddDriverNull_Test()
        {
            var race = new RaceEntry();
            Assert.Throws<InvalidOperationException>(() => race.AddDriver(null));
            Assert.That(race.Counter, Is.EqualTo(0));
        }

        [Test]
        public void RaceEntryAddDriverAlreadyExisted_Test()
        {
            var race = new RaceEntry();
            var unitDriver = new UnitDriver("Gosho", new UnitCar("BMW", 245, 3000));
            race.AddDriver(unitDriver);
            Assert.Throws<InvalidOperationException>(() => race.AddDriver(unitDriver));
            Assert.That(race.Counter, Is.EqualTo(1));
        }

        [Test]
        public void RaceEntryAddDriverProperly_Test()
        {
            // "Driver {0} added in race.";
            var unitDriver = new UnitDriver("Pesho", new UnitCar("VW", 101, 1600));
            var race = new RaceEntry();
            string result = race.AddDriver(unitDriver);
            Assert.That(race.Counter, Is.EqualTo(1));
            Assert.That(result, Is.EqualTo($"Driver {unitDriver.Name} added in race."));
        }

        [Test]
        public void RaceEntryCalculateAverageException_Test()
        {
            var unitDriver = new UnitDriver("Gosho", new UnitCar("Audi", 130, 1900));
            var race = new RaceEntry();
            race.AddDriver(unitDriver);
            Assert.Throws<InvalidOperationException>(() => race.CalculateAverageHorsePower());
        }

        [Test]
        public void RaceEntryCalculateAverageProperly_Test()
        {
            var unitDriver = new UnitDriver("Gosho", new UnitCar("Audi", 131, 1900));
            UnitDriver second = new UnitDriver("Pesho", new UnitCar("Bmw", 150, 2000));
            UnitDriver third = new UnitDriver("Kiro", new UnitCar("BMW", 193, 3000));
            var race = new RaceEntry();
            race.AddDriver(unitDriver);
            race.AddDriver(second);
            race.AddDriver(third);
            double result = race.CalculateAverageHorsePower();
            double expectedResult = (unitDriver.Car.HorsePower + second.Car.HorsePower + third.Car.HorsePower) / 3;
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}