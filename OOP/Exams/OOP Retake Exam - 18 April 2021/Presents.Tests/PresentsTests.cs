using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Presents.Tests
{
    [TestFixture]
    public class PresentsTests
    {
        private Present present;
        private Bag bag;

        [SetUp]
        public void StartUp()
        {
            //present = new Present("Ivan", 5);
            bag = new Bag();
        }

        [Test]
        public void Ctor_PresentTest()
        {
            present = new Present("Ivan", 5.2);
            Assert.That(present.Name, Is.EqualTo("Ivan"));
            Assert.That(present.Magic, Is.EqualTo(5.2));
        }

        [Test]
        public void Bag_CreateEmptyPresentTest()
        {
            bag = new Bag();
            Assert.Throws<ArgumentNullException>(() => bag.Create(present));
        }

        [Test]
        public void Bag_CreateAlreadyExistedPresentTest()
        {
            bag = new Bag();
            Present present = new Present("Pesho", 5);
            bag.Create(present);
            Assert.Throws<InvalidOperationException>(() => bag.Create(present));
        }

        [Test]
        public void Bag_SuccesfullyAddPresentTest()
        {
            bag = new Bag();
            Present present = new Present("Pesho", 5.2);
            string message = bag.Create(present);
            Assert.That(message, Is.EqualTo($"Successfully added present {present.Name}."));
            IReadOnlyCollection<Present> presents = bag.GetPresents();
            Assert.That(presents.Count, Is.EqualTo(1));
        }

        [Test]
        public void Bag_SuccesfullyRemovePresentTest()
        {
            Present present = new Present("Gosho", 3);
            bag = new Bag();
            bag.Create(present);

            bool removeSuccesfully = bag.Remove(present);
            Assert.That(removeSuccesfully, Is.EqualTo(true));
        }

        [Test]
        public void Bag_GetPressentWithLeastMagicTest()
        {
            Present first = new Present("Gosho", 3);
            Present second = new Present("Pesho", 5);
            bag.Create(first);
            bag.Create(second);
            Present selectedPresent = bag.GetPresentWithLeastMagic();
            Assert.That(selectedPresent, Is.EqualTo(first));
        }

        [Test]
        public void Bag_GetPresentByNameTest()
        {
            Present present = new Present("Pesho", 5);
            bag.Create(present);
            Present selectedPresent = bag.GetPresent("Pesho");
            Assert.That(selectedPresent, Is.EqualTo(present));
        }
    }
}
