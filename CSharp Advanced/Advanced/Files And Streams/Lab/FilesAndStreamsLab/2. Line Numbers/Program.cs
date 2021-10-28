using System;
using System.IO;

namespace _2._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var stream = new StreamReader("Input.txt"))
            {
                string line = stream.ReadLine();

                using (var output = new StreamWriter("Output.txt"))
                {
                    int index = 1;

                    while (line != null)
                    {
                        string outputLine = $" {index++}. {line}";
                        output.WriteLine(outputLine);
                        line = stream.ReadLine();
                    }
                }
            }

        }
    }
}
