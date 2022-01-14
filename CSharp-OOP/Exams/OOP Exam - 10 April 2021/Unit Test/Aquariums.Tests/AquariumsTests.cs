using NUnit.Framework;

namespace Aquariums.Tests
{
    using System;

    [TestFixture]
    public class AquariumsTests
    {
        private Aquarium aquarium;
        private Fish fish;

        [SetUp]
        public void StartUp()
        {
        }

        [Test]
        public void Ctor_FishTest()
        {
            fish = new Fish("Gosho");
            Assert.That(fish.Name, Is.EqualTo("Gosho"));
            Assert.That(fish.Available, Is.EqualTo(true));
        }

        // Potential bug Check for fish properties

        [Test]
        public void Ctor_AquariumProperlySetNameAndCapacity()
        {
            aquarium = new Aquarium("Ribite", 10);
            Assert.That(aquarium.Name, Is.EqualTo("Ribite"));
            Assert.That(aquarium.Capacity, Is.EqualTo(10));
        }

        [TestCase("", 10)]
        [TestCase(null, 10)]
        [Test]
        public void Ctor_UnproperlySettingName(string name, int capacity)
        {
            Assert.Throws<ArgumentNullException>(() => aquarium = new Aquarium(name, capacity));
        }

        [Test]
        public void Count_Properly()
        {
            fish = new Fish("Gosho");
            aquarium = new Aquarium("Na gosho", 2);
            this.aquarium.Add(fish);
            Assert.That(aquarium.Count, Is.EqualTo(1));
        }

        [Test]
        public void Count_Unproperly()
        {
            Assert.Throws<ArgumentException>(() => aquarium = new Aquarium("Ribite", -5));
        }

        [Test]
        public void Add_Unproperly()
        {
            Fish firstFish = new Fish("Ivan");
            Fish secondFish = new Fish("Gosho");
            aquarium = new Aquarium("Ribite", 1);
            aquarium.Add(firstFish);
            Assert.Throws<InvalidOperationException>(() => aquarium.Add(secondFish));
        }

        [Test]
        public void Remove_Properly()
        {
            fish = new Fish("Pesho");
            aquarium = new Aquarium("Ribite", 5);
            aquarium.Add(fish);
            Assert.That(aquarium.Count, Is.EqualTo(1));
            aquarium.RemoveFish("Pesho");
            Assert.That(aquarium.Count, Is.EqualTo(0));
        }

        [Test]
        public void SellingFish_Properly()
        {
            fish = new Fish("Pesho");
            aquarium = new Aquarium("Ribite", 5);
            aquarium.Add(fish);

            Fish selledFish = aquarium.SellFish("Pesho");
            Assert.That(fish, Is.EqualTo(selledFish));
            Assert.That(fish.Available, Is.EqualTo(false));
        }

        [Test]
        public void SellFish_Unproperly()
        {
            aquarium = new Aquarium("Ribite", 5);

            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish("Gosho"));
        }

        [Test]
        public void Test_Report()
        {
            aquarium = new Aquarium("Ribite", 5);
            aquarium.Add(new Fish("Pesho"));
            aquarium.Add(new Fish("Gosho"));

            string result = $"Fish available at {aquarium.Name}: Pesho, Gosho";
            Assert.That(aquarium.Report, Is.EqualTo(result));
        }
    }
}
