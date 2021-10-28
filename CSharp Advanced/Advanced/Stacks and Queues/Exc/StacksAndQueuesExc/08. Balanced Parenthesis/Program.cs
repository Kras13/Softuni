using System;
using System.Collections.Generic;

namespace _08._Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            if (IsInputParsBalanced(input))
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }

        private static bool IsInputParsBalanced(string input)
        {
            Stack<char> brackets = new Stack<char>();

            foreach (char ch in input)
            {
                if (ch == '[' || ch == '{' || ch == '(')
                {
                    brackets.Push(ch);
                }
                else if (ch == ']' || ch == '}' || ch == ')')
                {
                    if (brackets.Count <= 0)
                    {
                        return false;
                    }

                    char open = brackets.Pop();

                    if ((ch == '}' && open != '{') ||
                        (ch == ')' && open != '(') ||
                        (ch == ']' && open != '[')
                        )
                    {
                        return false;
                    }
                }
            }

            if (brackets.Count > 0)
            {
                return false;
            }

            return true;
        }
    }
}
