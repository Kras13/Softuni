namespace Raiding
{
    public class Rogue : BaseHero
    {
        private const int roguePower = 80;

        public Rogue(string name)
            : base(name, roguePower)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
