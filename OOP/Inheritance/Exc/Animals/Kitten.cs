namespace Animals
{
    public class Kitten : Cat
    {
        private const string defaultGender = "Female";
        public override string ProduceSound()
        {
            return "Meow";
        }

        public Kitten(string name, int age)
            : base(name, age, defaultGender)
        {
        }
    }
}
