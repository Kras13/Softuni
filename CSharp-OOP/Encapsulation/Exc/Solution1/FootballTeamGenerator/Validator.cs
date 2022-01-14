using System;

namespace FootballTeamGenerator
{
    public static class Validator
    {
        public static void ThrowIfNameIsInvalid(string name, string exceptionMessage)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(exceptionMessage);
            }
        }

        public static void ThrowIfStatNotValid(double score, string exceptionMessage)
        {
            if (score < 0 || score > 100)
            {
                throw new ArgumentException(exceptionMessage);
            }
        }
    }
}
