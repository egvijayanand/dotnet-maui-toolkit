namespace VijayAnand.MauiToolkit.Markup
{
    public static class MenuItemExtensions
    {
        /// <summary>Defines an accelerator for the menu item.</summary>
        public static TMenuItem Accelerator<TMenuItem>(this TMenuItem menuItem, string value)
            where TMenuItem : BaseMenuItem
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
    }
}
