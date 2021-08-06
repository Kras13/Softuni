using System;
using System.IO;
using System.Linq;
using System.Text;

namespace _1._Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] charArr = { '-', ',', '.', '!', '?' };
            int counter = 0;

            using (StreamReader input = new StreamReader("text.txt"))
            {
                string line = input.ReadLine();

                while (line != null)
                {
                    if (counter % 2 == 0)
                    {
                        string[] strToPrint = ReplaceChars(line, charArr)
                            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                            .Reverse()
                            .ToArray();

                        Console.WriteLine(string.Join(' ', strToPrint));
                    }

                    counter++;
                    line = input.ReadLine();
                }
            }
        }

        private static string ReplaceChars(string str, char[] charArr)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < str.Length; i++)
            {
                bool flag = false;

                for (int k = 0; k < charArr.Length; k++)
                {
                    if (str[i] == charArr[k])
                    {
                        stringBuilder.Append("@");
                        flag = true;
                        break;
                    }
                }

                if (!flag)
                {
                    stringBuilder.Append(str[i]);
                }
            }

            return stringBuilder.ToString();
        }
    }
}
