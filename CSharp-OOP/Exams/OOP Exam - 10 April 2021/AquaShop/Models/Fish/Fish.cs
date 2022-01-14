using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;

namespace AquaShop.Models.Fish
{
    public abstract class Fish : IFish
    {
        public Fish(string name, string species, decimal price, int size)
        {
            this.Name = name;
            this.Species = species;
            this.Price = price;
            this.Size = size;
        }

        private string name;
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidFishName);
                }
                this.name = value;
            }
        }

        private string species;
        public string Species
        {
            get => this.species;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidFishSpecies);
                }
                this.species = value;
            }
        }

        public int Size { get; protected set; }

        private decimal price;
        public decimal Price
        {
            get => this.price;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidFishPrice);
                }
                this.price = value;
            }
        }

        public abstract void Eat();

        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}
