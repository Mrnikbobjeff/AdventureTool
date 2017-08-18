using System.Collections.Generic;

namespace AdventureTool.Plugin.Navigation.Interfaces
{
    public interface INavigator
    {
        void PushView<T>(Dictionary<string, string> parameters) where T : IParameter;
        void ShowModal<T>(Dictionary<string, string> parameters) where T : IParameter;
        void PushOnRootViewController<T>(Dictionary<string, string> parameters) where T : IParameter;
        void GoBack();
    }
}