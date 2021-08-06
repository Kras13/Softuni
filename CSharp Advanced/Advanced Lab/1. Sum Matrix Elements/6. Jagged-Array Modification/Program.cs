using System;

namespace _6._Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[,] matrix = new int[rows, rows];
            int cols = 0;

            for (int row = 0; row < rows; row++)
            {
                string[] line = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                cols = line.Length;

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = int.Parse(line[col]);
                }
            }


            while (true)
            {
                string line = Console.ReadLine();

                if (line == "END")
                {
                    break;
                }

                string[] lineData = line.Split();

                string command = lineData[0];

                int row = int.Parse(lineData[1]);
                int col = int.Parse(lineData[2]);

                if (row >= rows || col >= cols || row < 0 || col < 0)
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                if (command == "Add")
                {
                    int value = int.Parse(lineData[3]);
                    matrix[row, col] += value;
                }
                else if (command == "Subtract")
                {
                    int value = int.Parse(lineData[3]);
                    matrix[row, col] -= value;
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0} ", matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
