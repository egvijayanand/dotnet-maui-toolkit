namespace VijayAnand.MauiToolkit.Markup
{
    public static class MenuGroupExtensions
    {
        public static TMenuBarItem Title<TMenuBarItem>(this TMenuBarItem topMenu, string value)
            where TMenuBarItem : MenuBarItem
        {
            topMenu.Text = value;
            return topMenu;
        }

        public static TMenuBarItem Enabled<TMenuBarItem>(this TMenuBarItem topMenu, bool value = true)
            where TMenuBarItem : MenuBarItem
        {
            topMenu.IsEnabled = value;
            return topMenu;
        }

        public static TMenuBarItem AddMenuGroup<TMenuBarItem>(this TMenuBarItem topMenu, IMenuFlyoutSubItem menuGroup)
            where TMenuBarItem : MenuBarItem
        {
            topMenu.Add(menuGroup);
            return topMenu;
        }

        public static TMenuFlyoutSubItem AddMenuItem<TMenuFlyoutSubItem>(this TMenuFlyoutSubItem topMenu, IMenuFlyoutItem menuItem)
            where TMenuFlyoutSubItem : MenuBarItem
        {
            topMenu.Add(menuItem);
            return topMenu;
        }

        public static TMenuFlyoutSubItem AddSubMenuItem<TMenuFlyoutSubItem>(this TMenuFlyoutSubItem menuGroup, IMenuFlyoutItem menuItem)
            where TMenuFlyoutSubItem : MenuFlyoutSubItem
        {
            menuGroup.Add(menuItem);
            return menuGroup;
        }
    }
}
