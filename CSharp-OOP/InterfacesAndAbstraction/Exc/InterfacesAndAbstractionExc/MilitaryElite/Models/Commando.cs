using MilitaryElite.Contracts;
using MilitaryElite.Enums;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private List<IMission> missions;

        public Commando(string firstName, string lastName, string id, decimal salary, Corps corps)
            : base(firstName, lastName, id, salary, corps)
        {
            this.missions = new List<IMission>();
        }

        public IReadOnlyCollection<IMission> Missions => this.missions.AsReadOnly();

        public void AddMission(IMission mission)
        {
            this.missions.Add(mission);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {Corps}");
            sb.AppendLine("Missions:");

            foreach (var mission in missions)
            {
                sb.AppendLine($"  {mission}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
