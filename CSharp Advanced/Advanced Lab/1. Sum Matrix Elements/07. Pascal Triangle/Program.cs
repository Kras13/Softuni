using System;

namespace _07._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());

            long[,] matrix = new long[n, n];

            for (int line = 0; line < n; line++)
            {
                for (int col = 0; col <= line; col++)
                {
                    if (line == col || col == 0)
                    {
                        matrix[line, col] = 1;
                    }
                    else
                    {
                        matrix[line, col] = matrix[line - 1, col - 1] + matrix[line - 1, col];
                    }

                    Console.Write("{0} ",matrix[line, col]);
                }
                Console.WriteLine();
            }

        }
    }
}
