namespace VijayAnand.MauiToolkit.Markup
{
    public static class MenuItemExtensions
    {
        // Common        
        public static TMenuItem Accelerator<TMenuItem>(this TMenuItem menuItem, string value)
            where TMenuItem : BaseMenuItem
        {
            menuItem.SetValue(MenuItem.AcceleratorProperty, value);
            return menuItem;
        }

        public static TMenuItem Title<TMenuItem>(this TMenuItem menuItem, string value)
            where TMenuItem : MenuItem
        {
            menuItem.Text = value;
            return menuItem;
        }

        public static TMenuItem Enabled<TMenuItem>(this TMenuItem menuItem, bool value = true)
            where TMenuItem : MenuItem
        {
            menuItem.IsEnabled = value;
            return menuItem;
        }

        public static TMenuItem Destructive<TMenuItem>(this TMenuItem menuItem, bool value = true)
            where TMenuItem : MenuItem
        {
            menuItem.IsDestructive = value;
            return menuItem;
        }
    }
}
