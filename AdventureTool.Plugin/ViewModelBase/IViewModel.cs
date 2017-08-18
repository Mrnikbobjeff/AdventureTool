using System.Reactive;
using System.Threading.Tasks;
using ReactiveUI;

namespace AdventureTool.Plugin.ViewModelBase
{
    public interface IViewModel
    {
        Task InitializeAsync();
	
        ReactiveCommand<Unit, bool> GoBack { get; set; }

        Task<bool> HandleGoBack();
    }
}