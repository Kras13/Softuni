using System;
using System.Linq;

namespace _05.SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string snake = Console.ReadLine();
            char[,] matrix = new char[size[0], size[1]];

            int pointer = 0;

            for (int row = 0; row < size[0]; row++)
            {
                for (int col = 0; col < size[1]; col++)
                {
                    if (row % 2 == 0)
                    {
                        matrix[row, col] = snake[pointer++];
                    }
                    else
                    {
                        matrix[row, size[1] - col - 1] = snake[pointer++];
                    }

                    if (pointer == snake.Length)
                    {
                        pointer = 0;
                    }
                }
            }

            for (int row = 0; row < size[0]; row++)
            {
                for (int col = 0; col < size[1]; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
