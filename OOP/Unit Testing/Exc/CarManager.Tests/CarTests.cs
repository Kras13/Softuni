using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            car = new Car("Make", "Model", 5, 100);
        }


        [Test]
        public void Ctor_ProperlySetingValues()
        {
            car = new Car("Audi", "A4", 6, 48);
            Assert.That(car.Make == "Audi");
            Assert.That(car.Model == "A4");
            Assert.That(car.FuelConsumption == 6);
            Assert.That(car.FuelCapacity == 48);
        }

        [Test]
        [TestCase("", "Model", 5, 100)]
        [TestCase(null, "Model", 5, 100)]
        [TestCase(null, "", 5, 100)]
        [TestCase("asd", null, 5, 100)]
        [TestCase("asd", "Model", 0, 100)]
        [TestCase("asd", "Model", -5, 100)]
        [TestCase("asd", "Model", 5, 0)]
        [TestCase("asd", "Model", 5, -5)]
        public void Ctor_ThrowsExceptionWhenDataIsInvalid(
            string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]

        public void Emptytor_Test()
        {
            car = new Car("Audi", "A4", 6, 48);
            Assert.That(car.FuelAmount, Is.EqualTo(0));
        }

        [Test]
        public void Refuel_ExceptionTest()
        {
            car = new Car("Audi", "A4", 6, 48);

            Assert.Throws<ArgumentException>(() => car.Refuel(-5));
            Assert.Throws<ArgumentException>(() => car.Refuel(0));
        }

        [Test]
        public void Refuel_RefuelingProperly()
        {
            car = new Car("Audi", "A4", 6, 48);
            car.Refuel(5);

            Assert.That(car.FuelAmount, Is.EqualTo(5));
        }

        [Test]
        public void Refuel_RefuelingMoreThanTank()
        {
            car = new Car("Audi", "A4", 6, 48);
            car.Refuel(50);

            Assert.That(car.FuelAmount, Is.EqualTo(48));
        }

        [Test]
        public void Drive_ExceptionMoreNeededFuel()
        {
            car = new Car("Audi", "A4", 5, 48);
            car.Refuel(10);

            Assert.Throws<InvalidOperationException>(() => car.Drive(201));
        }

        [Test]
        public void Drive_ProperlyDrive()
        {
            car = new Car("Audi", "A4", 5, 48);
            car.Refuel(10);
            car.Drive(190);

            Assert.That(car.FuelAmount > 0);
        }

        [Test]
        public void Refuel_SetFuelAmountToCapacity()
        {
            car.Refuel(car.FuelCapacity * 1.2);
            Assert.That(car.FuelAmount, Is.EqualTo(car.FuelCapacity));
        }

        [Test]
        public void Drive_DecreaseFuelAmountProperly()
        {
            double initialFuel = car.FuelCapacity;
            car.Refuel(initialFuel);
            car.Drive(100);
            Assert.That(car.FuelAmount, Is.EqualTo(initialFuel - car.FuelConsumption));
        }
    }
}