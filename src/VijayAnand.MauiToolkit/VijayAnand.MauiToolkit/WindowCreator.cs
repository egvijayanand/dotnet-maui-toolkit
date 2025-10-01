namespace VijayAnand.MauiToolkit;

/// <summary>
/// Provides functionality to create and manage a specific instance of a window.
/// </summary>
/// <typeparam name="TWindow">The type of the window to be created. Must derive from <see cref="Window"/>.</typeparam>
/// <param name="window">Window instance.</param>
internal sealed class WindowCreator<TWindow>(TWindow window) : IWindowCreator
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
internal sealed class WindowCreator<TWindow, TPage>(TWindow window) : IWindowCreator
    where TWindow : Window
    where TPage : Page
{
    public Window CreateWindow(Application app, IActivationState? activationState)
    {
        window.Page ??= AppService.GetRequiredService<TPage>();
        return window;
    }
}
