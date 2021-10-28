using System;

namespace _5._Square_With_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] line = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            int rows = int.Parse(line[0]);
            int cols = int.Parse(line[1]);

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = int.Parse(input[col]);
                }
            }

            int bestSum = 0;
            int bestRow = -1;
            int bestCol = -1;

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    int currentSum =
                        matrix[row, col]
                        + matrix[row, col + 1]
                        + matrix[row + 1, col]
                        + matrix[row + 1, col + 1];

                    if (currentSum > bestSum)
                    {
                        bestSum = currentSum;
                        bestRow = row;
                        bestCol = col;
                    }
                }
            }

            Console.WriteLine($"{matrix[bestRow, bestCol]} {matrix[bestRow, bestCol + 1]}");
            Console.WriteLine($"{matrix[bestRow + 1, bestCol]} {matrix[bestRow + 1, bestCol + 1]}");
            Console.WriteLine(bestSum);
        }
    }
}
