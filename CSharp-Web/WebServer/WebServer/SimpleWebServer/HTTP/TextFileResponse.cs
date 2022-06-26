using System.IO;
using System.Threading.Tasks;

namespace SimpleWebServer.Server.HTTP
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
            //Task.Run(async () =>
            //    {
            //        if (File.Exists(FileName))
            //        {
            //            this.Body = await File.ReadAllTextAsync(FileName);


            //        }
            //    });

            if (File.Exists(FileName))
            {
                this.Body = File.ReadAllTextAsync(FileName).Result;

                long fileBytesCount = new FileInfo(FileName).Length;
                this.Headers.Add(Header.ContentLength, fileBytesCount.ToString());

                this.Headers.Add(
                    Header.ContentDisposition, $"attachment; filename=\"{FileName}\"");
            }

            return base.ToString();
        }
    }
}
