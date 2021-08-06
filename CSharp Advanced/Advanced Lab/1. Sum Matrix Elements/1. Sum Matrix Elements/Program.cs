using System;

namespace _1._Sum_Matrix_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");

            int rows = int.Parse(input[0]);
            int cols = int.Parse(input[1]);
            double sum = 0;

            for (int i = 0; i < rows; i++)
            {
                string[] line = Console.ReadLine().Split(", ");

                foreach (var item in line)
                {
                    sum += int.Parse(item);
                }
            }

            Console.WriteLine(rows);
            Console.WriteLine(cols);
            Console.WriteLine(sum);
        }
    }
}
