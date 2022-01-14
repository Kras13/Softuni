namespace FootballTeamGenerator
{
    public class Stat
    {
        public Stat(double value, string type)
        {
            this.Value = value;
            this.Type = type;
        }

        public double Value { get; set; }

        public string Type { get; set; }
    }
}
