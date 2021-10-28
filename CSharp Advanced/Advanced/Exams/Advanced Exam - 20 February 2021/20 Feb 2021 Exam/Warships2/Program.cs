using System;
using System.Linq;

namespace Warships2
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            string[] commands = Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int playerOneShips = 0;
            int playerTwoShips = 0;
            int totalKilledShips = 0;
            bool winner = false;

            for (int row = 0; row < size; row++)
            {
                char[] lineData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = lineData[col];

                    if (matrix[row, col] == '<')
                    {
                        playerOneShips++;
                    }
                    if (matrix[row, col] == '>')
                    {
                        playerTwoShips++;
                    }
                }
            }

            for (int i = 0; i < commands.Length; i++)
            {
                int[] currentCommands = commands[i]
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).
                    ToArray();

                int currentRow = currentCommands[0];
                int currentCol = currentCommands[1];

                if (currentRow < 0 || currentRow > size || currentCol < 0 || currentCol > size)
                {
                    continue;
                }

                if (IsShipOfPlayerFirst(matrix, currentRow, currentCol))
                {
                    matrix[currentRow, currentCol] = 'X';
                    playerOneShips--;
                    totalKilledShips++;
                }
                else if (IsShipOfPlayerSecond(matrix, currentRow, currentCol))
                {
                    matrix[currentRow, currentCol] = 'X';
                    playerTwoShips--;
                    totalKilledShips++;
                }
                else if (matrix[currentRow, currentCol] == '#')
                {
                    for (int row = currentRow - 1; row <= currentRow + 1; row++)
                    {
                        for (int col = currentCol - 1; col <= currentCol + 1; col++)
                        {
                            if (row >= 0 && row < size && col >= 0 && col < size)
                            {
                                if (IsShipOfPlayerFirst(matrix, row, col))
                                {
                                    matrix[currentRow, currentCol] = 'X';
                                    playerOneShips--;
                                    totalKilledShips++;
                                }
                                else if (IsShipOfPlayerSecond(matrix, row, col))
                                {
                                    matrix[currentRow, currentCol] = 'X';
                                    playerTwoShips--;
                                    totalKilledShips++;
                                }
                            }
                        }
                    }
                }

                if (playerOneShips <= 0)
                {
                    Console.WriteLine($"Player Two has won the game! {totalKilledShips} ships have been sunk in the battle.");
                    winner = true;
                    break;
                }

                if (playerTwoShips <= 0)
                {
                    Console.WriteLine($"Player One has won the game! {totalKilledShips} ships have been sunk in the battle.");
                    winner = true;
                    break;
                }
            }

            if (!winner && playerOneShips > 0 && playerTwoShips > 0)
            {
                Console.WriteLine($"It's a draw! Player One has {playerOneShips} ships left. Player Two has {playerTwoShips} ships left.");
            }
        }

        private static bool IsShipOfPlayerFirst(char[,] matrix, int currentRow, int currentCol)
        {
            return matrix[currentRow, currentCol] == '<';
        }

        private static bool IsShipOfPlayerSecond(char[,] matrix, int currentRow, int currentCol)
        {
            return matrix[currentRow, currentCol] == '>';
        }
    }
}
