using SimpleWebServer.Tools;
using System;
using System.IO;

namespace SimpleWebServer.ConsoleApp
{
    class FIleLogger : ILogger
    {
        private readonly FileStream fileStream;
        public FIleLogger(string filePath)
        {
            this.fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
        }

        public void Log(string message)
        {
            throw new NotImplementedException();
        }

        public void LogLine(string message)
        {
            throw new NotImplementedException();
        }
    }
}
