using System;
using System.IO;

namespace _1._Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var stream = new StreamReader("Input.txt"))
            {
                int counter = 0;
                string line = stream.ReadLine();

                using (var writer = new StreamWriter("Output.txt"))
                {
                    while (line != null)
                    {
                        if (counter % 2 != 0)
                        {
                            writer.WriteLine(line);
                        }

                        counter++;
                        line = stream.ReadLine();
                    }
                }
            }
        }
    }
}
