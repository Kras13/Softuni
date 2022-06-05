using System;
using System.Linq;

namespace _04.Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = 0;
            int cols = 0;

            string[,] matrix = ReadAndfillMatrix(ref rows, ref cols);

            while (true)
            {
                string[] line = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (line[0] == "END")
                {
                    break;
                }

                string command = line[0];

                if (line.Length < 5)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                if (command != "swap")
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                int originRow = int.Parse(line[1]);
                int originCol = int.Parse(line[2]);
                int newRow = int.Parse(line[3]);
                int newCol = int.Parse(line[4]);

                if (
                    originRow >= rows || originCol >= cols ||
                    newRow >= rows || newCol >= cols ||
                    originRow < 0 || originCol < 0 ||
                    newRow < 0 || newCol < 0
                    )
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                string tempElement = matrix[originRow, originCol];
                matrix[originRow, originCol] = matrix[newRow, newCol];
                matrix[newRow, newCol] = tempElement;

                PrintMatrix(rows, cols, matrix);
            }
        }

        private static string[,] ReadAndfillMatrix(ref int resRows, ref int resCols)
        {
            int[] size = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = size[0];
            int cols = size[1];

            resRows = rows;
            resCols = cols;

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] line = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            return matrix;
        }

        private static void PrintMatrix(int rows, int cols, string[,] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
