using SimpleWebServer.Tools;
using System.Threading.Tasks;
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

        public async Task Log(string message)
        {
            await consoleLogger.Log(message);
            await fileLogger.Log(message);
        }

        public async Task LogLine(string message)
        {
            await consoleLogger.LogLine(message);
            await fileLogger.LogLine(message);
        }

        public void Flush()
        {
            this.fileLogger.Flush();
        }
    }
}
