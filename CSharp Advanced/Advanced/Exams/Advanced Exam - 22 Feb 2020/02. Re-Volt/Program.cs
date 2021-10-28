using System;
using System.Linq;

namespace _02._Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int commandsCount = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int playerRow = 0;
            int playerCol = 0;

            bool wonGame = false;

            for (int row = 0; row < n; row++)
            {
                char[] line = Console.ReadLine().ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = line[col];
                    if (matrix[row, col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            for (int i = 0; i < commandsCount; i++)
            {
                string command = Console.ReadLine();

                if (command == "down")
                {
                    if (playerRow + 1 >= n)
                    {
                        MoveTheWayOut(matrix, ref playerRow, ref playerCol, command,wonGame);
                    }
                    else if (matrix[playerRow + 1, playerCol] == 'B')
                    {
                        matrix[playerRow, playerCol] = '-';

                        if (playerRow + 2 >= n)
                        {
                            MoveTheWayOut(matrix, ref playerRow, ref playerCol, command, wonGame);
                        }
                        else
                        {
                            matrix[playerRow + 2, playerCol] = 'f';
                            playerRow += 2;
                        }
                    }
                    else if (matrix[playerRow + 1, playerCol] == 'F')
                    {
                        matrix[playerRow, playerCol] = '-';
                        matrix[playerRow + 1, playerCol] = 'f';
                        wonGame = true;
                        break;
                    }
                    else if (matrix[playerRow + 1, playerCol] == '-')
                    {
                        matrix[playerRow, playerCol] = '-';
                        matrix[playerRow + 1, playerCol] = 'f';
                        playerRow++;
                    }
                }
                else if (command == "up")
                {
                    if (playerRow - 1 < 0)
                    {
                        MoveTheWayOut(matrix, ref playerRow, ref playerCol, command, wonGame);
                    }
                    else if (matrix[playerRow - 1, playerCol] == 'B')
                    {
                        matrix[playerRow, playerCol] = '-';

                        if (playerRow + 2 < 0)
                        {
                            MoveTheWayOut(matrix, ref playerRow, ref playerCol, command, wonGame);
                        }
                        else
                        {
                            matrix[playerRow - 2, playerCol] = 'f';
                            playerRow -= 2;
                        }
                    }
                    else if (matrix[playerRow - 1, playerCol] == 'F')
                    {
                        matrix[playerRow, playerCol] = '-';
                        matrix[playerRow - 1, playerCol] = 'f';
                        wonGame = true;
                        break;
                    }
                    else if (matrix[playerRow - 1, playerCol] == '-')
                    {
                        matrix[playerRow, playerCol] = '-';
                        matrix[playerRow - 1, playerCol] = 'f';
                        playerRow--;
                    }
                }
                else if (command == "left")
                {
                    if (playerCol - 1 < 0)
                    {
                        MoveTheWayOut(matrix, ref playerRow, ref playerCol, command, wonGame);
                    }
                    else if (matrix[playerRow, playerCol - 1] == 'B')
                    {
                        matrix[playerRow, playerCol] = '-';

                        if (playerCol - 2 < 0)
                        {
                            MoveTheWayOut(matrix, ref playerRow, ref playerCol, command, wonGame);
                        }
                        else
                        {
                            matrix[playerRow, playerCol - 2] = 'f';
                            playerCol -= 2;
                        }
                    }
                    else if (matrix[playerRow, playerCol - 1] == 'F')
                    {
                        matrix[playerRow, playerCol] = '-';
                        matrix[playerRow, playerCol - 1] = 'f';
                        wonGame = true;
                        break;
                    }
                    else if (matrix[playerRow, playerCol - 1] == '-')
                    {
                        matrix[playerRow, playerCol] = '-';
                        matrix[playerRow, playerCol - 1] = 'f';
                        playerCol--;
                    }
                }
                else if (command == "right")
                {
                    if (playerCol + 1 >= n)
                    {
                        MoveTheWayOut(matrix, ref playerRow, ref playerCol, command, wonGame);
                    }
                    else if (matrix[playerRow, playerCol + 1] == 'B')
                    {
                        matrix[playerRow, playerCol] = '-';

                        if (playerCol + 2 >= n)
                        {
                            MoveTheWayOut(matrix, ref playerRow, ref playerCol, command, wonGame);
                        }
                        else
                        {
                            matrix[playerRow, playerCol + 2] = 'f';
                            playerCol += 2;
                        }
                    }
                    else if (matrix[playerRow, playerCol + 1] == 'F')
                    {
                        matrix[playerRow, playerCol] = '-';
                        matrix[playerRow, playerCol + 1] = 'f';
                        wonGame = true;
                        break;
                    }
                    else if (matrix[playerRow, playerCol + 1] == '-')
                    {
                        matrix[playerRow, playerCol] = '-';
                        matrix[playerRow, playerCol + 1] = 'f';
                        playerCol++;
                    }
                }
            }

            if (wonGame)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void MoveTheWayOut(char[,] matrix, ref int playerRow, ref int playerCol, string command, bool wonGame)
        {
            if (command == "down")
            {
                matrix[playerRow, playerCol] = '-';
                playerRow = 0;              
            }
            else if (command == "up")
            {
                matrix[playerRow, playerCol] = '-';
                playerRow = matrix.GetLength(0) - 1;
            }
            else if (command == "left")
            {
                matrix[playerRow, playerCol] = '-';
                playerCol = matrix.GetLength(1) - 1;
            }
            else if (command == "right")
            {
                matrix[playerRow, playerCol] = '-';
                playerCol = 0;
            }
            if (matrix[playerRow, playerCol] == 'F')
            {
                wonGame = true;
            }
        }
    }
}
