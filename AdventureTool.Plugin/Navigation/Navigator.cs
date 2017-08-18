using System.Collections.Generic;
using AdventureTool.Plugin.Navigation.Interfaces;

namespace AdventureTool.Plugin.Navigation
{
    public abstract class Navigator : INavigator 
    {
        public abstract void PushView<T>(Dictionary<string,string> parameters) where T : IParameter;
        public abstract void ShowModal<T>(Dictionary<string, string> parameters) where T : IParameter;
        public abstract void PushOnRootViewController<T>(Dictionary<string, string> parameters) where T : IParameter;
        public abstract void GoBack();
    }
}
