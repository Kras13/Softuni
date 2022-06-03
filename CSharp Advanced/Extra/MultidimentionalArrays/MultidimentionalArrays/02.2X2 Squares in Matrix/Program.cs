using System;
using System.Linq;

namespace _02._2X2_Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            const int squareRowLimit = 2;
            const int squareColLimit = 2;

            int[] size = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(e => int.Parse(e))
                .ToArray();

            int row = size[0];
            int col = size[1];

            char[,] matrix = InitMatrix(row, col);
            int result = NumberOfEqualSquares(matrix, squareRowLimit, squareColLimit);

            Console.WriteLine(result);
        }

        private static int NumberOfEqualSquares(
            char[,] matrix, int squareRowLimit, int squareColLimit)
        {
            int result = 0;

            for (int row = 0; row <= matrix.GetLength(0) - squareRowLimit; row ++)
            {
                for (int col = 0; col <= matrix.GetLength(1) - squareColLimit; col ++)
                {
                    if (matrix[row, col] == matrix[row, col + 1] &&
                        matrix[row, col] == matrix[row + 1, col] &&
                        matrix[row, col] == matrix[row + 1, col + 1])
                    {
                        result++;
                    }
                }
            }

            return result;
        }

        private static char[,] InitMatrix(int row, int col)
        {
            char[,] result = new char[row, col];

            for (int i = 0; i < row; i++)
            {
                char[] currentLine = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(e => char.Parse(e))
                    .ToArray();

                for (int k = 0; k < col; k++)
                {
                    result[i, k] = currentLine[k];
                }
            }

            return result;
        }
    }
}
