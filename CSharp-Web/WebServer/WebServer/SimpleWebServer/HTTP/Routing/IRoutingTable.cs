using System;

namespace SWS.Server.HTTP.Routing
{
    public interface IRoutingTable
    {
        IRoutingTable Map(string path, Method method, Func<Request, Response> responseFunction); // function that controller should give
        IRoutingTable MapGet(string path, Func<Request, Response> responseFunction);
        IRoutingTable MapPost(string path, Func<Request, Response> responseFunction);
    }
}
