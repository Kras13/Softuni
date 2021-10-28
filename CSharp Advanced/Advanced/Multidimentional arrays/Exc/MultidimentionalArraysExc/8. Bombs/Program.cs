using System;
using System.Linq;

namespace _8._Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                int[] line = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            string[] bombCoordinates = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < bombCoordinates.Length; i++)
            {
                string bomb = bombCoordinates[i];

                int rowBomb = int.Parse(bomb[0].ToString());
                int colBomb = int.Parse(bomb[2].ToString());

                if (IsIndexValid(rowBomb, colBomb, matrix.GetLength(0)) && matrix[rowBomb, colBomb] > 0)
                {
                    int bombValue = matrix[rowBomb, colBomb];
                    matrix[rowBomb, colBomb] = 0;

                    BombExplode(rowBomb, colBomb, matrix, bombValue);
                }

            }

            int aliveCount = 0;
            int sum = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        aliveCount++;
                        sum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine("Alive cells: {0}", aliveCount);
            Console.WriteLine("Sum: {0}", sum);

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void BombExplode(int rowBomb, int colBomb, int[,] matrix, int bombValue)
        {
            if (IsIndexValid(rowBomb - 1, colBomb - 1, matrix.GetLength(0)) && matrix[rowBomb - 1, colBomb - 1] > 0)
            {
                matrix[rowBomb - 1, colBomb - 1] -= bombValue;
            }

            if (IsIndexValid(rowBomb - 1, colBomb, matrix.GetLength(0)) && matrix[rowBomb - 1, colBomb] > 0)
            {
                matrix[rowBomb - 1, colBomb] -= bombValue;
            }

            if (IsIndexValid(rowBomb - 1, colBomb + 1, matrix.GetLength(0)) && matrix[rowBomb - 1, colBomb + 1] > 0)
            {
                matrix[rowBomb - 1, colBomb + 1] -= bombValue;
            }

            if (IsIndexValid(rowBomb, colBomb - 1, matrix.GetLength(0)) && matrix[rowBomb, colBomb - 1] > 0)
            {
                matrix[rowBomb, colBomb - 1] -= bombValue;
            }

            if (IsIndexValid(rowBomb, colBomb + 1, matrix.GetLength(0)) && matrix[rowBomb, colBomb + 1] > 0)
            {
                matrix[rowBomb, colBomb + 1] -= bombValue;
            }

            if (IsIndexValid(rowBomb + 1, colBomb - 1, matrix.GetLength(0)) && matrix[rowBomb + 1, colBomb - 1] > 0)
            {
                matrix[rowBomb + 1, colBomb - 1] -= bombValue;
            }

            if (IsIndexValid(rowBomb + 1, colBomb, matrix.GetLength(0)) && matrix[rowBomb + 1, colBomb] > 0)
            {
                matrix[rowBomb + 1, colBomb] -= bombValue;
            }

            if (IsIndexValid(rowBomb + 1, colBomb + 1, matrix.GetLength(0)) && matrix[rowBomb + 1, colBomb + 1] > 0)
            {
                matrix[rowBomb + 1, colBomb + 1] -= bombValue;
            }
        }

        private static bool IsIndexValid(int rowBomb, int colBomb, int lenght)
        {
            return rowBomb >= 0 && rowBomb < lenght && colBomb >= 0 && colBomb < lenght;
        }
    }
}
