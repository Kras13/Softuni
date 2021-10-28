using System;

namespace _02.Sneaking
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            string line = Console.ReadLine();
            string[,] matrix = new string[rows, line.Length];

            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = line[col].ToString();

                    if (matrix[row, col] == "S")
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }

                if (row < rows - 1)
                {
                    line = Console.ReadLine();
                }
            }

            string commands = Console.ReadLine();
            int cols = matrix.GetLength(1);

            bool flagEnd = false;

            for (int i = 0; i < commands.Length; i++)
            {
                string command = commands[i].ToString();

                for (int row = 0; row < rows; row++)
                {
                    bool mooved = false;
                    for (int col = 0; col < cols; col++)
                    {
                        if (matrix[row, col] == "b")
                        {
                            //if (matrix[row, col + 1] == "S")
                            //{
                            //    Console.WriteLine("Sam died at {0}, {1}", playerRow, playerCol);
                            //    matrix[row, col] = ".";
                            //    matrix[row, col + 1] = "X";
                            //    flagEnd = true;
                            //    break;
                            //}
                            //if (IsValidIndex(col + 2, matrix))
                            //{
                            //    if (matrix[row, col + 2] == "S")
                            //    {
                            //        Console.WriteLine("Sam died at {0}, {1}", playerRow, playerCol);
                            //        matrix[row, col] = ".";
                            //        matrix[row, col + 1] = "X";

                            //    }
                            //}

                            flagEnd = true;
                            break;


                            if (matrix[row, col + 1] == ".")
                            {
                                if (IsAtEdgeRight(col + 1, matrix))
                                {
                                    matrix[row, col + 1] = "Ds";
                                    matrix[row, col] = ".";
                                    mooved = true;
                                }
                                else
                                {
                                    matrix[row, col] = ".";
                                    matrix[row, col + 1] = "b";
                                    mooved = true;
                                }
                            }
                        }
                        else if (matrix[row, col] == "d")
                        {
                            if (matrix[row, col - 1] == "S")
                            {
                                Console.WriteLine("Sam died at {0}, {1}", playerRow, playerCol);
                                matrix[row, col] = ".";
                                matrix[row, col - 1] = "X";
                                flagEnd = true;
                                break;
                            }
                            if (IsValidIndex(col - 2, matrix))
                            {
                                if (matrix[row, col - 2] == "S")
                                {
                                    Console.WriteLine("Sam died at {0}, {1}", playerRow, playerCol);
                                    matrix[row, col] = ".";
                                    matrix[row, col - 1] = "X";
                                    flagEnd = true;
                                    break;
                                }
                            }
                            if (matrix[row, col - 1] == ".")
                            {
                                if (IsAtEdgeLeft(col - 1))
                                {
                                    matrix[row, col - 1] = "Bs";
                                    matrix[row, col] = ".";
                                    mooved = true;
                                }
                                else
                                {
                                    matrix[row, col] = ".";
                                    matrix[row, col - 1] = "d";
                                    mooved = true;
                                }
                            }
                        }
                        if (mooved)
                        {
                            break;
                        }
                    }
                    if (flagEnd)
                    {
                        break;
                    }
                }

                if (flagEnd)
                {
                    break;
                }

                PrintMatrix(matrix);

                if (command == "U")
                {
                    if (MoveUp(playerRow, playerCol, matrix))
                    {
                        flagEnd = true;
                    }

                    matrix[playerRow, playerCol] = ".";
                    playerRow--;
                    matrix[playerRow, playerCol] = "S";
                }
                else if (command == "D")
                {
                    if (MoveDown(playerRow, playerCol, matrix))
                    {
                        flagEnd = true;
                    }
                    matrix[playerRow, playerCol] = ".";
                    playerRow++;
                    matrix[playerRow, playerCol] = "S";
                }
                else if (command == "L")
                {
                    if (MoveLeft(playerRow, playerCol, matrix))
                    {
                        flagEnd = true;
                    }
                    matrix[playerRow, playerCol] = ".";
                    playerCol--;
                    matrix[playerRow, playerCol] = "S";
                }
                else if (command == "R")
                {
                    if (MoveRight(playerRow, playerCol, matrix))
                    {
                        flagEnd = true;
                    }
                    matrix[playerRow, playerCol] = ".";
                    playerCol++;
                    matrix[playerRow, playerCol] = "S";
                }
                else
                {
                    continue;
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == "Ds")
                    {
                        matrix[row, col] = "d";
                    }
                    else if (matrix[row, col] == "Bs")
                    {
                        matrix[row, col] = "b";
                    }

                    Console.Write($"{matrix[row, col]}");
                }

                Console.WriteLine();
            }
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }

                Console.WriteLine();
            }
        }

        private static bool IsValidIndex(int col, string[,] matrix)
        {
            return col < matrix.GetLength(1) && col >= 0;
        }

        private static bool MoveRight(int playerRow, int playerCol, string[,] matrix)
        {
            if (matrix[playerRow, playerCol + 1] == "N")
            {
                Console.WriteLine("Nikoladze killed!");
                matrix[playerRow, playerCol + 1] = "X";
                return true;
            }
            else
            {
                matrix[playerRow, playerCol + 1] = ".";
                return false;
            }
        }

        private static bool MoveLeft(int playerRow, int playerCol, string[,] matrix)
        {
            if (matrix[playerRow, playerCol - 1] == "N")
            {
                Console.WriteLine("Nikoladze killed!");
                matrix[playerRow, playerCol - 1] = "X";
                return true;
            }
            else
            {
                matrix[playerRow, playerCol - 1] = ".";
                return false;
            }
        }

        private static bool MoveDown(int playerRow, int playerCol, string[,] matrix)
        {
            if (matrix[playerRow + 1, playerCol] == "N")
            {
                Console.WriteLine("Nikoladze killed!");
                matrix[playerRow + 1, playerCol] = "X";
                return true;
            }
            else
            {
                matrix[playerRow + 1, playerCol] = ".";
                return false;
            }
        }

        private static bool MoveUp(int playerRow, int playerCol, string[,] matrix)
        {
            if (matrix[playerRow - 1, playerCol] == "N")
            {
                Console.WriteLine("Nikoladze killed!");
                matrix[playerRow - 1, playerCol] = "X";
                return true;
            }
            else
            {
                matrix[playerRow - 1, playerCol] = ".";
                return false;
            }
        }

        private static bool IsAtEdgeLeft(int v)
        {
            return v == 0;
        }

        private static bool IsAtEdgeRight(int col, string[,] matrix)
        {
            return col == matrix.GetLength(1) - 1;
        }
    }
}
