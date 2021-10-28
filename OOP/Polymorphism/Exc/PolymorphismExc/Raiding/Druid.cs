namespace Raiding
{
    public class Druid : BaseHero
    {
        private const int druidPower = 80;

        public Druid(string name)
            : base(name, druidPower)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} healed for {Power}";
        }
    }
}
