using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] people = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);
            string[] products = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);

            List<Person> peopleCollection = new List<Person>();
            List<Product> productsCollection = new List<Product>();
            try
            {
                for (int i = 0; i < people.Length; i++)
                {
                    string[] personTokens = people[i].Split("=");
                    string personName = personTokens[0];
                    double personMoney = double.Parse(personTokens[1]);
                    Person person = new Person(personName, personMoney);
                    peopleCollection.Add(person);
                }

                for (int i = 0; i < products.Length; i++)
                {
                    string[] productTokens = products[i].Split("=");
                    string productName = productTokens[0];
                    double productMoney = double.Parse(productTokens[1]);
                    Product product = new Product(productName, productMoney);
                    productsCollection.Add(product);
                }

                while (true)
                {
                    string[] line = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    if (line[0] == "END")
                    {
                        break;
                    }

                    Person selectedPerson = peopleCollection.FirstOrDefault(p => p.Name == line[0]);
                    Product selectedProduct = productsCollection.FirstOrDefault(p => p.Name == line[1]);

                    if (selectedPerson != null && selectedProduct != null)
                    {
                        string message = selectedPerson.BuyProduct(selectedProduct);
                        Console.WriteLine(message);
                    }  
                }

                foreach (Person person1 in peopleCollection)
                {
                    Console.WriteLine(person1.ShowProducts());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}", e.Message);
            }
        }
    }
}
