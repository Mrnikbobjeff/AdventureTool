using AdventureTool.Plugin.Router.Interfaces;

namespace AdventureTool.Plugin.Router
{
    public class RequestResult : IRequestResult
    {
        public static readonly IRequestResult Empty = new RequestResult();

        public static IRequestResult FromValue(object value)
        {
            return new ObjectResult(value);
        }

        internal RequestResult()
        {
        }
    }
}