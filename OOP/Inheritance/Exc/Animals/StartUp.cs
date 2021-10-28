using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Beast!")
                {
                    break;
                }

                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string gender = tokens[2];

                if (string.IsNullOrEmpty(name) ||
                    age < 0 ||
                    string.IsNullOrEmpty(gender))

                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                if (line == "Cat")
                {
                    var cat = new Cat(name, age, gender);

                    Console.WriteLine(cat);
                    Console.WriteLine(cat.ProduceSound());
                }
                else if (line == "Dog")
                {
                    var dog = new Dog(name, age, gender);

                    Console.WriteLine(dog);
                    Console.WriteLine(dog.ProduceSound());
                }
                else if (line == "Tomcat")
                {
                    var cat = new Tomcat(name, age);

                    Console.WriteLine(cat);
                    Console.WriteLine(cat.ProduceSound());
                }
                else if (line == "Kitten")
                {
                    var kitten = new Kitten(name, age);

                    Console.WriteLine(kitten);
                    Console.WriteLine(kitten.ProduceSound());
                }
                else if (line == "Frog")
                {
                    var frog = new Frog(name, age, gender);

                    Console.WriteLine(frog);
                    Console.WriteLine(frog.ProduceSound());
                }
            }


        }
    }
}
