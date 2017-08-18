using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Disposables;
using System.Threading.Tasks;
using AdventureTool.Plugin.Navigation.Interfaces;
using AdventureTool.Plugin.Router;
using AdventureTool.Plugin.ViewModelBase;
using ReactiveUI;
using Splat;

namespace AdventureTool.Plugin
{
    public abstract class BaseViewModel : ReactiveObject, IViewModel, IParameter, IDisposable
    {
        protected IRouter Router { get; }
        public ReactiveCommand<Unit, bool> GoBack { get; set; }
        public ReactiveCommand<Unit, Unit> AppFromBackground { get; set; }
        public IDictionary<string, string> Parameters { get; set; }

        protected readonly CompositeDisposable disposable = new CompositeDisposable();
        protected BaseViewModel()
        {
            Router = Locator.CurrentMutable.GetService<IRouter>();
            GoBack = ReactiveCommand.CreateFromTask<Unit, bool>((_, ct) => GoBackImplementation());
            GoBack.ThrownExceptions.Subscribe(ex =>
            {
                //TODO Logging
            });

            AppFromBackground = ReactiveCommand.Create(AppFromBackgroundImplementation);
            AppFromBackground.ThrownExceptions.Subscribe(ex =>
            {
                //TODO Logging
            });
        }

        private async Task<bool> GoBackImplementation()
        {
            var success = await HandleGoBack();

            if(!success)
            {
                //Show dialog
            }

            return success;
        }

        private Unit AppFromBackgroundImplementation()
        {
            return Unit.Default;
        }

        public virtual Task InitializeAsync() { return Task.Factory.StartNew(() => {}); }

        public virtual void Update(Dictionary<string, string> parameter) { }

        public virtual Task<bool> HandleGoBack() { return Task.Run(() => false); }

        public void Dispose()
        {
            try
            {
                disposable.Clear();
            }
            catch(Exception ex)
            {
                //TODO Log Error
            }
        }
    }
}
