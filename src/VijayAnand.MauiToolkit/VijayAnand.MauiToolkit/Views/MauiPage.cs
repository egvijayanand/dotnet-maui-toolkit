namespace VijayAnand.MauiToolkit.Views
{
    /// <summary>
    /// Generic base class for .NET MAUI page definition with an instance of ViewModel bound to this View.
    /// </summary>
    /// <typeparam name="TViewModel">The type of the ViewModel.</typeparam>
    public class MauiPage<TViewModel> : MauiPage where TViewModel : class, IViewModel
    {
        public MauiPage()
        {
            ViewModel = AppService.GetService<TViewModel>();
            BindingContext = ViewModel;
        }

        public MauiPage(TViewModel viewModel)
        {
            ViewModel = viewModel;
            BindingContext = ViewModel;
        }

        /// <summary>
        /// If set to true, the Initialize method that is invoked in the OnAppearing will be in async mode.
        /// </summary>
        public bool Async { get; set; }

        /// <summary>
        /// Instance of an ViewModel that is bound to this View.
        /// </summary>
        public TViewModel? ViewModel { get; protected set; }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

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
    public class MauiPage : ContentPage
    {

    }
}
