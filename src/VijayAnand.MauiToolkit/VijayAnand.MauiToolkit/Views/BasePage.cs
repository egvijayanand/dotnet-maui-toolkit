namespace VijayAnand.MauiToolkit.Views;

/// <summary>
/// Base class for .NET MAUI page definition with Typed ViewModel.
/// </summary>
public class BasePage : MauiPage
{
    public BasePage()
    {
        SetBinding(TitleProperty, new Binding(nameof(BaseViewModel.Title)));
        SetBinding(AsyncProperty, new Binding(nameof(BaseViewModel.Async)));
        SetBinding(IsWaitingProperty, new Binding(nameof(BaseViewModel.IsBusy)));
        SetBinding(LoadingMessageProperty, new Binding(nameof(BaseViewModel.StatusMessage)));
    }

    /// <summary>
    /// Instance of an ViewModel that is bound to this View.
    /// </summary>
    public BaseViewModel? ViewModel { get; set; }

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
