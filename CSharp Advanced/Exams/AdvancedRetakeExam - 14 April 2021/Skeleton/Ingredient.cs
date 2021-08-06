using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailParty
{
    public class Ingredient
    {
        public string Name { get; private set; }

        public int Alcohol { get; private set; }

        public int Quantity { get; private set; }

        public Ingredient(string name, int alcohol, int quantity)
        {
            this.Name = name;
            this.Alcohol = alcohol;
            this.Quantity = quantity;
        }

        public override string ToString()
        {
            string result = $"Ingredient: {this.Name}" + Environment.NewLine;
            result += $"Quantity: { this.Quantity}" + Environment.NewLine;
            result += $"Alcohol: {this.Alcohol}";
            return result;

            //return $"Ingredient: {this.Name}" + Environment.NewLine +
            //    $"Quantity: { this.Quantity}" + Environment.NewLine +
            //    $"Alcohol: {this.Alcohol}";
        }
    }
}
