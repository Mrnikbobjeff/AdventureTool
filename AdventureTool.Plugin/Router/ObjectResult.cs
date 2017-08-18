using AdventureTool.Plugin.Router.Interfaces;

namespace AdventureTool.Plugin.Router
{
    internal class ObjectResult : IRequestResult
    {
        public object Value { get; }

        public ObjectResult(object value)
        {
            Value = value;
        }
    }
}