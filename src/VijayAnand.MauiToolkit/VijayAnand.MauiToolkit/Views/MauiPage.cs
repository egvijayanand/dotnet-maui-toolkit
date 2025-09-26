using System.ComponentModel;

namespace VijayAnand.MauiToolkit.Views;

/// <summary>
/// Generic base class for .NET MAUI page definition with an instance of ViewModel bound to this View.
/// </summary>
/// <typeparam name="TViewModel">The type of the ViewModel.</typeparam>
public partial class MauiPage<TViewModel> : MauiPage
    where TViewModel : class, INotifyPropertyChanged, IViewModel
{
    public MauiPage()
    {
        ConfigureBindings();
        ViewModel = AppService.GetService<TViewModel>();
        BindingContext = ViewModel;
    }

    public MauiPage(TViewModel viewModel)
    {
        ConfigureBindings();
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
                await ViewModel.InitializeAsync(Parameter);
            }
        }
        else
        {
            ViewModel?.Initialize(Parameter);
        }
    }

    private void ConfigureBindings()
    {
#if NET9_0_OR_GREATER
        this.SetBinding(TitleProperty, static (IViewModel vm) => vm.Title);
        this.SetBinding(AsyncProperty, static (IViewModel vm) => vm.Async);
        this.SetBinding(IsWaitingProperty, static (IViewModel vm) => vm.IsBusy);
        this.SetBinding(LoadingMessageProperty, static (IViewModel vm) => vm.StatusMessage);
#else
        SetBinding(TitleProperty, new Binding(nameof(IViewModel.Title)));
        SetBinding(AsyncProperty, new Binding(nameof(IViewModel.Async)));
        SetBinding(IsWaitingProperty, new Binding(nameof(IViewModel.IsBusy)));
        SetBinding(LoadingMessageProperty, new Binding(nameof(IViewModel.StatusMessage)));
#endif
    }
}

/// <summary>
/// Base class for .NET MAUI page definition.
/// </summary>
public partial class MauiPage : WaitingPage
{
    public object? Parameter { get; protected set; }

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
