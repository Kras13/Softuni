using System;

namespace DynamicArrayImpl
{
    class Program
    {
        static void Main(string[] args)
        {
            //MyList<int> myList = new MyList<int>();

            //myList.AddElement(5);
            //myList.AddElement(5);
            //myList.AddElement(5);
            //myList.AddElement(5);
            //myList.AddElement(5);
            //myList.AddElement(5);
            //myList.AddElement(5);
            //myList.AddElement(5);

            //for (int i = 0; i < myList.Count; i++)
            //{
            //    Console.WriteLine(myList[i]);
            //}

            //int[] arr = myList.ToArray();
            //Console.WriteLine();
            //foreach (var element in arr)
            //{
            //    Console.WriteLine(element);
            //}

            MyList<string> myList = new MyList<string>(new string[] { "Sasho", "Pesho", "Misho" });

            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }

        }
    }
}
