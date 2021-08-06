using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            double[][] jaggedArr = new double[rows][];

            for (int row = 0; row < rows; row++)
            {
                int[] lineValues = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                jaggedArr[row] = new double[lineValues.Length];

                for (int col = 0; col < lineValues.Length; col++)
                {
                    jaggedArr[row][col] = lineValues[col];
                }
            }

            for (int row = 0; row < rows - 1; row++)
            {
                if (jaggedArr[row].Length == jaggedArr[row + 1].Length)
                {
                    for (int col = 0; col < jaggedArr[row].Length; col++)
                    {
                        jaggedArr[row][col] *= 2;
                    }

                    for (int col = 0; col < jaggedArr[row + 1].Length; col++)
                    {
                        jaggedArr[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < jaggedArr[row].Length; col++)
                    {
                        jaggedArr[row][col] = jaggedArr[row][col] / 2;
                    }
                    for (int col = 0; col < jaggedArr[row + 1].Length; col++)
                    {
                        jaggedArr[row + 1][col] = jaggedArr[row + 1][col] / 2;
                    }
                }
            }

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                string[] lineValues = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (lineValues[0] == "Add")
                {
                    int row = int.Parse(lineValues[1]);
                    int col = int.Parse(lineValues[2]);
                    int value = int.Parse(lineValues[3]);

                    if (row < 0 || row >= rows || col >= jaggedArr[row].Length || col < 0)
                    {
                        continue;
                    }

                    jaggedArr[row][col] += value;
                }
                else if (lineValues[0] == "Subtract")
                {
                    int row = int.Parse(lineValues[1]);
                    int col = int.Parse(lineValues[2]);
                    int value = int.Parse(lineValues[3]);

                    if (row < 0 || row >= rows || col >= jaggedArr[row].Length || col < 0)
                    {
                        continue;
                    }

                    jaggedArr[row][col] -= value;
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < jaggedArr[row].Length; col++)
                {
                    Console.Write(jaggedArr[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
