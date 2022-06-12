using SimpleWebServer.Server.Common;
using SimpleWebServer.Server.Responses;
using System;
using System.Collections.Generic;

namespace SimpleWebServer.Server.HTTP.Routing
{
    public class RoutingTable : IRoutingTable
    {
        private readonly Dictionary<Method, Dictionary<string, Response>> routes;

        public RoutingTable()
        {
            this.routes = new Dictionary<Method, Dictionary<string, Response>>()
            {
                [Method.Get] = new Dictionary<string, Response>(),
                [Method.Post] = new Dictionary<string, Response>(),
                [Method.Put] = new Dictionary<string, Response>(),
                [Method.Delete] = new Dictionary<string, Response>()
            };
        }

        public IRoutingTable Map(string url, Method method, Response response)
        {
            switch (method)
            {
                case Method.Get:
                    return this.MapGet(url, response);
                case Method.Post:
                    throw new InvalidOperationException($"{method} is not a supported method!");
                case Method.Put:
                    throw new InvalidOperationException($"{method} is not a supported method!");
                case Method.Delete:
                    throw new InvalidOperationException($"{method} is not a supported method!");
                default:
                    throw new InvalidOperationException($"{method} is not a supported method!");
            }
        }

        public IRoutingTable MapGet(string url, Response response)
        {
            Guard.AgainstNull(url, nameof(url));
            Guard.AgainstNull(response, nameof(response));

            this.routes[Method.Get][url] = response;

            return this;
        }

        public IRoutingTable MapPost(string url, Response response)
        {
            Guard.AgainstNull(url, nameof(url));
            Guard.AgainstNull(response, nameof(response));

            this.routes[Method.Post][url] = response;

            return this;
        }

        public Response MatchRequest(Request request)
        {
            Method requestMethod = request.Method;
            string requestUrl = request.Url;

            if (!this.routes.ContainsKey(requestMethod) ||
                !this.routes[requestMethod].ContainsKey(requestUrl))
            {
                return new NotFoundResponse();
            }

            return this.routes[requestMethod][requestUrl];
        }
    }
}
