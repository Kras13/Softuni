﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleWebServer.Server.HTTP
{
    public class Request
    {
        public Method Method { get; private set; }

        public string Url { get; set; }

        public HeaderCollection Headers { get; set; }

        public string Body { get; set; }

        public static Request Parse(string request)
        {
            string[] lines = request.Split("\r\n");

            string[] firstLine = lines[0].Split(' ');
            Method method = ParseMethod(firstLine[0]);
            string url = firstLine[1];

            HeaderCollection headers = ParseHeaders(lines.Skip(1));

            string[] bodyLines = lines.Skip(headers.Count + 2).ToArray();

            string body = string.Join("\r\n", bodyLines);

            return new Request()
            {
                Method = method,
                Url = url,
                Body = body,
                Headers = headers
            };
        }

        private static HeaderCollection ParseHeaders(IEnumerable<string> headerLines)
        {
            HeaderCollection headers = new HeaderCollection();

            foreach (var headerLine in headerLines)
            {
                if (headerLine == string.Empty)
                {
                    break;
                }

                string[] headerParts = headerLine.Split(":", 2);

                if (headerParts.Length != 2)
                {
                    throw new InvalidOperationException("Request is not valid.");
                }

                string headerName = headerParts[0];
                string headerValue = headerParts[1].Trim();

                headers.Add(headerName, headerValue);
            }

            return headers;
        }

        private static Method ParseMethod(string method)
        {
            try
            {
                return (Method)Enum.Parse(typeof(Method), method, true);
            }
            catch (System.Exception)
            {
                throw new InvalidOperationException($"Method '{method}' is not supported!");
            }
        }
    }
}
