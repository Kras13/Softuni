using System;
using System.Linq;

namespace _3._Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> minNumber = n => n.Min();

            var num = Console.ReadLine()
                  .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                  .Select(int.Parse)
                  .Min();

            Console.WriteLine(num);
        }
    }
}
