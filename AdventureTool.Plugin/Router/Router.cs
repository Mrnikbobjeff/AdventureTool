using System;
using System.Reactive.Subjects;
using AdventureTool.Plugin.Router.Interfaces;

namespace AdventureTool.Plugin.Router
{
    public class Router : IRouter
    {
        private readonly IRouteHandler _handler;
        private readonly ISubject<IRequestResult> _unhandledResults = new Subject<IRequestResult>();
        private readonly Uri _baseUri = new Uri("wiloTeamApp://", UriKind.Absolute);

        public Router(IRouteHandler handler)
        {
            _handler = handler;
            //_unhandledResults.Subscribe(result =>
            //{
            //    throw new RouteNotFoundException("No route found. Please register a route on the Router via AddSegment or AddView");
            //});
        }

        public void Call(string relativePath)
        {
            var result = CallInternal(relativePath);

            _unhandledResults.OnNext(result);
        }

        private IRequestResult CallInternal(string relativePath)
        {
            var result = _handler.HandleRoute(Uri.IsWellFormedUriString(relativePath, UriKind.Absolute) ? 
                new RoutingContext(new Uri(relativePath, UriKind.Absolute)) : 
                new RoutingContext(new Uri(_baseUri, relativePath)));

            return result;
        }
    }
}