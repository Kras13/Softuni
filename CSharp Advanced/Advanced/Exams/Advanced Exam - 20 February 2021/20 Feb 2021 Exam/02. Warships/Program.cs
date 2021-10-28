using System;
using System.Linq;
using System.Text;

namespace _02._Warships
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);
            char[,] matrix = new char[n, n];
            int shipsCount = 0;
            bool winner = false;

            for (int row = 0; row < n; row++)
            {
                string[] line = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                StringBuilder text = new StringBuilder();

                foreach (var item in line)
                {
                    text.Append(item);
                }
                string result = text.ToString();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = result[col];
                }
            }

            for (int i = 0; i < commands.Length; i++)
            {
                int[] tokens = commands[i].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int rowComand = tokens[0];
                int colComand = tokens[1];

                if (!IsValidIndexes(rowComand, colComand, matrix))
                {
                    continue;
                }
                if (matrix[rowComand, colComand] == '#')
                {
                    BombExplode(matrix, rowComand, colComand, ref shipsCount);
                    matrix[rowComand, colComand] = 'X';
                }
                else if (matrix[rowComand, colComand] == '>' || matrix[rowComand, colComand] == '<')
                {
                    LandOnIt(i, rowComand, colComand, matrix, ref shipsCount);
                }

                if (HasWinner(matrix))
                {
                    winner = true;
                    break;
                }
            }

            int firstCount = CheckResult(matrix, '<');
            int secondCount = CheckResult(matrix, '>');

            if (winner)
            {
                if (firstCount > secondCount)
                {
                    Console.WriteLine($"Player One has won the game! {shipsCount} ships have been sunk in the battle.");
                }
                else
                {
                    Console.WriteLine($"Player Two has won the game! {shipsCount} ships have been sunk in the battle.");
                }
            }
            else
            {
                Console.WriteLine($"It's a draw! Player One has {firstCount} ships left. Player Two has {secondCount} ships left.");
            }

        }

        private static bool HasWinner(char[,] matrix)
        {
            int firstCount = 0;
            int secondCount = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == '<')
                    {
                        firstCount++;
                    }
                    else if (matrix[row, col] == '>')
                    {
                        secondCount++;
                    }
                }
            }

            // both 0 or both != 0 => no winner
            // one 0 other different => winner
            if (firstCount == 0 && secondCount == 0 || firstCount != 0 && secondCount != 0)
            {
                return false;
            }
            return true;
        }

        private static int CheckResult(char[,] matrix, char indexToCheck)
        {
            int result = 0;

            // Check for the first one

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == indexToCheck)
                    {
                        result++;
                    }
                }
            }

            return result;
        }

        private static void LandOnIt(int i, int rowComand, int colComand, char[,] matrix, ref int count)
        {
            if (i % 2 == 0)
            {
                // Player first
                if (matrix[rowComand, colComand] == '>')
                {
                    matrix[rowComand, colComand] = 'X';
                    count++;
                }
            }
            else
            {
                // Second player
                if (matrix[rowComand, colComand] == '<')
                {
                    matrix[rowComand, colComand] = 'X';
                    count++;
                }
            }
        }

        private static void BombExplode(char[,] matrix, int row, int col, ref int count)
        {
            if (IsValidIndexes(row, col - 1, matrix))
            {
                if (IsShip(row, col - 1, matrix))
                {
                    count++;
                }
                matrix[row, col - 1] = 'X';
            }
            if (IsValidIndexes(row, col + 1, matrix))
            {
                if (IsShip(row, col + 1, matrix))
                {
                    count++;
                }
                matrix[row, col + 1] = 'X';
            }
            if (IsValidIndexes(row - 1, col, matrix))
            {
                if (IsShip(row - 1, col, matrix))
                {
                    count++;
                }
                matrix[row - 1, col] = 'X';
            }
            if (IsValidIndexes(row + 1, col, matrix))
            {
                if (IsShip(row + 1, col, matrix))
                {
                    count++;
                }
                matrix[row + 1, col] = 'X';
            }
            if (IsValidIndexes(row - 1, col - 1, matrix))
            {
                if (IsShip(row - 1, col - 1, matrix))
                {
                    count++;
                }
                matrix[row - 1, col - 1] = 'X';
            }
            if (IsValidIndexes(row - 1, col + 1, matrix))
            {
                if (IsShip(row - 1, col + 1, matrix))
                {
                    count++;
                }
                matrix[row - 1, col + 1] = 'X';
            }
            if (IsValidIndexes(row + 1, col - 1, matrix))
            {
                if (IsShip(row + 1, col - 1, matrix))
                {
                    count++;
                }
                matrix[row + 1, col - 1] = 'X';
            }
            if (IsValidIndexes(row + 1, col + 1, matrix))
            {
                if (IsShip(row + 1, col + 1, matrix))
                {
                    count++;
                }
                matrix[row + 1, col + 1] = 'X';
            }
        }

        private static bool IsShip(int row, int col, char[,] matrix)
        {
            if (matrix[row, col] == '<' || matrix[row, col] == '>')
            {
                return true;
            }
            return false;
        }

        private static bool IsValidIndexes(int row, int col, char[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
