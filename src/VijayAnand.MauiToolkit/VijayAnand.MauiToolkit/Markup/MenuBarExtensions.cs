namespace VijayAnand.MauiToolkit.Markup;

public static partial class MenuBarExtensions
{
#if NET8_0_OR_GREATER
    /// <summary>Defines a menu item separator.</summary>
    public static TMenuBarItem AddMenuSeparator<TMenuBarItem>(this TMenuBarItem menuBar)
        where TMenuBarItem : IMenuBarItem
    {
        menuBar.Add(new MenuFlyoutSeparator());
        return menuBar;
    }
#endif
}
