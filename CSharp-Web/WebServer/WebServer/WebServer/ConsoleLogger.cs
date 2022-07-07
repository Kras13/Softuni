using SWS.Tools;
using System.Threading.Tasks;

namespace WebServer
{
    public class ConsoleLogger : ILogger
    {
        public void Flush()
        {
            
        }

        public async Task Log(string message)
        {
            System.Console.Write(message);
        }

        public async Task LogLine(string message)
        {
            System.Console.WriteLine(message);
        }
    }
}
