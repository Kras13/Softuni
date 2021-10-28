using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> family;

        public Family()
        {
            this.family = new List<Person>();
        }

        public void AddMember(Person member)
        {
            family.Add(member);
        }

        public Person GetOldestMember()
        {
            Person oldestPerson = new Person();

            oldestPerson = family.OrderByDescending(per => per.Age).FirstOrDefault();

            return oldestPerson;
        }
    }
}
