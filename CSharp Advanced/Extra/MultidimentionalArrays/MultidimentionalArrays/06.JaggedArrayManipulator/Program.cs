using System;
using System.Linq;

namespace _06.JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            double[][] jaggedArray = new double[rows][];

            int pointer = 0;

            double[] line = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            jaggedArray[0] = line;

            while (true)
            {
                string[] currentLine = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (currentLine[0] == "End")
                {
                    break;
                }

                if (currentLine[0] == "Add")
                {
                    int row = int.Parse(currentLine[1]);
                    int col = int.Parse(currentLine[2]);
                    int value = int.Parse(currentLine[3]);

                    if (row < jaggedArray.Length && row >= 0)
                    {
                        if (col < jaggedArray[row].Length && col >= 0)
                        {
                            jaggedArray[row][col] += value;
                        }
                    }

                    continue;
                }
                else if (currentLine[0] == "Subtract")
                {
                    int row = int.Parse(currentLine[1]);
                    int col = int.Parse(currentLine[2]);
                    int value = int.Parse(currentLine[3]);

                    if (row < jaggedArray.Length && row >= 0)
                    {
                        if (col < jaggedArray[row].Length && col >= 0)
                        {
                            jaggedArray[row][col] -= value;
                        }
                    }

                    continue;
                }

                double[] currentFormattedLine = currentLine
                    .Select(double.Parse)
                    .ToArray();

                if (currentFormattedLine.Length == jaggedArray[pointer].Length)
                {
                    for (int i = 0; i < jaggedArray[pointer].Length; i++)
                    {
                        jaggedArray[pointer][i] *= 2;
                    }

                    pointer++;

                    for (int i = 0; i < currentFormattedLine.Length; i++)
                    {
                        currentFormattedLine[i] *= 2;
                    }
                }
                else
                {
                    for (int i = 0; i < jaggedArray[pointer].Length; i++)
                    {
                        jaggedArray[pointer][i] /= 2;
                    }

                    pointer++;

                    for (int i = 0; i < currentFormattedLine.Length; i++)
                    {
                        currentFormattedLine[i] /= 2;
                    }
                }

                jaggedArray[pointer] = currentFormattedLine;
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write(jaggedArray[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
