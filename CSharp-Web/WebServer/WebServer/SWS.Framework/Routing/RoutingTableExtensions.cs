using SWS.Server.HTTP;
using SWS.Server.HTTP.Routing;
using System;

namespace SWS.Framework.Routing
{
    using SWS.Framework.Controller;

    public static class RoutingTableExtensions
    {
        public static IRoutingTable MapGet<TContoller>(
            this IRoutingTable routingTable,
            string path,
            Func<TContoller, Response> controllerFunction) where TContoller : Controller
        {
            return routingTable.MapGet(path, request => controllerFunction(
                CreateController<TContoller>(request)));
        }

        public static IRoutingTable MapPost<TContoller>(
            this IRoutingTable routingTable,
            string path,
            Func<TContoller, Response> controllerFunction) where TContoller : Controller
        {
            return routingTable.MapPost(path, request => controllerFunction(
                CreateController<TContoller>(request)));
        }

        private static TController CreateController<TController>(Request request)
        {
            return (TController)Activator.CreateInstance(typeof(TController), new[] { request});
        }
    }
}
