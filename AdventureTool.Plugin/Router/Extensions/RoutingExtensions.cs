using System;
using System.Reactive.Disposables;
using AdventureTool.Plugin.Navigation.Interfaces;
using AdventureTool.Plugin.Router.Handler;
using AdventureTool.Plugin.Router.Interfaces;

namespace AdventureTool.Plugin.Router.Extensions
{
    public static class RoutingExtensions
    {
        public static IDisposable MapRoute(this IRouteBuilder builder, Func<IRoutingContext, IRequestResult> action)
        {
            return builder.Add(new ActionRouteHandler(action));
        }

        public static IDisposable MapRoute(this IRouteBuilder builder, Action<IRoutingContext> action)
        {
            return builder.Add(new ActionRouteHandler(ctx =>
            {
                action(ctx);
                return RequestResult.Empty;
            }));
        }

        public static IDisposable Add(this ISegmentsBuilder builder, string segment, Func<IRoutingContext, IRequestResult> action)
        {
            return builder.Add(segment, new ActionRouteHandler(action));
        }

        public static IDisposable AddView<T>(this ISegmentsBuilder builder, string segment, string defaultMethodName = null) where T : IParameter
        {
            var handler = new ViewHandler();

            var defaultDisp = builder.Add(segment, handler.RequestView<T>);
            //var methodDisp = builder.Add(segment + "/", ctx => handler.HandleMethodInvoke(ctx));

            return Disposable.Create(() =>
            {
                defaultDisp.Dispose();
            });
        }

        public static IDisposable ShowModal<T>(this ISegmentsBuilder builder, string segment, string defaultMethodName = null) where T : IParameter
        {
            var handler = new ViewHandler();

            var defaultDisp = builder.Add(segment, handler.ShowModal<T>);
            //var methodDisp = builder.Add(segment + "/", ctx => handler.HandleMethodInvoke(ctx));

            return Disposable.Create(() =>
            {
                defaultDisp.Dispose();
            });
        }

        public static IDisposable PushOnRootViewController<T>(this ISegmentsBuilder builder, string segment, string defaultMethodName = null) where T : IParameter
        {
            var handler = new ViewHandler();

            var defaultDisp = builder.Add(segment, handler.PushOnRootViewController<T>);
            //var methodDisp = builder.Add(segment + "/", ctx => handler.HandleMethodInvoke(ctx));

            return Disposable.Create(() =>
            {
                defaultDisp.Dispose();
            });
        }
    }
}