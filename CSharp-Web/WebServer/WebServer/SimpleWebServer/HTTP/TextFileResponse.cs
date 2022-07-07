using System.IO;
using System.Threading.Tasks;

namespace SWS.Server.HTTP
{
    public class TextFileResponse : Response
    {
        public TextFileResponse(string fileName)
            : base(StatusCode.OK)
        {
            this.FileName = fileName;

            this.Headers.Add(Header.ContentType, ContentType.PlainText);
        }

        public string FileName { get; set; }

        public override string ToString()
        {
            Task task = new Task(async () =>
            {
                if (File.Exists(FileName))
                {
                    this.Body = await File.ReadAllTextAsync(FileName);
                    long fileBytesCount = new FileInfo(FileName).Length;
                    this.Headers.Add(Header.ContentLength, fileBytesCount.ToString());

                    this.Headers.Add(
                        Header.ContentDisposition, $"attachment; filename=\"{FileName}\"");
                }
            });

            task.Start();
            task.Wait();

            return base.ToString();

            //if (File.Exists(FileName))
            //{
            //    this.Body = File.ReadAllTextAsync(FileName).Result;

            //    long fileBytesCount = new FileInfo(FileName).Length;
            //    this.Headers.Add(Header.ContentLength, fileBytesCount.ToString());

            //    this.Headers.Add(
            //        Header.ContentDisposition, $"attachment; filename=\"{FileName}\"");
            //}

            //return base.ToString();
        }
    }
}
