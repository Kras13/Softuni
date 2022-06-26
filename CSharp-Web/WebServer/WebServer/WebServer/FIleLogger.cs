using SimpleWebServer.Tools;
using System;
using System.IO;
using System.Text;

namespace SimpleWebServer.ConsoleApp
{
    public class FIleLogger : ILogger
    {
        private readonly BufferedStream bufferedStream;

        public FIleLogger(string filePath)
        {
            FileStream baseStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            this.bufferedStream = new BufferedStream(baseStream);
        }

        public void Log(string message)
        {
            byte[] bytesToWrite = Encoding.UTF8.GetBytes(message);

            bufferedStream.Write(bytesToWrite, 0, bytesToWrite.Length);
        }

        public void LogLine(string message)
        {
            byte[] bytesToWrite = Encoding.UTF8.GetBytes(message);
            byte[] newLine = Encoding.UTF8.GetBytes("\r\n");

            bufferedStream.Write(bytesToWrite, 0, bytesToWrite.Length);
            bufferedStream.Write(newLine, 0, newLine.Length);
        }

        public void Flush()
        {
            this.bufferedStream.Flush();
        }
    }
}