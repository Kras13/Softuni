using System.Threading.Tasks;

namespace SWS.Tools
{
    public interface ILogger
    {
        Task Log(string message);

        Task LogLine(string message);

        void Flush();
    }
}
