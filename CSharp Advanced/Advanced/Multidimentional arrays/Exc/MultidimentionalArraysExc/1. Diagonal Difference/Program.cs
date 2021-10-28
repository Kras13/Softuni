using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = ReadMatrixConsole(n, n);

            int sumMainDiagonal = 0;
            int sumSecondDiagonal = 0;

            for (int row = 0; row < n; row++)
            {
                sumMainDiagonal += matrix[row, row];
                sumSecondDiagonal += matrix[row, n - row - 1];
            }

            Console.WriteLine(Math.Abs(sumMainDiagonal - sumSecondDiagonal));
        }

        private static int[,] ReadMatrixConsole(int n, int c)
        {
            int[,] result = new int[n, c];

            for (int row = 0; row < n; row++)
            {
                int[] valuesRow = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
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
