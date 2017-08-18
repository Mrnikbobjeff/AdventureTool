namespace AdventureTool.Plugin.Router.Interfaces
{
    public interface IRouteHandler
    {
        IRequestResult HandleRoute(IRoutingContext ctx);
    }
}