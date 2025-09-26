namespace VijayAnand.MauiToolkit.Markup;

public static class MenuItemExtensions
{
#if !NET10_0_OR_GREATER
    /// <summary>Defines an accelerator for the menu item.</summary>
#if NET8_0_OR_GREATER
    [Obsolete("Use MenuFlyoutItem.KeyboardAcceleratorsProperty (or the MapKey markup method) instead.")]
#endif
    public static TMenuItem Accelerator<TMenuItem>(this TMenuItem menuItem, string value)
        where TMenuItem : MenuItem
    {
        menuItem.SetValue(MenuItem.AcceleratorProperty, value);
        return menuItem;
    }

    /// <summary>Defines a title for the menu item.</summary>
    public static TMenuItem Title<TMenuItem>(this TMenuItem menuItem, string value)
        where TMenuItem : MenuItem
    {
        menuItem.Text = value;
        return menuItem;
    }
#endif

    /// <summary>Defines whether the menu item is enabled or not.</summary>
    public static TMenuItem Enabled<TMenuItem>(this TMenuItem menuItem, bool value = true)
        where TMenuItem : MenuItem
    {
        menuItem.IsEnabled = value;
        return menuItem;
    }

    /// <summary>Defines whether the menu item is destructive or not.</summary>
    public static TMenuItem Destructive<TMenuItem>(this TMenuItem menuItem, bool value = true)
        where TMenuItem : MenuItem
    {
        menuItem.IsDestructive = value;
        return menuItem;
    }

#if NET8_0_OR_GREATER
    /// <summary>Defines a keyboard accelerator for a menu/sub-menu item.</summary>
    public static TMenuFlyoutItem MapKey<TMenuFlyoutItem>(this TMenuFlyoutItem menuFlyoutItem, KeyboardAcceleratorModifiers modifiers, string? key)
        where TMenuFlyoutItem : MenuFlyoutItem
    {
        menuFlyoutItem.KeyboardAccelerators.Add(new KeyboardAccelerator()
        {
            Modifiers = modifiers,
            Key = key
        });

        return menuFlyoutItem;
    }
#endif
}
