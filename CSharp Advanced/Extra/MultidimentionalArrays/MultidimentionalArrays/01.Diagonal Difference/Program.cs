using System;
using System.Linq;

namespace _01.Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[] diagonalsSum = new int[2];

            for (int i = 0; i < size; i++)
            {
                int[] currentLine = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                diagonalsSum[0] += currentLine[i];
                diagonalsSum[1] += currentLine[size - i - 1];
            }

            Console.WriteLine(Math.Abs(diagonalsSum[0] - diagonalsSum[1]));
        }
    }
}
