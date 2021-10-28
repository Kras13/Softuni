using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Matrix_Shuffling
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

            string word = Console.ReadLine();
            Queue<char> snake = new Queue<char>(word);
            int count = 0;

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {

                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (count == word.Length)
                        {
                            count = 0;
                            snake = new Queue<char>(word);
                        }

                        matrix[row, col] = snake.Dequeue();
                        count++;
                    }
                }
                else
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        if (count == word.Length)
                        {
                            count = 0;
                            snake = new Queue<char>(word);
                        }

                        matrix[row, col] = snake.Dequeue();
                        count++;
                    }
                }

                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }

        }
    }
}
