using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using AdventureTool.Plugin.Router.Interfaces;

namespace AdventureTool.Plugin.Router
{
    public class SegmentHandler : IRouteHandler, ISegmentsBuilder
    {
        private readonly IRouteHandler _parent;
        private readonly IDictionary<string, IRouteHandler> _handlers = new Dictionary<string, IRouteHandler>();

        public SegmentHandler(IRouteHandler parent)
        {
            _parent = parent;
        }

        public IRequestResult HandleRoute(IRoutingContext ctx)
        {
            var segmental = ctx as SegmentalContext ?? new SegmentalContext(ctx);
            if (segmental.Current == "/")
            {
                if (_parent != null)
                    _parent.HandleRoute(segmental);
                else
                {
                    segmental.Next();
                    return HandleRoute(segmental);
                }
            }
            else if (_handlers.ContainsKey(segmental.Current))
            {
                var handler = _handlers[segmental.Current];

                segmental.Next();
                return handler.HandleRoute(segmental);
            }

            return null;
        }

        public IDisposable Add(string name, IRouteHandler handler)
        {
            _handlers[name] = handler;

            return Disposable.Create(() => _handlers.Remove(name));
        }
    }
}