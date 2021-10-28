using System;

namespace _7._Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                char[] charArray = Console.ReadLine().ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = charArray[col];
                }
            }

            int killedKnights = 0;
            while (true)
            {
                int knightRow = -1;
                int knightCol = -1;
                int maxAttack = 0; //first we remove the worst ones

                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
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
