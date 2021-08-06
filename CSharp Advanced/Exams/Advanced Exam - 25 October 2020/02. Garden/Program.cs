using System;
using System.Linq;

namespace _02._Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            int[,] matrix = new int[rows, cols];

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Bloom Bloom Plow")
                {
                    break;
                }

                int[] commands = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int currentRow = commands[0];
                int currentCol = commands[1];

                if (currentRow < 0 || currentRow > rows || currentCol < 0 || currentCol > cols)
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }

                SpreadFlowersInMatrix(matrix, currentRow, currentCol);
            }

            PrintMatrix(matrix);

            //for (int row = 0; row < rows; row++)
            //{
            //    for (int col = 0; col < cols; col++)
            //    {
            //        Console.Write(matrix[row,col]);
            //    }
            //    Console.WriteLine();
            //}
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                } 

                Console.WriteLine();
            }
        }

        private static void SpreadFlowersInMatrix(int[,] matrix, int currentRow, int currentCol)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row == currentRow)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col]++;
                    }
                }
                matrix[row, currentCol]++;
            }
            matrix[currentRow, currentCol]--;
        }
    }
}
