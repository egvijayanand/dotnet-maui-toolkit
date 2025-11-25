namespace VijayAnand.MauiToolkit;

/// <summary>
/// Provides functionality to create and manage a specific instance of a window.
/// </summary>
/// <param name="window">Window instance.</param>
internal sealed class WindowCreator(Window window) : IWindowCreator
{
    public Window CreateWindow(Application app, IActivationState? activationState) => window;
}

/// <summary>
/// Provides functionality to create and manage a specific instance of a window.
/// </summary>
/// <typeparam name="TWindow">The type of the window to be created. Must derive from <see cref="Window"/>.</typeparam>
/// <param name="window">Window instance.</param>
internal sealed class WindowCreator<TWindow>([FromKeyedServices(Startup)] TWindow window) : IWindowCreator
    where TWindow : Window
{
    public Window CreateWindow(Application app, IActivationState? activationState) => window;
}

/// <summary>
/// Provides functionality to create and manage a specific instance of a window with a specified page.
/// </summary>
/// <typeparam name="TWindow">The type of the window to be created. Must derive from <see cref="Window"/>.</typeparam>
/// <typeparam name="TPage">The type of the page to be created. Must derive from <see cref="Page"/>.</typeparam>
/// <param name="window">Window instance.</param>
internal sealed class WindowCreator<TWindow, TPage>([FromKeyedServices(Startup)] TWindow window) : IWindowCreator
    where TWindow : Window
    where TPage : Page
{
    public static Action<TWindow>? ConfigureWindow { get; set; }

    public Window CreateWindow(Application app, IActivationState? activationState)
    {
        window.Page ??= AppService.GetKeyedService<TPage>(Startup, true);

        if (window.Page is { } page && string.IsNullOrEmpty(window.Title))
        {
            window.Title = page.Title;
        }

        ConfigureWindow?.Invoke(window);

        return window;
    }
}
