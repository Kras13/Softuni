using System;

namespace Telephony
{
    public static class Validator
    {
        public static void CallingValidating(string number, string message)
        {
            foreach (char ch in number)
            {
                if (!char.IsDigit(ch))
                {
                    throw new InvalidOperationException(message);
                }
            }
        }

        public static void BrowsingValidator(string number, string message)
        {
            foreach (char ch in number)
            {
                if (char.IsDigit(ch))
                {
                    throw new InvalidOperationException(message);
                }
            }
        }
    }
}
