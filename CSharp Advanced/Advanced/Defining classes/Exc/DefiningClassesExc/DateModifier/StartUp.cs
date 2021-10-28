using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondtDate = Console.ReadLine();

            DateModifier dateModifier = new DateModifier();

            string diff = dateModifier.DiffernceInDates(firstDate, secondtDate);
            Console.WriteLine(diff);
        }
    }
}
