using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        public Character(string name, double health, double armor, double abilityPoints)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
        }

        private string name;
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }
                this.name = value;
            }
        }

        public double BaseHealth { get; private set; }

        public bool IsAlive { get; set; } = true;

        private double health;
        public double Health
        {
            get => this.health;
            set
            {
                if (value >= this.BaseHealth)
                {
                    this.health = BaseHealth;
                }
                else if (value < 0)
                {
                    this.health = 0;
                }
                else
                {
                    this.health = value;
                }
            }
        }

        public double Armor { get; private set; }

        public double AbilityPoints { get; private set; }

        public double BaseArmor { get; private set; }

        public Bag Bag { get; protected set; }

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }

        public void TakeDamage(double hitPoints)
        {
            if (this.IsAlive)
            {
                this.Armor -= hitPoints;
                if (this.Armor < 0)
                {
                    this.Health += Armor;
                    this.Armor = 0;
                    if (this.Health <= 0)
                    {
                        this.IsAlive = false;
                    }
                }
            }
        }

        public void UseItem(Item item)
        {
            item.AffectCharacter(this);
        }
    }
}