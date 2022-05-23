namespace VijayAnand.Toolkit.Markup
{
    public static class ShellExtensions
    {
        // Flyout Items

        public static FlyoutItem FlyoutEntry(string title,
                                             DataTemplate dataTemplate,
                                             string route,
                                             ImageSource? icon = null)
        {
            return new FlyoutItem()
            {
                Items =
                {
                    new ShellContent()
                    {
                        ContentTemplate = dataTemplate,
                        Route = route
                    }
                },
                Title = title,
                Icon = icon
            };
        }

        public static FlyoutItem FlyoutEntry(string title,
                                             Func<object> loadTemplate,
                                             string route,
                                             ImageSource? icon = null)
        {
            return new FlyoutItem()
            {
                Items =
                {
                    new ShellContent()
                    {
                        ContentTemplate = new DataTemplate(loadTemplate),
                        Route = route
                    }
                },
                Title = title,
                Icon = icon
            };
        }

        // Tab Items

        public static Tab TabEntry(string title,
                                   DataTemplate dataTemplate,
                                   string route,
                                   ImageSource? icon = null)
        {
            return new Tab()
            {
                Items =
                {
                    new ShellContent()
                    {
                        ContentTemplate = dataTemplate,
                        Route = route
                    }
                },
                Title = title,
                Icon = icon
            };
        }

        public static Tab TabEntry(string title,
                                   Func<object> loadTemplate,
                                   string route,
                                   ImageSource? icon = null)
        {
            return new Tab()
            {
                Items =
                {
                    new ShellContent()
                    {
                        ContentTemplate = new DataTemplate(loadTemplate),
                        Route = route
                    }
                },
                Title = title,
                Icon = icon
            };
        }

        public static ShellContent FlyoutEntry(DataTemplate dataTemplate, string route)
        {
            return new ShellContent()
            {
                ContentTemplate = dataTemplate,
                Route = route
            };
        }

        public static ShellContent FlyoutEntry(Func<object> loadTemplate, string route)
        {
            return new ShellContent()
            {
                ContentTemplate = new DataTemplate(loadTemplate),
                Route = route
            };
        }

        // Menu Item

        public static MenuItem MenuEntry(string title, ImageSource? icon = null)
        {
            return new MenuItem() { Text = title, IconImageSource = icon };
        }
    }
}
