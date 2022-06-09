using System;

namespace SimpleWebServer.Server.Common
{
    public static class Guard
    {
        public static void AgainstNull(object value, string name = null)
        {
            if (value == null)
            {
                if (name == null)
                {
                    name = "Value";
                }

                throw new InvalidOperationException($"{name} cannot be null!");
            }
        }
    }
}
