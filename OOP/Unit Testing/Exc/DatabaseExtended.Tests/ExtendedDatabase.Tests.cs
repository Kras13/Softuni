using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase extendedDb;

        [SetUp]
        public void Setup()
        {
            extendedDb = new ExtendedDatabase();
        }

        [Test]
        public void Ctor_AddPeopleToTheDb()
        {
            Person[] people = new Person[5];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, $"Name: {i}");
            }

            extendedDb = new ExtendedDatabase(people);
            Assert.That(extendedDb.Count, Is.EqualTo(people.Length));

            foreach (var person in people)
            {
                Person selectedPerson = extendedDb.FindById(person.Id);
                Assert.That(person, Is.EqualTo(selectedPerson));
            }
        }

        [Test]
        public void Ctor_ThrowIfCapacityExceede()
        {
            Person[] peopleToAdd = new Person[17];
            for (int i = 0; i < peopleToAdd.Length; i++)
            {
                Person person = new Person(i + 5, $"UserId: {i}");
            }

            Assert.Throws<ArgumentException>(() => extendedDb = new ExtendedDatabase(peopleToAdd));
        }

        [Test]
        public void Add_ThrowIfCapacityExceeded()
        {
            Person[] peopleToAdd = new Person[16];
            for (int i = 0; i < peopleToAdd.Length; i++)
            {
                extendedDb.Add(new Person(i + 5, $"UserId: {i}"));
            }

            Assert.Throws<InvalidOperationException>(() => extendedDb.Add(new Person(21, "Someone")));
        }

        [Test]
        public void Add_ThrowIfUserAlreadyExistsWithTheGivenuserName()
        {
            Person person = new Person(1, "Ivan");
            extendedDb.Add(person);

            Assert.Throws<InvalidOperationException>(() => extendedDb.Add(new Person(12, "Ivan")));
        }

        [Test]
        public void Add_ThrowIfUserAlreadyExistsWithTheGivenId()
        {
            Person person = new Person(1, "Gosho");
            extendedDb.Add(person);

            Assert.Throws<InvalidOperationException>(() => extendedDb.Add(new Person(1, "Ivan")));
        }

        [Test]
        public void Add_WorkingProperlyCheck()
        {
            Person[] people = new Person[5];
            for (int i = 0; i < people.Length; i++)
            {
                extendedDb.Add(new Person(i, $"UserName: {i}"));
            }

            Assert.That(extendedDb.Count, Is.EqualTo(people.Length));
        }

        [Test]
        public void Remove_ThrowExceptionZero()
        {
            Assert.Throws<InvalidOperationException>(() => extendedDb.Remove());
        }

        [Test]
        public void Remove_WorkingProperly()
        {
            Person[] people = new Person[5];
            for (int i = 0; i < people.Length; i++)
            {
                extendedDb.Add(new Person(i, $"UserName: {i}"));
            }
            extendedDb.Remove();

            Assert.That(extendedDb.Count, Is.EqualTo(people.Length - 1));
        }

        [Test]
        public void FindByUsername_UserNameNull()
        {
            Assert.Throws<ArgumentNullException>(() => extendedDb.FindByUsername(null));
        }

        [Test]
        public void FindByUsername_AlreadyExisted()
        {
            extendedDb.Add(new Person(1, "Gosho"));

            Assert.Throws<InvalidOperationException>(() => extendedDb.FindByUsername("Ivan"));
        }

        [Test]
        public void FindByUsername_WorkingProperly()
        {
            Person person = new Person(1, "Gosho");
            extendedDb.Add(person);
            Person selectedPerson = extendedDb.FindByUsername("Gosho");

            Assert.That(selectedPerson, Is.EqualTo(person));
        }

        [Test]
        public void FindById_NegativeIdExceptionCheck()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => extendedDb.FindById(-5));
        }

        [Test]
        public void FindById_UnExistedUser()
        {
            Assert.Throws<InvalidOperationException>(() => extendedDb.FindById(5));
        }

        [Test]
        public void FindById_PositiveResult()
        {
            Person person = new Person(1, "Pesho");
            extendedDb.Add(person);
            var selectedPerson = extendedDb.FindById(1);

            Assert.That(selectedPerson, Is.EqualTo(person));
        }
    }
}