using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using AdventureTool.Plugin.Router.Extensions;
using AdventureTool.Plugin.Router.Interfaces;

namespace AdventureTool.Plugin.Router
{
    public class RouteBuilder : IRouteHandler, IRouteBuilder
    {
        private readonly IList<IRouteHandler> _routes = new List<IRouteHandler>();

        public IDisposable Add(IRouteHandler handler)
        {
            _routes.Add(handler);

            return Disposable.Create(() => _routes.Remove(handler));
        }

        public IDisposable AddSegment(IRouteBuilder routeBuilder, string segment, Action<SegmentHandler> registerViews)
        {
            var handler = new SegmentHandler(routeBuilder as IRouteHandler);

            if (!segment.EndsWith("/"))
                segment += "/";

            registerViews(handler);

            return this.MapRoute(context =>
            {
                var segContext = new SegmentalContext(context);
                segContext.Next();

                if (segContext.Current == segment)
                {
                    segContext.Next();
                    return handler.HandleRoute(segContext);
                }

                return null;
            });
        }

        public IRequestResult HandleRoute(IRoutingContext ctx)
        {
            //TODO: Allow also Exception Results
            return _routes.Reverse().Select(handler => handler.HandleRoute(ctx)).FirstOrDefault(result => result != null);
        }
    }
}