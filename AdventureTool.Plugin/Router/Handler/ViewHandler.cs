using System.Collections.Generic;
using AdventureTool.Plugin.Navigation.Interfaces;
using AdventureTool.Plugin.Router.Interfaces;
using PortableRazor.Web;
using Splat;

namespace AdventureTool.Plugin.Router.Handler
{
    public class ViewHandler
    {
        public IRequestResult RequestView<T>(IRoutingContext routingContext) where T : IParameter
        {
            var navigator = Locator.CurrentMutable.GetService<INavigator>();
            var parameters = new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(routingContext.Uri.Query))
            {
                var query = routingContext.Uri.Query;
                parameters = HttpUtility.ParseQueryString(query);
            }

            navigator.PushView<T>(parameters);
            return RequestResult.Empty;
        }

        public IRequestResult ShowModal<T>(IRoutingContext routingContext) where T : IParameter
        {
            var navigator = Locator.CurrentMutable.GetService<INavigator>();
            var parameters = new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(routingContext.Uri.Query))
            {
                var query = routingContext.Uri.Query;
                parameters = HttpUtility.ParseQueryString(query);
            }

            navigator.ShowModal<T>(parameters);
            return RequestResult.Empty;
        }

        public IRequestResult PushOnRootViewController<T>(IRoutingContext routingContext) where T : IParameter
        {
            var navigator = Locator.CurrentMutable.GetService<INavigator>();
            var parameters = new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(routingContext.Uri.Query))
            {
                var query = routingContext.Uri.Query;
                parameters = HttpUtility.ParseQueryString(query);
            }

            navigator.PushOnRootViewController<T>(parameters);
            return RequestResult.Empty;
        }
    }
}