using System;
using System.Linq;

namespace _03.MaximalSum
{
    class Program
    {
        private const int rowLimit = 3;
        private const int colLimit = 3;

        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = size[0];
            int cols = size[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] line = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            int bestMax = 0;
            int bestRow = 0;
            int bestCol = 0;

            for (int row = 0; row < rows - (rowLimit - 1); row++)
            {
                for (int col = 0; col < cols - (colLimit - 1); col++)
                {
                    int currentBest = FindCurrentBest(matrix, row, col);

                    if (currentBest > bestMax)
                    {
                        bestMax = currentBest;
                        bestRow = row;
                        bestCol = col;
                    }
                }
            }

            Console.WriteLine("Sum = {0}", bestMax);

            for (int row = 0; row < rowLimit; row++)
            {
                int[] currentLineValues = new int[colLimit];

                for (int col = 0; col < colLimit; col++)
                {
                    currentLineValues[col] = matrix[row + bestRow, col + bestCol];
                }

                Console.WriteLine(string.Join(' ', currentLineValues));
            }
        }

        private static int FindCurrentBest(int[,] matrix, int row, int col)
        {
            int result = 0;

            for (int i = 0; i < rowLimit; i++)
            {
                for (int k = 0; k < colLimit; k++)
                {
                    result += matrix[i + row, k + col];
                }
            }

            return result;
        }
    }
}
