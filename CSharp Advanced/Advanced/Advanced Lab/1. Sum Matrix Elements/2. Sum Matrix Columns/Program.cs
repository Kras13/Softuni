using System;

namespace _2._Sum_Matrix_Columns
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");

            int rows = int.Parse(input[0]);
            int cols = int.Parse(input[1]);

            int[] sumRows = new int[cols];

            for (int row = 0; row < rows; row++)
            {
                string[] line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < line.Length; i++)
                {
                    sumRows[i] += int.Parse(line[i]);
                }
            }

            foreach (var item in sumRows)
            {
                Console.WriteLine(item);
            }
        }
    }
}
