using SWS.Server.Common;
using SWS.Server.Responses;
using System;
using System.Collections.Generic;

namespace SWS.Server.HTTP.Routing
{
    public class RoutingTable : IRoutingTable
    {
        private readonly Dictionary<Method, Dictionary<string, Func<Request, Response>>> routes;

        public RoutingTable()
        {
            this.routes = new Dictionary<Method, Dictionary<string, Func<Request, Response>>>()
            {
                [Method.Get] = new Dictionary<string, Func<Request, Response>>(),
                [Method.Post] = new Dictionary<string, Func<Request, Response>>(),
                [Method.Put] = new Dictionary<string, Func<Request, Response>>(),
                [Method.Delete] = new Dictionary<string, Func<Request, Response>>()
            };
        }

        public IRoutingTable Map(
            string path,
            Method method,
            Func<Request, Response> responseFunction)
        {
            Guard.AgainstNull(path, nameof(path));
            Guard.AgainstNull(responseFunction, nameof(responseFunction));

            this.routes[method][path] = responseFunction;

            return this;
        }

        public IRoutingTable MapGet(string path, Func<Request, Response> responseFunction)
        {
            return this.Map(path, Method.Get, responseFunction);
        }

        public IRoutingTable MapPost(string path, Func<Request, Response> responseFunction)
        {
            return this.Map(path, Method.Post, responseFunction);
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

            Func<Request, Response> responsFunction = this.routes[requestMethod][requestUrl];

            return responsFunction(request);
        }
    }
}
