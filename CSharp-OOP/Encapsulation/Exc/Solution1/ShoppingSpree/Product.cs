using System;

namespace ShoppingSpree
{
    public class Product
    {
        private string name;
        private double cost;

        public Product(string name, double cost)
        {
            this.Name = name;
            this.Cost = cost;
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

        public double Cost
        {
            get
            {
                return cost;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Money cannot be negative");
                }
                cost = value;
            }
        }

        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}
