namespace VijayAnand.MauiToolkit.Markup
{
    public static class MenuGroupExtensions
    {
        /// <summary>Defines a title for the top level menu item.</summary>
        public static TMenuBarItem Title<TMenuBarItem>(this TMenuBarItem topMenu, string value)
            where TMenuBarItem : MenuBarItem
        {
            topMenu.Text = value;
            return topMenu;
        }

        /// <summary>Defines whether the top level menu item is enabled or not.</summary>
        public static TMenuBarItem Enabled<TMenuBarItem>(this TMenuBarItem topMenu, bool value = true)
            where TMenuBarItem : MenuBarItem
        {
            topMenu.IsEnabled = value;
            return topMenu;
        }

        /// <summary>Defines a top level menu group.</summary>
        public static TMenuBarItem AddMenuGroup<TMenuBarItem>(this TMenuBarItem topMenu, IMenuFlyoutSubItem menuGroup)
            where TMenuBarItem : MenuBarItem
        {
            topMenu.Add(menuGroup);
            return topMenu;
        }

        /// <summary>Defines a sub menu group within a menu group.</summary>
        public static TMenuFlyoutSubItem AddSubMenuGroup<TMenuFlyoutSubItem>(this TMenuFlyoutSubItem parentMenu, IMenuFlyoutSubItem subMenuGroup)
            where TMenuFlyoutSubItem : MenuFlyoutSubItem
        {
            parentMenu.Add(subMenuGroup);
            return parentMenu;
        }

        /// <summary>Defines a menu item.</summary>
        public static TMenuFlyoutSubItem AddMenuItem<TMenuFlyoutSubItem>(this TMenuFlyoutSubItem topMenu, IMenuFlyoutItem menuItem)
            where TMenuFlyoutSubItem : MenuBarItem
        {
            topMenu.Add(menuItem);
            return topMenu;
        }

        /// <summary>Defines a sub menu item within a menu group.</summary>
        public static TMenuFlyoutSubItem AddSubMenuItem<TMenuFlyoutSubItem>(this TMenuFlyoutSubItem menuGroup, IMenuFlyoutItem menuItem)
            where TMenuFlyoutSubItem : MenuFlyoutSubItem
        {
            menuGroup.Add(menuItem);
            return menuGroup;
        }
    }
}
