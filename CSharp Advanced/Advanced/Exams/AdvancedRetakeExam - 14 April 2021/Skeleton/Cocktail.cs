using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        private List<Ingredient> ingredients;

        public string Name { get; private set; }

        public int Capacity { get; private set; }

        public int MaxAlcoholLevel { get; private set; }

        public int CurrentAlcoholLevel
        {
            get
            {
                return ingredients.Sum(ing => ing.Alcohol);
            }
        }

        public List<Ingredient> Ingredients { get { return this.ingredients; } }


        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.MaxAlcoholLevel = maxAlcoholLevel;
            ingredients = new List<Ingredient>();
        }

        public void Add(Ingredient ingredient)
        {
            Ingredient selectedIngredient = ingredients.FirstOrDefault(x => x.Name == ingredient.Name);

            if (selectedIngredient == null && this.ingredients.Count < this.Capacity && CurrentAlcoholLevel + ingredient.Alcohol <= this.MaxAlcoholLevel)
            {
                this.ingredients.Add(ingredient);
            }
        }

        public bool Remove(string name)
        {
            if (ingredients.Any(ing => ing.Name == name))
            {
                Ingredient selectedIngredient = ingredients.FirstOrDefault(ing => ing.Name == name);
                ingredients.Remove(selectedIngredient);
                return true;
            }
            return false;
        }

        public Ingredient FindIngredient(string name)
        {
            return ingredients.FirstOrDefault(ing => ing.Name == name);
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            return ingredients.OrderBy(ing => ing.Alcohol).Last();
        }

        public string Report()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(($"Cocktail: {this.Name} - Current Alcohol Level: {this.CurrentAlcoholLevel}"));

            for (int i = 0; i < ingredients.Count; i++)
            {
                if (i == ingredients.Count - 1)
                {
                    stringBuilder.Append(ingredients[i]);
                }
                else
                {
                    stringBuilder.AppendLine(ingredients[i].ToString());
                }
            }

            return stringBuilder.ToString();
        }
    }
}
