namespace VijayAnand.MauiToolkit.Markup
{
    public static class MenuItemExtensions
    {
        public static TMenuItem Accelerator<TMenuItem>(this TMenuItem menuItem, string value)
            where TMenuItem : MenuItem
        {
            menuItem.SetValue(MenuItem.AcceleratorProperty, value);
            return menuItem;
        }
    }
}
