namespace VijayAnand.MauiToolkit.Views;

[ContentProperty(nameof(Content))]
public partial class WaitingPage : ContentPage
{
    private ContentView _pageContent;

    #region Bindable Properties

    public static readonly BindableProperty IsWaitingProperty
        = BindableProperty.Create(nameof(IsWaiting), typeof(bool), typeof(WaitingPage), false);

    public static readonly BindableProperty LoadingMessageProperty
        = BindableProperty.Create(nameof(LoadingMessage), typeof(string), typeof(WaitingPage), "Loading ...");

    public static readonly BindableProperty ShowLoadingViewProperty =
        BindableProperty.Create(nameof(ShowLoadingView), typeof(bool), typeof(WaitingPage), false);

    public static readonly BindableProperty ShowLoadingMessageProperty =
        BindableProperty.Create(nameof(ShowLoadingMessage), typeof(bool), typeof(WaitingPage), false);

    public static readonly BindableProperty ShadeBackgroundProperty =
        BindableProperty.Create(nameof(ShadeBackground), typeof(bool), typeof(WaitingPage), false);

    public static readonly BindableProperty StatusOrientationProperty =
        BindableProperty.Create(nameof(StatusOrientation), typeof(StatusOrientation), typeof(WaitingPage), StatusOrientation.Horizontal);

    public static new readonly BindableProperty ContentProperty
        = BindableProperty.Create(nameof(Content), typeof(View), typeof(WaitingPage), null, BindingMode.TwoWay);

    #endregion

    public WaitingPage()
    {
        Resources.Add("OrientationConverter", new EnumToBoolConverter());
        Resources.Add("StatusOrientationConverter", new StatusOrientationConverter());
        Resources.Add("ShadedBgColorConverter", new BoolToObjectConverter()
        {
            TrueObject = Black.MultiplyAlpha(0.2f),
            FalseObject = Transparent
        });
        Resources.Add("BorderBgColorConverter", new BoolToObjectConverter()
        {
            TrueObject = Application.Current!.UserAppTheme switch
            {
                AppTheme.Dark => Color.Parse("#121212"),
                _ => White
            },
            FalseObject = Transparent
        });
        Resources.Add("BorderColorConverter", new BoolToObjectConverter()
        {
            TrueObject = Gray,
            FalseObject = Transparent
        });

#if NET9_0_OR_GREATER
        _pageContent = new ContentView();

        var horizontalIndicator = new ActivityIndicator();
        horizontalIndicator.SetBinding(ActivityIndicator.IsRunningProperty, static (WaitingPage page) => page.IsWaiting, source: this);
        horizontalIndicator.SetBinding(ActivityIndicator.IsVisibleProperty, static (WaitingPage page) => page.StatusOrientation, converter: (IValueConverter)Resources["OrientationConverter"], converterParameter: StatusOrientation.Horizontal, source: this);
        horizontalIndicator.SetBinding(ActivityIndicator.IsRunningProperty, static (WaitingPage page) => page.IsWaiting, source: this);

        var loadingMessage = new Label()
        {
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
        };

        loadingMessage.SetBinding(Label.TextProperty, static (WaitingPage page) => page.LoadingMessage, source: this);
        loadingMessage.SetBinding(Label.IsVisibleProperty, static (WaitingPage page) => page.ShowLoadingMessage, source: this);

        var verticalTopIndicator = new ActivityIndicator();
        verticalTopIndicator.SetBinding(ActivityIndicator.IsRunningProperty, static (WaitingPage page) => page.IsWaiting, source: this);
        verticalTopIndicator.SetBinding(ActivityIndicator.IsVisibleProperty, static (WaitingPage page) => page.StatusOrientation, converter: (IValueConverter)Resources["OrientationConverter"], converterParameter: StatusOrientation.VerticalTop, source: this);

        var verticalBottomIndicator = new ActivityIndicator();
        verticalBottomIndicator.SetBinding(ActivityIndicator.IsRunningProperty, static (WaitingPage page) => page.IsWaiting, source: this);
        verticalBottomIndicator.SetBinding(ActivityIndicator.IsVisibleProperty, static (WaitingPage page) => page.StatusOrientation, converter: (IValueConverter)Resources["OrientationConverter"], converterParameter: StatusOrientation.VerticalBottom, source: this);

        var stack = new StackLayout()
        {
            Spacing = 15,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            Children =
            {
                horizontalIndicator,
                verticalTopIndicator,
                loadingMessage,
                verticalBottomIndicator
            }
        };

        stack.SetBinding(StackLayout.OrientationProperty, static (WaitingPage page) => page.StatusOrientation, converter: (IValueConverter)Resources["StatusOrientationConverter"], source: this);

        var borderView = new Border()
        {
            Padding = 20,
            StrokeShape = new RoundRectangle()
            {
                CornerRadius = 5
            },
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            Content = stack
        };

        borderView.SetBinding(Border.BackgroundColorProperty, static (WaitingPage page) => page.ShowLoadingView, converter: (IValueConverter)Resources["BorderBgColorConverter"], source: this);
        borderView.SetBinding(Border.StrokeProperty, static (WaitingPage page) => page.ShowLoadingView, converter: (IValueConverter)Resources["BorderColorConverter"], source: this);
        borderView.SetBinding(Border.ShadowProperty, static (WaitingPage page) => page.ShowLoadingView, source: this);

        var container = new Grid()
        {
            Children =
            {
                borderView
            }
        };

        container.SetBinding(Grid.BackgroundColorProperty, static (WaitingPage page) => page.ShadeBackground, converter: (IValueConverter)Resources["ShadedBgColorConverter"], source: this);
        container.SetBinding(Grid.IsVisibleProperty, static (WaitingPage page) => page.IsWaiting, source: this);

        base.Content = new Grid()
        {
            Children =
            {
                _pageContent,
                container
            }
        };

        this.SetBinding(ContentProperty, static (WaitingPage page) => page.Content, source: this);
#else
        _pageContent = new ContentView();

        var horizontalIndicator = new ActivityIndicator();
        horizontalIndicator.SetBinding(ActivityIndicator.IsRunningProperty, new Binding(nameof(IsWaiting), source: this));
        horizontalIndicator.SetBinding(ActivityIndicator.IsVisibleProperty, new Binding(nameof(StatusOrientation), converter: (IValueConverter)Resources["OrientationConverter"], converterParameter: StatusOrientation.Horizontal, source: this));

        var loadingMessage = new Label()
        {
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
        };

        loadingMessage.SetBinding(Label.TextProperty, new Binding(nameof(LoadingMessage), source: this));
        loadingMessage.SetBinding(Label.IsVisibleProperty, new Binding(nameof(ShowLoadingMessage), source: this));

        var verticalTopIndicator = new ActivityIndicator();
        verticalTopIndicator.SetBinding(ActivityIndicator.IsRunningProperty, new Binding(nameof(IsWaiting), source: this));
        verticalTopIndicator.SetBinding(ActivityIndicator.IsVisibleProperty, new Binding(nameof(StatusOrientation), converter: (IValueConverter)Resources["OrientationConverter"], converterParameter: StatusOrientation.VerticalTop, source: this));

        var verticalBottomIndicator = new ActivityIndicator();
        verticalBottomIndicator.SetBinding(ActivityIndicator.IsRunningProperty, new Binding(nameof(IsWaiting), source: this));
        verticalBottomIndicator.SetBinding(ActivityIndicator.IsVisibleProperty, new Binding(nameof(StatusOrientation), converter: (IValueConverter)Resources["OrientationConverter"], converterParameter: StatusOrientation.VerticalBottom, source: this));

        var stack = new StackLayout()
        {
            Spacing = 15,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            Children =
            {
                horizontalIndicator,
                verticalTopIndicator,
                loadingMessage,
                verticalBottomIndicator
            }
        };

        stack.SetBinding(StackLayout.OrientationProperty, new Binding(nameof(StatusOrientation), converter: (IValueConverter)Resources["StatusOrientationConverter"], source: this));

        var borderView = new Border()
        {
            Padding = 20,
            StrokeShape = new RoundRectangle()
            {
                CornerRadius = 5
            },
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            Content = stack
        };

        borderView.SetBinding(Border.BackgroundColorProperty, new Binding(nameof(ShowLoadingView), converter: (IValueConverter)Resources["BorderBgColorConverter"], source: this));
        borderView.SetBinding(Border.StrokeProperty, new Binding(nameof(ShowLoadingView), converter: (IValueConverter)Resources["BorderColorConverter"], source: this));
        borderView.SetBinding(Border.ShadowProperty, new Binding(nameof(ShowLoadingView), source: this));

        var container = new Grid()
        {
            Children =
            {
                borderView
            }
        };

        container.SetBinding(Grid.BackgroundColorProperty, new Binding(nameof(ShadeBackground), converter: (IValueConverter)Resources["ShadedBgColorConverter"], source: this));
        container.SetBinding(Grid.IsVisibleProperty, new Binding(nameof(IsWaiting), source: this));

        base.Content = new Grid()
        {
            Children =
            {
                _pageContent,
                container
            }
        };

        SetBinding(ContentProperty, new Binding(nameof(Content), source: this));
#endif
    }

    #region Properties

    public bool IsWaiting
    {
        get => (bool)GetValue(IsWaitingProperty);
        set => SetValue(IsWaitingProperty, value);
    }

    public string LoadingMessage
    {
        get => (string)GetValue(LoadingMessageProperty);
        set => SetValue(LoadingMessageProperty, value);
    }

    public bool ShowLoadingMessage
    {
        get => (bool)GetValue(ShowLoadingMessageProperty);
        set => SetValue(ShowLoadingMessageProperty, value);
    }

    public bool ShowLoadingView
    {
        get => (bool)GetValue(ShowLoadingViewProperty);
        set => SetValue(ShowLoadingViewProperty, value);
    }

    public bool ShadeBackground
    {
        get => (bool)GetValue(ShadeBackgroundProperty);
        set => SetValue(ShadeBackgroundProperty, value);
    }

    public StatusOrientation StatusOrientation
    {
        get => (StatusOrientation)GetValue(StatusOrientationProperty);
        set => SetValue(StatusOrientationProperty, value);
    }

    public new View Content
    {
        get => _pageContent.Content;
        set => _pageContent.Content = value;
    }

    #endregion
}
