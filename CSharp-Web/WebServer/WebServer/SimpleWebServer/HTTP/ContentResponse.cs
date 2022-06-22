using SimpleWebServer.Server.Common;
using System;
using System.Text;

namespace SimpleWebServer.Server.HTTP
{
    public class ContentResponse : Response
    {
        public ContentResponse(string content, string contentType, Action<Request, Response> preRenderAction = null)
            : base(StatusCode.OK)
        {
            Guard.AgainstNull(content, nameof(content));
            Guard.AgainstNull(contentType, nameof(contentType));

            this.PreRenderAction = preRenderAction;
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
