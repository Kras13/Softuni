using System;

namespace Re_Volt2
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
                        matrix[playerRow, playerCol] = '-';
                        CheckForOutsideTheBoundary(matrix, ref playerRow, ref playerCol, command, ref wonGame);
                    }
                    else
                    {
                        matrix[playerRow, playerCol] = '-';
                        playerRow++;

                        if (matrix[playerRow, playerCol] == 'T')
                        {
                            playerRow--;
                        }
                        else if (matrix[playerRow, playerCol] == 'B')
                        {
                            playerRow++;
                            if (playerRow >= n)
                            {
                                CheckForOutsideTheBoundary(matrix, ref playerRow, ref playerCol, command, ref wonGame);
                            }
                        }
                        else if (matrix[playerRow, playerCol] == 'F')
                        {
                            wonGame = true;
                            matrix[playerRow, playerCol] = 'f';
                            break;
                        }

                        matrix[playerRow, playerCol] = 'f';
                    }
                }
                else if (command == "up")
                {
                    if (playerRow - 1 < 0)
                    {
                        matrix[playerRow, playerCol] = '-';
                        CheckForOutsideTheBoundary(matrix, ref playerRow, ref playerCol, command, ref wonGame);
                    }
                    else
                    {
                        matrix[playerRow, playerCol] = '-';
                        playerRow--;

                        if (matrix[playerRow, playerCol] == 'T')
                        {
                            playerRow++;
                        }
                        else if (matrix[playerRow, playerCol] == 'B')
                        {
                            playerRow--;
                            if (playerRow < 0)
                            {
                                CheckForOutsideTheBoundary(matrix, ref playerRow, ref playerCol, command, ref wonGame);
                            }
                        }
                        else if (matrix[playerRow, playerCol] == 'F')
                        {
                            wonGame = true;
                            matrix[playerRow, playerCol] = 'f';
                            break;
                        }

                        matrix[playerRow, playerCol] = 'f';
                    }
                }
                else if (command == "left")
                {
                    if (playerCol - 1 < 0)
                    {
                        matrix[playerRow, playerCol] = '-';
                        CheckForOutsideTheBoundary(matrix, ref playerRow, ref playerCol, command, ref wonGame);
                    }
                    else
                    {
                        matrix[playerRow, playerCol] = '-';
                        playerCol--;

                        if (matrix[playerRow, playerCol] == 'T')
                        {
                            playerCol++;
                        }
                        else if (matrix[playerRow, playerCol] == 'B')
                        {
                            playerCol--;
                            if (playerCol < 0)
                            {
                                CheckForOutsideTheBoundary(matrix, ref playerRow, ref playerCol, command, ref wonGame);
                            }
                        }
                        else if (matrix[playerRow, playerCol] == 'F')
                        {
                            wonGame = true;
                            matrix[playerRow, playerCol] = 'f';
                            break;
                        }

                        matrix[playerRow, playerCol] = 'f';
                    }
                }
                else if (command == "right")
                {
                    if (playerCol + 1 >= n)
                    {
                        matrix[playerRow, playerCol] = '-';
                        CheckForOutsideTheBoundary(matrix, ref playerRow, ref playerCol, command, ref wonGame);
                    }
                    else
                    {
                        matrix[playerRow, playerCol] = '-';
                        playerCol++;

                        if (matrix[playerRow, playerCol] == 'T')
                        {
                            playerCol--;
                        }
                        else if (matrix[playerRow, playerCol] == 'B')
                        {
                            playerCol++;
                            if (playerCol >= n)
                            {
                                CheckForOutsideTheBoundary(matrix, ref playerRow, ref playerCol, command, ref wonGame);
                            }
                        }
                        else if (matrix[playerRow, playerCol] == 'F')
                        {
                            wonGame = true;
                            matrix[playerRow, playerCol] = 'f';
                            break;
                        }

                        matrix[playerRow, playerCol] = 'f';
                    }
                }

                if (wonGame)
                {
                    break;
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

        static void CheckForOutsideTheBoundary(char[,] matrix, ref int playerRow, ref int playerCol, string command, ref bool wonGame)
        {
            int n = matrix.GetLength(0);

            if (command == "down")
            {
                playerRow = 0;

                if (matrix[playerRow, playerCol] == 'T')
                {
                    playerRow = n - 1;
                    return;
                }

                if (matrix[playerRow, playerCol] == 'F')
                {
                    wonGame = true;
                    matrix[playerRow, playerCol] = 'f';
                }
                if (matrix[playerRow, playerCol] == 'B')
                {
                    playerRow++;
                }

                matrix[playerRow, playerCol] = 'f';
            }
            else if (command == "up")
            {
                playerRow = n - 1;

                if (matrix[playerRow, playerCol] == 'T')
                {
                    playerRow = 0;
                    return;
                }


                if (matrix[playerRow, playerCol] == 'F')
                {
                    wonGame = true;
                    matrix[playerRow, playerCol] = 'f';
                }
                if (matrix[playerRow, playerCol] == 'B')
                {
                    playerRow--;
                }

                matrix[playerRow, playerCol] = 'f';
            }
            else if (command == "right")
            {
                playerCol = 0;

                if (matrix[playerRow, playerCol] == 'T')
                {
                    playerCol = n - 1;
                    return;
                }


                if (matrix[playerRow, playerCol] == 'F')
                {
                    wonGame = true;
                    matrix[playerRow, playerCol] = 'f';
                }
                if (matrix[playerRow, playerCol] == 'B')
                {
                    playerCol++;
                }

                matrix[playerRow, playerCol] = 'f';
            }
            else if (command == "left")
            {
                playerCol = n - 1;

                if (matrix[playerRow, playerCol] == 'T')
                {
                    playerCol = 0;
                    return;
                }

                if (matrix[playerRow, playerCol] == 'F')
                {
                    wonGame = true;
                    matrix[playerRow, playerCol] = 'f';
                }
                if (matrix[playerRow, playerCol] == 'B')
                {
                    playerCol--;
                }

                matrix[playerRow, playerCol] = 'f';
            }
        }
    }
}
