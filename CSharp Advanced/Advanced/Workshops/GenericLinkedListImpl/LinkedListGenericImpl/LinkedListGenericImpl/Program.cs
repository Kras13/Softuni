using System;

namespace LinkedListGenericImpl
{
    class Program
    {
        static void Main(string[] args)
        {
            MyLinkedList myList = new MyLinkedList();

            myList.AddLast(5);
            myList.AddLast(10);
            myList.AddLast(15);

            int[] array = myList.ToArray();

            Console.WriteLine(string.Join(' ', array));
        }
    }
}
