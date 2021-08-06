using System;

namespace _9._Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[,] matrix = new string[n, n];
            string[] commands = Console.ReadLine().Split(' ');

            int minerRow = 0;
            int minerCol = 0;
            int allCoals = 0;

            bool flag = false;

            for (int row = 0; row < n; row++)
            {
                string[] charArray = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = charArray[col];

                    if (matrix[row, col] == "s")
                    {
                        minerRow = row;
                        minerCol = col;
                    }

                    if (matrix[row, col] == "c")
                    {
                        allCoals++;
                    }
                }
            }

            int clsCount = 0;

            for (int i = 0; i < commands.Length; i++)
            {
                string command = commands[i];

                if (command == "up")
                {
                    if (!IsIndexesValid(minerRow - 1, minerCol, n))
                    {
                        continue;
                    }

                    if (matrix[minerRow - 1, minerCol] == "c")
                    {
                        minerRow -= 1;
                        clsCount++;
                        matrix[minerRow, minerCol] = "*";

                        if (clsCount == allCoals)
                        {
                            Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                            flag = true;
                            return;
                        }
                    }
                    else if (matrix[minerRow - 1, minerCol] == "e")
                    {
                        minerRow -= 1;
                        Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                        flag = true;
                        return;
                    }
                    else
                    {
                        minerRow -= 1;
                    }
                }
                else if (command == "down")
                {
                    if (!IsIndexesValid(minerRow + 1, minerCol, n))
                    {
                        continue;
                    }

                    if (matrix[minerRow + 1, minerCol] == "c")
                    {
                        minerRow += 1;
                        clsCount++;
                        matrix[minerRow, minerCol] = "*";

                        if (clsCount == allCoals)
                        {
                            Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                            flag = true;
                            return;
                        }
                    }
                    else if (matrix[minerRow + 1, minerCol] == "e")
                    {
                        minerRow += 1;
                        Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                        flag = true;
                        return;
                    }
                    else
                    {
                        minerRow += 1;
                    }
                }
                else if (command == "left")
                {
                    if (!IsIndexesValid(minerRow, minerCol - 1, n))
                    {
                        continue;
                    }

                    if (matrix[minerRow, minerCol - 1] == "c")
                    {
                        minerCol -= 1;
                        clsCount++;
                        matrix[minerRow, minerCol] = "*";

                        if (clsCount == allCoals)
                        {
                            Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                            flag = true;
                            return;
                        }
                    }
                    else if (matrix[minerRow, minerCol - 1] == "e")
                    {
                        minerCol -= 1;
                        Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                        flag = true;
                        return;
                    }
                    else
                    {
                        minerCol -= 1;
                    }
                }
                else if (command == "right")
                {
                    if (!IsIndexesValid(minerRow, minerCol + 1, n))
                    {
                        continue;
                    }

                    if (matrix[minerRow, minerCol + 1] == "c")
                    {
                        minerCol += 1;
                        clsCount++;
                        matrix[minerRow, minerCol] = "*";

                        if (clsCount == allCoals)
                        {
                            Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                            flag = true;
                            return;
                        }
                    }
                    else if (matrix[minerRow, minerCol + 1] == "e")
                    {
                        minerCol += 1;
                        Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                        flag = true;
                        return;
                    }
                    else
                    {
                        minerCol += 1;
                    }
                }
            }

            if (!flag)
            {
                int remainingCoals = allCoals - clsCount;
                Console.WriteLine($"{remainingCoals} coals left. ({minerRow}, {minerCol})");
            }
        }

        private static bool IsIndexesValid(int row, int col, int n)
        {
            return row >= 0 && row < n && col >= 0 && col < n;
        }
    }
}
