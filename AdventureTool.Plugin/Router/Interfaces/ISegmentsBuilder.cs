using System;

namespace AdventureTool.Plugin.Router.Interfaces
{
    public interface ISegmentsBuilder
    {
        IDisposable Add(string name, IRouteHandler handler);
    }
}