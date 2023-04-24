using System.ComponentModel;

namespace VijayAnand.MauiToolkit.Views
{
    /// <summary>
    /// Generic base class for .NET MAUI page definition with an instance of ViewModel bound to this View.
    /// </summary>
    /// <typeparam name="TViewModel">The type of the ViewModel.</typeparam>
    public class MauiPage<TViewModel> : MauiPage
        where TViewModel : class, INotifyPropertyChanged, IViewModel
    {
        public MauiPage()
        {
            SetBinding(TitleProperty, new Binding(nameof(IViewModel.Title)));
            SetBinding(AsyncProperty, new Binding(nameof(IViewModel.Async)));
            SetBinding(IsWaitingProperty, new Binding(nameof(IViewModel.IsBusy)));
            SetBinding(LoadingMessageProperty, new Binding(nameof(IViewModel.StatusMessage)));
            ViewModel = AppService.GetService<TViewModel>();
            BindingContext = ViewModel;
        }

        public MauiPage(TViewModel viewModel)
        {
            SetBinding(TitleProperty, new Binding(nameof(IViewModel.Title)));
            SetBinding(AsyncProperty, new Binding(nameof(IViewModel.Async)));
            SetBinding(IsWaitingProperty, new Binding(nameof(IViewModel.IsBusy)));
            SetBinding(LoadingMessageProperty, new Binding(nameof(IViewModel.StatusMessage)));
            ViewModel = viewModel;
            BindingContext = ViewModel;
        }

        /// <summary>
        /// Instance of an ViewModel that is bound to this View.
        /// </summary>
        public TViewModel? ViewModel { get; protected set; }

        protected override async void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);

            if (Async)
            {
                if (ViewModel is not null)
                {
                    await ViewModel.InitializeAsync();
                }
            }
            else
            {
                ViewModel?.Initialize();
            }
        }
    }

    /// <summary>
    /// Base class for .NET MAUI page definition.
    /// </summary>
    public class MauiPage : WaitingPage
    {
        public static readonly BindableProperty AsyncProperty =
            BindableProperty.Create(nameof(Async), typeof(bool), typeof(MauiPage), false);

        /// <summary>
        /// If set to true, the Initialize method that is invoked in the OnAppearing will be in async mode.
        /// </summary>
        public bool Async
        {
            get => (bool)GetValue(AsyncProperty);
            set => SetValue(AsyncProperty, value);
        }
    }
}
