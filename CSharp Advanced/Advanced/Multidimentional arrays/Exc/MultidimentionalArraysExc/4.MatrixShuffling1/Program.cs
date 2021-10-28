using System;
using System.Linq;

namespace _4.MatrixShuffling1
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

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "END")
                {
                    break;
                }

                string[] lineValues = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (lineValues.Length != 5 || lineValues[0] != "swap")
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                else
                {
                    int firstRow = int.Parse(lineValues[1]);
                    int firstCol = int.Parse(lineValues[2]);

                    int secondRow = int.Parse(lineValues[3]);
                    int secondCol = int.Parse(lineValues[4]);

                    if (firstRow >= rows || firstRow < 0 || secondRow >= rows || secondRow < 0
                        || firstCol >= cols || firstCol < 0 || secondCol >= cols || secondCol < 0
                        )
                    {
                        Console.WriteLine("Invalid input!");
                        continue;
                    }

                    string tempValue = matrix[firstRow, firstCol];
                    matrix[firstRow, firstCol] = matrix[secondRow, secondCol];
                    matrix[secondRow, secondCol] = tempValue;
                    PrintMatrix(rows, cols, matrix);
                }
            }

            //PrintMatrix(rows, cols, matrix);
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
