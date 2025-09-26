namespace VijayAnand.MauiToolkit;

/// <summary>
/// Provides functionality to create and manage a specific instance of a window.
/// </summary>
/// <typeparam name="TWindow">The type of the window to be created. Must derive from <see cref="Window"/>.</typeparam>
/// <param name="window"></param>
internal sealed class WindowCreator<TWindow>(TWindow window) : IWindowCreator
    where TWindow : Window
{
    public Window CreateWindow(Application app, IActivationState? activationState) => window;
}
