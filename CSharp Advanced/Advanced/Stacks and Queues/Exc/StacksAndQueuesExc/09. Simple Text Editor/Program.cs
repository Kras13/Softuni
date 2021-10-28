using System;
using System.Collections.Generic;
using System.Text;

namespace _09._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Stack only before 1 and 2 command

            StringBuilder builder = new StringBuilder();
            Stack<string> stack = new Stack<string>();
            stack.Push(builder.ToString());

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();

                if (int.Parse(command[0]) == 1)
                {
                    if (command.Length > 2)
                    {
                        builder.Append(command[1] + command[2]);
                        stack.Push(builder.ToString());
                    }
                    else
                    {
                        builder.Append(command[1]);
                        stack.Push(builder.ToString());
                    }
                    
                }
                else if (int.Parse(command[0]) == 2)
                {
                    int count = int.Parse(command[1]);
                    builder.Remove(builder.Length - count, count);
                    stack.Push(builder.ToString());
                }
                else if (int.Parse(command[0]) == 3)
                {
                    int index = int.Parse(command[1]);
                    Console.WriteLine(builder[index - 1]);
                }
                else if (int.Parse(command[0]) == 4)
                {
                    stack.Pop();
                    builder = new StringBuilder();
                    builder.Append(stack.Peek());
                }
            }
        }
    }
}
