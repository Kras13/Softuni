using System;
using System.Collections.Generic;

namespace _4._Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            Stack<int> numbers = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    numbers.Push(i);
                }
                else if (expression[i] == ')')
                {
                    int startIndex = numbers.Pop();

                    Console.WriteLine(expression.Substring(startIndex, i - startIndex + 1));
                }
            }

        }
    }
}
