using System;
using AdventureTool.Plugin.Router.Interfaces;

namespace AdventureTool.Plugin.Router
{
    internal class ActionRouteHandler : IRouteHandler
    {
        private readonly Func<IRoutingContext, IRequestResult> _action;

        public ActionRouteHandler(Func<IRoutingContext, IRequestResult> action)
        {
            _action = action;
        }

        public IRequestResult HandleRoute(IRoutingContext ctx)
        {
            return _action?.Invoke(ctx);
        }
    }
}