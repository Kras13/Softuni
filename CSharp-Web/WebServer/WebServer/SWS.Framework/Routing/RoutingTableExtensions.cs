using SWS.Server.HTTP;
using SWS.Server.HTTP.Routing;
using System;

namespace SWS.Framework.Routing
{
    using SWS.Framework.Controller;

    public static class RoutingTableExtensions
    {
        internal class MediumClass<TController> where TController : Controller
        {
            Func<TController, Response> _selectedControllerFunction;

            internal MediumClass(Func<TController, Response> selectedControllerFunction)
            {
                _selectedControllerFunction = selectedControllerFunction;
            }

            private TController CreateController(Request request)
            {
                return (TController)Activator.CreateInstance(typeof(TController), new[] { request });
            }

            internal Response RoutingAction(Request request)
            {
                var currentController = this.CreateController(request);

                return _selectedControllerFunction(currentController);
            }
        }

        public static IRoutingTable MapGet<TController>(
            this IRoutingTable routingTable,
            string path,
            Func<TController, Response> controllerFunction) where TController : Controller
        {
            var mediumClass = new MediumClass<TController>(controllerFunction);

            return routingTable.MapGet(path, mediumClass.RoutingAction);
        }        

        public static IRoutingTable MapPost<TController>(
            this IRoutingTable routingTable,
            string path,
            Func<TController, Response> controllerFunction) where TController : Controller
        {
            var mediumClass = new MediumClass<TController>(controllerFunction);

            return routingTable.MapPost(path, mediumClass.RoutingAction);
        }
    }
}
