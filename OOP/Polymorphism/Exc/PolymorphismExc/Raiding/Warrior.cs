namespace Raiding
{
    public class Warrior : BaseHero
    {
        private const int warriorPower = 100;

        public Warrior(string name)
            : base(name, warriorPower)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
