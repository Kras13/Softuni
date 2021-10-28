using System;

namespace PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            string pizzaName = Console.ReadLine().Split()[1];

            string[] doughTokens = Console.ReadLine().Split();
            string doughMaterial = doughTokens[1];
            string bakingTechnique = doughTokens[2];
            int grams = int.Parse(doughTokens[3]);

            try
            {
                Dough dough = new Dough(doughMaterial, bakingTechnique, grams);
                Pizza pizza = new Pizza(pizzaName, dough);

                while (true)
                {
                    string line = Console.ReadLine();

                    if (line == "END")
                    {
                        break;
                    }

                    string[] toppingTokens = line.Split();
                    string toppingName = toppingTokens[1];
                    int toppingWeight = int.Parse(toppingTokens[2]);
                    Topping topping = new Topping(toppingName, toppingWeight);

                    pizza.AddTopping(topping);
                }

                Console.WriteLine("{0} - {1:F2} Calories.", pizzaName, pizza.Calories);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
