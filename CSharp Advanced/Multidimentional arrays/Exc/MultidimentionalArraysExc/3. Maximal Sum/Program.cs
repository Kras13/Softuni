using System;
using System.Linq;

namespace _3._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            int[,] matrix = ReadMatrixConsole(rows, cols);

            int bestSum = int.MinValue;
            int bestRow = 0;
            int bestCol = 0;

            for (int row = 0; row < rows - 2; row++)
            {

                for (int col = 0; col < cols - 2; col++)
                {
                    int sumFirstRow = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2];
                    int sumSecondRow = matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2];
                    int sumThirdRow = matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                    int currentSum = sumFirstRow + sumSecondRow + sumThirdRow;

                    if (currentSum > bestSum)
                    {
                        bestRow = row;
                        bestCol = col;
                        bestSum = currentSum;
                    }
                }
            }

            Console.WriteLine("Sum = {0}", bestSum);

            for (int row = bestRow; row <= bestRow + 2; row++)
            {
                for (int col = bestCol; col <= bestCol + 2; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }

        }
        private static int[,] ReadMatrixConsole(int n, int c)
        {
            int[,] result = new int[n, c];

            for (int row = 0; row < n; row++)
            {
                int[] valuesRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
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
