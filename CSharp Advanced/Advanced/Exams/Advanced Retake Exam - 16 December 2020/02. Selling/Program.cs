using System;

namespace _02._Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int playerRow = 0;
            int playerCol = 0;
            double money = 0;
            bool outGone = false;

            for (int row = 0; row < n; row++)
            {
                string line = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = line[col];

                    if (matrix[row, col] == 'S')
                    {
                        playerRow = row;
                        playerCol = col;
                        matrix[row, col] = '-';
                    }
                }
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "right")
                {
                    if (!IsValid(playerRow, playerCol + 1, n))
                    {
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        Console.WriteLine("Money: {0}", money);
                        outGone = true;
                        matrix[playerRow, playerCol] = '-';
                        PrintMatrix(matrix);
                        break;
                    }
                    matrix[playerRow, playerCol] = '-';

                    if (matrix[playerRow, playerCol + 1] == 'O')
                    {
                        matrix[playerRow, playerCol + 1] = '-';
                        MoveByZero(matrix, ref playerRow, ref playerCol);
                    }
                    else if (matrix[playerRow, playerCol + 1] == '-')
                    {
                        playerCol++;
                    }
                    else
                    {
                        money += int.Parse(matrix[playerRow, playerCol + 1].ToString());
                        playerCol++;
                    }
                }
                else if (command == "left")
                {
                    // Move left
                    if (!IsValid(playerRow, playerCol - 1, n))
                    {
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        Console.WriteLine("Money: {0}", money);
                        outGone = true;
                        matrix[playerRow, playerCol] = '-';
                        PrintMatrix(matrix);
                        break;
                    }
                    matrix[playerRow, playerCol] = '-';
                    if (matrix[playerRow, playerCol - 1] == 'O')
                    {
                        matrix[playerRow, playerCol - 1] = '-';
                        MoveByZero(matrix, ref playerRow, ref playerCol);
                    }
                    else if (matrix[playerRow, playerCol - 1] == '-')
                    {
                        playerCol--;
                    }
                    else
                    {
                        money += int.Parse(matrix[playerRow, playerCol - 1].ToString());
                        playerCol--;
                    }
                }
                else if (command == "up")
                {
                    // Move up
                    if (!IsValid(playerRow - 1, playerCol, n))
                    {
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        Console.WriteLine("Money: {0}", money);
                        outGone = true;
                        matrix[playerRow, playerCol] = '-';
                        PrintMatrix(matrix);
                        break;
                    }
                    matrix[playerRow, playerCol] = '-';

                    if (matrix[playerRow - 1, playerCol] == 'O')
                    {
                        matrix[playerRow - 1, playerCol] = '-';
                        MoveByZero(matrix, ref playerRow, ref playerCol);
                    }
                    else if (matrix[playerRow - 1, playerCol] == '-')
                    {
                        playerRow--;
                    }
                    else
                    {
                        money += int.Parse(matrix[playerRow - 1, playerCol].ToString());
                        playerRow--;
                    }
                }
                else if (command == "down")
                {
                    if (!IsValid(playerRow + 1, playerCol, n))
                    {
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        Console.WriteLine("Money: {0}", money);
                        outGone = true;
                        matrix[playerRow, playerCol] = '-';
                        PrintMatrix(matrix);
                        break;
                    }

                    matrix[playerRow, playerCol] = '-';

                    if (matrix[playerRow + 1, playerCol] == 'O')
                    {
                        matrix[playerRow + 1, playerCol] = '-';
                        MoveByZero(matrix, ref playerRow, ref playerCol);
                    }
                    else if (matrix[playerRow + 1, playerCol] == '-')
                    {
                        playerRow++;
                    }
                    else
                    {
                        money += int.Parse(matrix[playerRow + 1, playerCol].ToString());
                        playerRow++;
                    }
                }

                if (money >= 50)
                {
                    break;
                }
            }

            if (!outGone)
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
                Console.WriteLine("Money: {0}", money);
                matrix[playerRow, playerCol] = 'S';
                PrintMatrix(matrix);
            }
        }
        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static bool IsValid(int row, int col, int n)
        {
            return row >= 0 && row < n && col >= 0 && col < n;
        }

        private static void MoveByZero(char[,] matrix, ref int playerRow, ref int playerCol)
        {
            bool flag = false;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'O')
                    {
                        playerRow = row;
                        playerCol = col;
                        matrix[row, col] = '-';
                        flag = true;
                        break;
                    }
                }
                if (flag)
                {
                    break;
                }
            }
        }
    }
}
