using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> calc = new Stack<string>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .ToArray()
                );

            while (calc.Count > 1)
            {
                int a = int.Parse(calc.Pop());
                string oper = calc.Pop();
                int b = int.Parse(calc.Pop());

                if (oper == "+")
                {
                    calc.Push((a + b).ToString());
                }
                else
                {
                    calc.Push((a - b).ToString());
                }
            }

            Console.WriteLine(calc.Pop());
        }
    }
}
