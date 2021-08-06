using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> data;

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => data.Count;

        public Race(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            data = new List<Racer>();
        }

        public void Add(Racer Racer)
        {
            if (data.Count < Capacity)
            {
                data.Add(Racer);
            }
        }

        public bool Remove(string name)
        {
            if (data.Any(r => r.Name == name))
            {
                Racer selectedRacer = data.First(r => r.Name == name);
                data.Remove(selectedRacer);
                return true;
            }
            return false;
        }

        public Racer GetOldestRacer()
        {
            return data.OrderByDescending(r => r.Age).First();
        }

        public Racer GetRacer(string name)
        {
            return data.FirstOrDefault(r => r.Name == name);
        }

        public Racer GetFastestRacer()
        {
            return data.OrderBy(r => r.Car.Speed).Last();
        }

        public string Report()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Racers participating at {this.Name}:");

            foreach (var racer in data)
            {
                stringBuilder.AppendLine(racer.ToString());
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
