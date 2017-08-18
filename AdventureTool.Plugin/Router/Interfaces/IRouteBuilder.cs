using System;

namespace AdventureTool.Plugin.Router.Interfaces
{
    public interface IRouteBuilder
    {
        IDisposable Add(IRouteHandler handler);

        IDisposable AddSegment(IRouteBuilder routeBuilder, string segment, Action<SegmentHandler> registerViews);
    }
}