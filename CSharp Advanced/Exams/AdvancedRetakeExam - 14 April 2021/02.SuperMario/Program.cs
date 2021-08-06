using System;

namespace _02.SuperMario
{
    class Program
    {
        static void Main(string[] args)
        {
            int health = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());
            string line = Console.ReadLine();
            int cols = line.Length;
            char[,] matrix = new char[rows, cols];
            int marioRow = 0;
            int marioCol = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = line[col];

                    if (matrix[row, col] == 'M')
                    {
                        marioRow = row;
                        marioCol = col;
                    }
                }

                if (row < rows - 1)
                {
                    line = Console.ReadLine();
                }
            }

            bool foundPrincess = false;
            bool killed = false;

            while (true)
            {
                string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int enemyRow = int.Parse(commands[1]);
                int enemyCol = int.Parse(commands[2]);
                matrix[enemyRow, enemyCol] = 'B';

                switch (commands[0])
                {
                    case "W":
                        health--;

                        if (IsIndexesValid(marioRow - 1, marioCol, matrix))
                        {
                            if (matrix[marioRow - 1, marioCol] == 'P')
                            {
                                foundPrincess = true;
                                matrix[marioRow - 1, marioCol] = '-';
                                matrix[marioRow, marioCol] = '-';
                            }
                            else if (matrix[marioRow - 1, marioCol] == 'B')
                            {
                                health -= 2;

                                if (health > 0)
                                {
                                    matrix[marioRow - 1, marioCol] = 'M';
                                    matrix[marioRow, marioCol] = '-';
                                    marioRow -= 1;
                                }
                                else
                                {
                                    killed = true;
                                    matrix[marioRow, marioCol] = '-';
                                    marioRow -= 1;
                                }
                            }
                            else
                            {
                                matrix[marioRow - 1, marioCol] = 'M';
                                matrix[marioRow, marioCol] = '-';
                                marioRow -= 1;
                            }
                        }

                        break;
                    case "S":
                        health--;

                        if (IsIndexesValid(marioRow + 1, marioCol, matrix))
                        {
                            if (matrix[marioRow + 1, marioCol] == 'P')
                            {
                                foundPrincess = true;
                                matrix[marioRow + 1, marioCol] = '-';
                                matrix[marioRow, marioCol] = '-';
                            }
                            else if (matrix[marioRow + 1, marioCol] == 'B')
                            {
                                health -= 2;

                                if (health > 0)
                                {
                                    matrix[marioRow + 1, marioCol] = 'M';
                                    matrix[marioRow, marioCol] = '-';
                                    marioRow += 1;
                                }
                                else
                                {
                                    killed = true;
                                    matrix[marioRow, marioCol] = '-';
                                    marioRow += 1;
                                }
                            }
                            else
                            {
                                matrix[marioRow + 1, marioCol] = 'M';
                                matrix[marioRow, marioCol] = '-';
                                marioRow += 1;
                            }
                        }
                        break;
                    case "A":
                        health--;

                        if (IsIndexesValid(marioRow, marioCol - 1, matrix))
                        {
                            if (matrix[marioRow, marioCol - 1] == 'P')
                            {
                                foundPrincess = true;
                                matrix[marioRow, marioCol - 1] = '-';
                                matrix[marioRow, marioCol] = '-';
                            }
                            else if (matrix[marioRow, marioCol - 1] == 'B')
                            {
                                health -= 2;

                                if (health > 0)
                                {
                                    matrix[marioRow, marioCol - 1] = 'M';
                                    matrix[marioRow, marioCol] = '-';
                                    marioCol -= 1;
                                }
                                else
                                {
                                    killed = true;
                                    matrix[marioRow, marioCol] = '-';
                                    marioCol -= 1;
                                }
                            }
                            else
                            {
                                matrix[marioRow, marioCol - 1] = 'M';
                                matrix[marioRow, marioCol] = '-';
                                marioCol -= 1;
                            }
                        }
                        break;
                    case "D":
                        health--;

                        if (IsIndexesValid(marioRow, marioCol + 1, matrix))
                        {
                            if (matrix[marioRow, marioCol + 1] == 'P')
                            {
                                foundPrincess = true;
                                matrix[marioRow, marioCol + 1] = '-';
                                matrix[marioRow, marioCol] = '-';
                            }
                            else if (matrix[marioRow, marioCol + 1] == 'B')
                            {
                                health -= 2;

                                if (health > 0)
                                {
                                    matrix[marioRow, marioCol + 1] = 'M';
                                    matrix[marioRow, marioCol] = '-';
                                    marioCol += 1;
                                }
                                else
                                {
                                    killed = true;
                                    matrix[marioRow, marioCol] = '-';
                                    marioCol += 1;
                                }
                            }
                            else
                            {
                                matrix[marioRow, marioCol + 1] = 'M';
                                matrix[marioRow, marioCol] = '-';
                                marioCol += 1;
                            }
                        }
                        break;
                }

                if (foundPrincess)
                {
                    Console.WriteLine("Mario has successfully saved the princess! Lives left: {0}", health);
                    break;
                }
                else if (killed || health <= 0)
                {
                    matrix[marioRow, marioCol] = 'X';
                    Console.WriteLine("Mario died at {0};{1}.", marioRow, marioCol);
                    break;
                }
            }

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[,] maze)
        {
            for (int row = 0; row < maze.GetLength(0); row++)
            {
                for (int col = 0; col < maze.GetLength(1); col++)
                {
                    Console.Write(maze[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static bool IsIndexesValid(int row, int col, char[,] maze)
        {
            return row >= 0 && row < maze.GetLength(0) && col >= 0 && col < maze.GetLength(1);
        }
    }
}
