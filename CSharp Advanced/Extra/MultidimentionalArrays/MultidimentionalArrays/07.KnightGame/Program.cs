using System;
using System.Linq;

namespace _07.KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = rows;

            char[,] matrix = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                char[] line = Console.ReadLine()
                    .ToCharArray();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = line[j];
                }
            }

            int killedKnights = 0;
            while (true)
            {
                int knightRow = -1;
                int knightCol = -1;
                int maxAttack = 0; //first we remove the worst ones

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == 'K')
                        {
                            int tempAttack = CountAttacks(matrix, row, col);

                            if (tempAttack > maxAttack)
                            {
                                maxAttack = tempAttack;
                                knightRow = row;
                                knightCol = col;
                            }
                        }
                    }
                }

                if (maxAttack > 0)
                {
                    matrix[knightRow, knightCol] = '0';
                    killedKnights++;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(killedKnights);
        }

        private static int CountAttacks(char[,] matrix, int row, int col)
        {
            int attacks = 0;

            //first type
            if (IsIndexValid(matrix.Length, row - 1, col - 2) && matrix[row - 1, col - 2] == 'K')
            {
                attacks++;
            }

            if (IsIndexValid(matrix.GetLength(0), row - 1, col + 2) && matrix[row - 1, col + 2] == 'K')
            {
                attacks++;
            }

            if (IsIndexValid(matrix.GetLength(0), row + 1, col - 2) && matrix[row + 1, col - 2] == 'K')
            {
                attacks++;
            }

            if (IsIndexValid(matrix.GetLength(0), row + 1, col + 2) && matrix[row + 1, col + 2] == 'K')
            {
                attacks++;
            }

            //second type
            if (IsIndexValid(matrix.GetLength(0), row - 2, col - 1) && matrix[row - 2, col - 1] == 'K')
            {
                attacks++;
            }

            if (IsIndexValid(matrix.GetLength(0), row - 2, col + 1) && matrix[row - 2, col + 1] == 'K')
            {
                attacks++;
            }

            if (IsIndexValid(matrix.GetLength(0), row + 2, col - 1) && matrix[row + 2, col - 1] == 'K')
            {
                attacks++;
            }

            if (IsIndexValid(matrix.GetLength(0), row + 2, col + 1) && matrix[row + 2, col + 1] == 'K')
            {
                attacks++;
            }

            return attacks;
        }

        private static bool IsIndexValid(int matrixLength, int row, int col)
        {
            return row >= 0 && col >= 0 && row < matrixLength && col < matrixLength;
        }
    }
}
