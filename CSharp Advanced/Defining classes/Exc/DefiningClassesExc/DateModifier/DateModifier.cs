using System;

namespace DefiningClasses
{
    public class DateModifier
    {
        public string DiffernceInDates(string first, string second)
        {
            string result = null;

            DateTime firstDate = DateTime.Parse(first);
            DateTime secondDate = DateTime.Parse(second);

            if (secondDate > firstDate)
            {
                result = (secondDate - firstDate).Days.ToString();
            }
            else
            {
                result = (firstDate - secondDate).Days.ToString();
            }

            return result;
        }
    }
}
