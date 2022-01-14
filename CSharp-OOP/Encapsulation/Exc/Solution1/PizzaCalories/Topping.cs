using System;

namespace PizzaCalories
{
    public class Topping
    {
        private double indexMod;
        private double grams;

        public Topping(string toppingName, double grams)
        {
            string toppingToLowwer = toppingName.ToLower();

            if (!IsToppingValid(toppingToLowwer))
            {
                throw new Exception($"Cannot place {toppingName} on top of your pizza.");
            }

            if (toppingToLowwer == "meat")
            {
                this.indexMod = 1.2;
            }
            else if (toppingToLowwer == "veggies")
            {
                this.indexMod = 0.8;
            }
            else if (toppingToLowwer == "cheese")
            {
                this.indexMod = 1.1;
            }
            else if (toppingToLowwer == "sauce")
            {
                this.indexMod = 0.9;
            }

            if (grams >= 1 && grams <= 50)
            {
                this.grams = grams;
            }
            else
            {
                throw new Exception($"{toppingName} weight should be in the range [1..50].");
            }
        }

        public double Calories
        {
            get
            {
                return 2 * indexMod * grams;
            }
        }
        private bool IsToppingValid(string toppingName)
        {
            return toppingName == "meat" || toppingName == "veggies" || toppingName == "cheese" || toppingName == "sauce";
        }
    }
}
