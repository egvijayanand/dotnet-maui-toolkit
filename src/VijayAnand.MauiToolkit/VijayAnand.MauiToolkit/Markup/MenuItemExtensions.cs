namespace VijayAnand.MauiToolkit.Markup
{
    public static class MenuItemExtensions
    {
        public static TMenuItem Accelerator<TMenuItem>(this TMenuItem menuItem, string value)
            where TMenuItem : BaseMenuItem
        {
            menuItem.SetValue(MenuItem.AcceleratorProperty, value);
            return menuItem;
        }

        public static TMenuItem Title<TMenuItem>(this TMenuItem menuItem, string value)
            where TMenuItem : BaseMenuItem
        {
            menuItem.SetValue(MenuItem.TextProperty, value);
            return menuItem;
        }

        public static TMenuItem Enabled<TMenuItem>(this TMenuItem menuItem, bool value = true)
            where TMenuItem : BaseMenuItem
        {
            menuItem.SetValue(MenuItem.IsEnabledProperty, value);
            return menuItem;
        }

        public static TMenuItem Destructive<TMenuItem>(this TMenuItem menuItem, bool value = true)
            where TMenuItem : MenuItem
        {
            menuItem.SetValue(MenuItem.IsDestructiveProperty, value);
            return menuItem;
        }
    }
}
