using SimpleWebServer.Tools;

namespace WebServer
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            System.Console.Write(message);
        }

        public void LogLine(string message)
        {
            System.Console.WriteLine(message);
        }
    }
}
