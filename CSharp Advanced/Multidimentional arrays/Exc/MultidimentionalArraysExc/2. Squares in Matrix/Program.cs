using System;
using System.Linq;

namespace _2._Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            string[,] charMatrix = ReadMatrixConsole(rows, cols);

            int count = 0;

            for (int row = 0; row < charMatrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < charMatrix.GetLength(1) - 1; col++)
                {
                    if (charMatrix[row, col] == charMatrix[row, col + 1]
                        && charMatrix[row, col] == charMatrix[row + 1, col]
                        && charMatrix[row, col] == charMatrix[row + 1, col + 1])
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }

        private static string[,] ReadMatrixConsole(int n, int c)
        {
            string[,] result = new string[n, c];

            for (int row = 0; row < n; row++)
            {
                string[] valuesRow = Console.ReadLine()
                    .Split(' ')
                    .ToArray();

                for (int col = 0; col < c; col++)
                {
                    result[row, col] = valuesRow[col];
                }
            }

            return result;
        }

    }
}
