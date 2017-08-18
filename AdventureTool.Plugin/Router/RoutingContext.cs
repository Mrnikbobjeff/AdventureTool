using System;
using AdventureTool.Plugin.Router.Interfaces;

namespace AdventureTool.Plugin.Router
{
    internal class RoutingContext : IRoutingContext
    {
        public Uri Uri { get; }

        public string Query => Uri.Query;

        public RoutingContext(Uri uri)
        {
            //var uri = Uri.IsWellFormedUriString(route, UriKind.Relative);
            Uri = uri;
        }
    }
}