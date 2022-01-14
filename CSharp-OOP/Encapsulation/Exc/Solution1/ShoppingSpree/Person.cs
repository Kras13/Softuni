using System.Collections.Generic;
using System;

namespace ShoppingSpree
{
    public class Person
    {
        private List<Product> products;

        private string name;
        private double money;

        public Person(string name, double money)
        {
            this.Name = name;
            this.Money = money;
            products = new List<Product>();
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value == " ")
                {
                    throw new Exception("Name cannot be empty");
                }
                name = value;
            }
        }

        public double Money
        {
            get
            {
                return money;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Money cannot be negative");
                }
                money = value;
            }
        }

        public string BuyProduct(Product product)
        {
            if (product.Cost <= this.money)
            {
                this.money -= product.Cost;
                products.Add(product);
                return $"{this.name} bought {product.Name}";
            }

            return $"{this.name} can't afford {product.Name}";
        }

        public string ShowProducts()
        {
            if (products.Count > 0)
            {
                return $"{this.name} - {string.Join(", ", products)}";
            }
            return $"{this.name} - Nothing bought";
        }
    }
}
