namespace VijayAnand.Toolkit.Markup
{
    public static class MenuItemExtensions
    {
        public static TMenuItem Text<TMenuItem>(this TMenuItem menuItem, string value)
            where TMenuItem : MenuItem
        {
            menuItem.Text = value;
            return menuItem;
        }
    }
}
