using System;
using System.Linq;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] numbersInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (var number in numbersInput)
            {
                if (number.Length == 10)
                {
                    try
                    {
                        ICallable callable = new Smartphone();
                        string message = callable.Call(number);
                        Console.WriteLine(message);
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    try
                    {
                        ICallable callable = new StationaryPhone();
                        string message = callable.Call(number);
                        Console.WriteLine(message);
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            string[] urlsInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (var url in urlsInput)
            {
                try
                {
                    IBrowsable browsable = new Smartphone();
                    string message = browsable.Browse(url);
                    Console.WriteLine(message);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
