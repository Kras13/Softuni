using System.Collections.Generic;
using System;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.toppings = new List<Topping>();
        }

        private List<Topping> toppings;

        public string Name
        {
            get => this.name;
            set
            {
                if (value.Length >= 1 && value.Length <= 15)
                {
                    this.name = value;
                }
                else
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }
            }
        }

        public Dough Dough { get; set; }

        public int ToppingsCount => toppings.Count;

        public double Calories => TotalCalories();

        private double TotalCalories()
        {
            double sum = 0;

            foreach (Topping topping in toppings)
            {
                sum += topping.Calories;
            }

            sum += this.Dough.Calories;

            return sum;
        }

        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            this.toppings.Add(topping);
        }
    }
}
