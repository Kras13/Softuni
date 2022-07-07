using SWS.Tools;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SWS.ConsoleApp
{
    public class FIleLogger : ILogger
    {
        //private readonly BufferedStream bufferedStream;
        //private readonly FileStream fileStream;
        private string filePath;

        public FIleLogger(string filePath)
        {
            //FileStream baseStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            //this.bufferedStream = new BufferedStream(baseStream);

            //this.fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
            this.filePath = filePath;
        }

        public async Task Log(string message)
        {
            //byte[] bytesToWrite = Encoding.UTF8.GetBytes(message);

            //await fileStream.WriteAsync(bytesToWrite, 0, bytesToWrite.Length);

            //await File.WriteAllTextAsync(filePath, message);

            using (var fileStream = new FileStream(filePath, FileMode.Append, FileAccess.Write))
            {
                byte[] bytesToWrite = Encoding.UTF8.GetBytes(message);
                byte[] newLine = Encoding.UTF8.GetBytes("\r\n");

                await fileStream.WriteAsync(bytesToWrite, 0, bytesToWrite.Length);
                await fileStream.WriteAsync(newLine, 0, newLine.Length);
            }
        }

        public async Task LogLine(string message)
        {
            using (var fileStream = new FileStream(filePath, FileMode.Append, FileAccess.Write))
            {
                byte[] bytesToWrite = Encoding.UTF8.GetBytes(message);
                byte[] newLine = Encoding.UTF8.GetBytes("\r\n");

                await fileStream.WriteAsync(bytesToWrite, 0, bytesToWrite.Length);
                await fileStream.WriteAsync(newLine, 0, newLine.Length);
            }
        }

        public void Flush()
        {
            //this.fileStream.Flush();
        }
    }
}