using System;
using System.Linq;

namespace _10.RadioactiveMutantVampireBunnies
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

            string[,] matrix = new string[rows, cols];

            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < rows; row++)
            {
                string lineValues = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = lineValues[col].ToString();

                    if (matrix[row, col] == "P")
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            string commands = Console.ReadLine();

            int cycleCount = 0;

            for (int i = 0; i < commands.Length; i++)
            {
                char command = commands[i];
                cycleCount++;

                if (command == 'U')
                {
                    // go up

                    if (IsIndexesValid(playerRow - 1, playerCol, matrix))
                    {
                        playerRow -= 1;

                        if (matrix[playerRow, playerCol] == "B")
                        {
                            for (int j = cycleCount; j < commands.Length; j++)
                            {
                                MultiplyBunnies(matrix);
                            }

                            PrintMatrix(matrix);
                            Console.WriteLine($"dead: {playerRow} {playerCol}");
                            break;
                        }
                    }
                    else
                    {
                        for (int j = cycleCount; j < commands.Length; j++)
                        {
                            MultiplyBunnies(matrix);
                        }

                        PrintMatrix(matrix);
                        Console.WriteLine($"won: {playerRow} {playerCol}");
                        break;
                    }
                }
                else if (command == 'D')
                {
                    // go down

                    if (IsIndexesValid(playerRow + 1, playerCol, matrix))
                    {
                        playerRow += 1;
                        // MultiplyBunnies(matrix);

                        if (matrix[playerRow, playerCol] == "B")
                        {
                            for (int j = cycleCount; j < commands.Length; j++)
                            {
                                MultiplyBunnies(matrix);
                            }

                            PrintMatrix(matrix);
                            Console.WriteLine($"dead: {playerRow} {playerCol}");
                            break;
                        }

                    }
                    else
                    {
                        for (int j = cycleCount; j < commands.Length; j++)
                        {
                            MultiplyBunnies(matrix);
                        }

                        PrintMatrix(matrix);
                        Console.WriteLine($"won: {playerRow} {playerCol}");
                        break;
                    }
                }
                else if (command == 'L')
                {
                    // go left

                    if (IsIndexesValid(playerRow, playerCol - 1, matrix))
                    {
                        playerCol -= 1;
                        //MultiplyBunnies(matrix);

                        if (matrix[playerRow, playerCol] == "B")
                        {
                            for (int j = cycleCount; j < commands.Length; j++)
                            {
                                MultiplyBunnies(matrix);
                            }

                            PrintMatrix(matrix);
                            Console.WriteLine($"dead: {playerRow} {playerCol}");
                            break;
                        }

                    }
                    else
                    {
                        for (int j = cycleCount; j < commands.Length; j++)
                        {
                            MultiplyBunnies(matrix);
                        }

                        PrintMatrix(matrix);
                        Console.WriteLine($"won: {playerRow} {playerCol}");
                        break;
                    }
                }
                else if (command == 'R')
                {
                    // go right

                    if (IsIndexesValid(playerCol + 1, playerCol, matrix))
                    {
                        playerCol += 1;
                        // MultiplyBunnies(matrix);

                        if (matrix[playerRow, playerCol] == "B")
                        {
                            for (int j = cycleCount; j < commands.Length; j++)
                            {
                                MultiplyBunnies(matrix);
                            }

                            PrintMatrix(matrix);
                            Console.WriteLine($"dead: {playerRow} {playerCol}");
                            break;
                        }
                    }
                    else
                    {
                        for (int j = cycleCount; j < commands.Length; j++)
                        {
                            MultiplyBunnies(matrix);
                        }

                        PrintMatrix(matrix);
                        Console.WriteLine($"won: {playerRow} {playerCol}");
                        break;
                    }
                }

                MultiplyBunnies(matrix);
            }

        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void MultiplyBunnies(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == "B")
                    {
                        if (IsIndexesValid(row - 1, col, matrix))
                        {
                            //up

                            matrix[row - 1, col] = "B";
                        }
                        if (IsIndexesValid(row + 1, col, matrix))
                        {
                            // down

                            matrix[row + 1, col] = "B";
                        }
                        if (IsIndexesValid(row, col - 1, matrix))
                        {
                            // left

                            matrix[row, col - 1] = "B";
                        }
                        if (IsIndexesValid(row, col + 1, matrix))
                        {
                            // right

                            matrix[row, col + 1] = "B";
                        }
                    }
                }
            }
        }

        private static bool IsIndexesValid(int playerRow, int playerCol, string[,] matrix)
        {
            return playerRow >= 0 && playerRow < matrix.GetLength(0) && playerCol >= 0 && playerCol < matrix.GetLength(1);
        }
    }
}
