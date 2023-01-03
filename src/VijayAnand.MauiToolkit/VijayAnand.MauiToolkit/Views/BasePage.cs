namespace VijayAnand.MauiToolkit.Views
{
    /// <summary>
    /// Base class for .NET MAUI page definition with Typed ViewModel.
    /// </summary>
    public class BasePage : ContentPage
    {
        public static readonly BindableProperty AsyncProperty =
            BindableProperty.Create(nameof(Async),
                                    typeof(bool),
                                    typeof(BasePage),
                                    default(bool));

        /// <summary>
        /// If set to true, the Initialize method that is invoked in the OnAppearing will be in async mode.
        /// </summary>
        public bool Async
        {
            get => (bool)GetValue(AsyncProperty);
            set => SetValue(AsyncProperty, value);
        }

        /// <summary>
        /// Instance of an ViewModel that is bound to this View.
        /// </summary>
        public BaseViewModel? ViewModel { get; set; }

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
}
