using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Priest : Character, IHealer
    {
        private const double CustomBaseHealth = 50;
        private const double CustomArmor = 25;
        private const double CustomAbilitypoints = 40;
        private static Bag bag = new Backpack();

        public Priest(string name)
            : base(name, CustomBaseHealth, CustomArmor, CustomAbilitypoints)
        {
            this.Bag = bag;
        }

        public void Heal(Character character)
        {
            this.EnsureAlive();

            if (this.IsAlive && character.IsAlive)
            {
                character.Health += this.AbilityPoints;
            }
        }
    }
}
