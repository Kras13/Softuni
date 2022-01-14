using NUnit.Framework;
using System;

namespace Tests
{
    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void Setup()
        {
            database = new Database();
        }

        [Test]
        public void Ctor_ThrowExceptionWhenDbCapacityIsExceeded()
        {
            Assert.Throws<InvalidOperationException>(
                () => database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17));
        }

        [Test]
        public void Ctor_AddValidElementToDb()
        {
            var elements = new int[] { 1, 2, 3 };
            database = new Database(elements);
            Assert.That(database.Count, Is.EqualTo(elements.Length));
        }

        [Test]
        public void Add_ThrowExceptionWhenAddingOverCapacity()
        {
            int n = 16;
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = i + 1;
            }

            database = new Database(array);

            Assert.Throws<InvalidOperationException>(() => database.Add(17));
        }

        [Test]
        public void Add_IncrementCountWheenAddIsvalid()
        {
            int n = 5;

            for (int i = 0; i < n; i++)
            {
                database.Add(i);
            }

            Assert.That(database.Count, Is.EqualTo(n));
        }

        [Test]
        public void Remove_ThroException()
        {
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void Remove_Positivetest()
        {
            database = new Database(new int[] { 1, 2, 3, 4 });
            database.Remove();

            Assert.That(database.Count, Is.EqualTo(3));
        }

        [Test]
        public void Fetch_TestReference()
        {
            database = new Database(new int[] { 1, 2, 3, 4, 5 });
            int[] first = database.Fetch();
            database.Remove();

            Assert.That(database.Count, Is.Not.EqualTo(first.Length));
        }
    }
}