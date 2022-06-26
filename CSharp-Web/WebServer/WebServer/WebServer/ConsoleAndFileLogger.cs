using SimpleWebServer.Tools;
using WebServer;

namespace SimpleWebServer.ConsoleApp
{
    public class ConsoleAndFileLogger : ILogger
    {
        private readonly ConsoleLogger consoleLogger;
        private readonly FIleLogger fileLogger;

        public ConsoleAndFileLogger(
            ConsoleLogger consoleLogger, FIleLogger fIleLogger)
        {
            this.consoleLogger = consoleLogger;
            this.fileLogger = fIleLogger;
        }

        public void Log(string message)
        {
            consoleLogger.Log(message);
            fileLogger.Log(message);
        }

        public void LogLine(string message)
        {
            consoleLogger.LogLine(message);
            fileLogger.LogLine(message);
        }

        public void Flush()
        {
            this.fileLogger.Flush();
        }
    }
}
