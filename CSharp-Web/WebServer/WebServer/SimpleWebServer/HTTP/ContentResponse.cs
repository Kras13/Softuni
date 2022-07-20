using SWS.Server.Common;
using System;
using System.Text;

namespace SWS.Server.HTTP
{
    public class ContentResponse : Response
    {
        public ContentResponse(string content, string contentType)
            : base(StatusCode.OK)
        {
            Guard.AgainstNull(content, nameof(content));
            Guard.AgainstNull(contentType, nameof(contentType));

            this.Headers.Add(Header.ContentType, contentType);
            this.Body = content;
        }

        public override string ToString()
        {
            if (this.Body != null)
            {
                string contentLength = Encoding.UTF8.GetByteCount(this.Body).ToString();
                this.Headers.Add(Header.ContentLength, contentLength);
            }

            return base.ToString();
        }
    }
}
