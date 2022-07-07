using System;

namespace SWS.Server.HTTP
{
    public class TextResponse : ContentResponse
    {
        public TextResponse(string content, Action<Request, Response> preRenderAction = null) 
            : base(content, ContentType.PlainText, preRenderAction)
        {
        }
    }
}
