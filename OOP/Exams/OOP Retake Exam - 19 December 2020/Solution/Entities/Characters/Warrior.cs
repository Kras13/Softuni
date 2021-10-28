using System;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Warrior : Character, IAttacker
    {
        private const double CustomBaseHealth = 100;
        private const double CustomArmor = 50;
        private const double CustomAbilitypoints = 40;
        private Satchel bag = new Satchel();

        public Warrior(string name)
            : base(name, CustomBaseHealth, CustomArmor, CustomAbilitypoints)
        {
            this.Bag = bag;
        }
        public void Attack(Character character)
        {
            this.EnsureAlive();

            if (character.Name == this.Name)
            {
                throw new InvalidOperationException(ExceptionMessages.CharacterAttacksSelf);
            }

            if (this.IsAlive && character.IsAlive)
            {
                character.TakeDamage(this.AbilityPoints);
            }
        }
    }
}
