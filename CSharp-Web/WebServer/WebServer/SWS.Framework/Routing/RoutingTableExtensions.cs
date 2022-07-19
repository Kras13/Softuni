using SWS.Server.HTTP;
using SWS.Server.HTTP.Routing;
using System;

namespace SWS.Framework.Routing
{
    using SWS.Framework.Controller;

    public static class RoutingTableExtensions
    {
        class PortClass
        {
            private  Response _response;
            private Controller _controller;

            private Func<Controller, Response> _controllerFunction;

            protected PortClass(
                Response response, 
                Controller controller,
                Func<Controller, Response> controllerFunction)
            {
                this._response = response;
                this._controller = controller;
                this._controllerFunction = controllerFunction;
            }

            public void InitController()
            {

            }

            public Response MainInvokeFunc(Request request)
            {

                // TODO -> create controller with the request
                // TODO -> call the givenfunction with the controller

                return _response;
            }

            private TController CreateController<TController>(Request request)
            {
                return (TController)Activator.CreateInstance(typeof(TController), new[] { request });
            }
        }

        public static IRoutingTable MapGet<TController>(
            this IRoutingTable routingTable,
            string path,
            Func<TController, Response> controllerFunction) where TController : Controller
        {
            return routingTable.MapGet(path, request => controllerFunction(
                CreateController<TController>(request)));
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
            return (TController)Activator.CreateInstance(typeof(TController), new[] { request });
        }
    }
}
