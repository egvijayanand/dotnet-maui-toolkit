namespace VijayAnand.Toolkit.Markup
{
    public static class ViewInGridExtensions
    {
        const string Default = nameof(Default);
        const string OnIdiom = nameof(OnIdiom);
        const string OnPlatform = nameof(OnPlatform);

        // Grid Spacing

        public static TGrid RowSpacing<TGrid>(this TGrid gridLayout, double value)
            where TGrid : Grid
        {
            gridLayout.RowSpacing = value;
            return gridLayout;
        }

        public static TGrid ColumnSpacing<TGrid>(this TGrid gridLayout, double value)
            where TGrid : Grid
        {
            gridLayout.ColumnSpacing = value;
            return gridLayout;
        }

        // Grid Rows and Columns

        public static TGrid Rows<TGrid>(this TGrid gridLayout, params GridLength[] heights)
            where TGrid : Grid
        {
            var rows = new RowDefinitionCollection();

            foreach (var height in heights)
            {
                rows.Add(new RowDefinition { Height = height });
            }

            gridLayout.RowDefinitions = rows;
            return gridLayout;
        }

        public static TGrid Columns<TGrid>(this TGrid gridLayout, params GridLength[] widths)
            where TGrid : Grid
        {
            var columns = new ColumnDefinitionCollection();

            foreach (var width in widths)
            {
                columns.Add(new ColumnDefinition { Width = width });
            }

            gridLayout.ColumnDefinitions = columns;
            return gridLayout;
        }

        public static TView Row<TView, TRow>(this TView view, TRow row, int span)
            where TView : View
            where TRow : Enum
        {
            int rowIndex = row.ToInt();
            view.SetValue(Grid.RowProperty, rowIndex);
            view.SetValue(Grid.RowSpanProperty, span);
            return view;
        }

        public static TView Column<TView, TColumn>(this TView view, TColumn column, int span)
            where TView : View
            where TColumn : Enum
        {
            int columnIndex = column.ToInt();
            view.SetValue(Grid.ColumnProperty, columnIndex);
            view.SetValue(Grid.ColumnSpanProperty, span);
            return view;
        }

        public static TView Row<TView>(this TView view, string markup)
            where TView : View
        {
            if (markup.StartsWith("{") && markup.EndsWith("}"))
            {
                var content = markup[1..^1];
                string markupId = content[..content.IndexOf("\x20")];

                if (!(markupId == OnIdiom || markupId == OnPlatform))
                {
                    throw new ArgumentOutOfRangeException(nameof(markup), "Currently only OnIdiom and OnPlatform markup extension format is supported.");
                }

                var options = new Dictionary<string, int>();

                var matches = Regex.Matches(content, @"(?'key'\w+)\s*\=\s*((\'(?'value'[^\']+)\')+|(?'value'\w+)+)");

                foreach (Match match in matches)
                {
                    if (match.Success)
                    {
                        options.Add(match.Groups["key"].Value, match.Groups["value"].Value.ToInt());
                    }
                }

                int rowIndex;

                if (markupId == OnIdiom)
                {
#if NETSTANDARD2_0
                    rowIndex = Device.Idiom switch
                    {
                        TargetIdiom.Unsupported => options.ContainsKey(nameof(TargetIdiom.Unsupported))
                                                        ? options[nameof(TargetIdiom.Unsupported)]
                                                        : options[Default],
                        TargetIdiom.Phone => options.ContainsKey(nameof(TargetIdiom.Phone))
                                                        ? options[nameof(TargetIdiom.Phone)]
                                                        : options[Default],
                        TargetIdiom.Tablet => options.ContainsKey(nameof(TargetIdiom.Tablet))
                                                        ? options[nameof(TargetIdiom.Tablet)]
                                                        : options[Default],
                        TargetIdiom.Desktop => options.ContainsKey(nameof(TargetIdiom.Desktop))
                                                        ? options[nameof(TargetIdiom.Desktop)]
                                                        : options[Default],
                        TargetIdiom.TV => options.ContainsKey(nameof(TargetIdiom.TV))
                                                        ? options[nameof(TargetIdiom.TV)]
                                                        : options[Default],
                        TargetIdiom.Watch => options.ContainsKey(nameof(TargetIdiom.Watch))
                                                        ? options[nameof(TargetIdiom.Watch)]
                                                        : options[Default],
                        _ => options[Default],
                    };
#elif NET6_0_OR_GREATER
                    rowIndex = DeviceInfo.Idiom.ToString() switch
                    {
                        nameof(DeviceIdiom.Unknown) => options.ContainsKey(nameof(DeviceIdiom.Unknown))
                                                        ? options[nameof(DeviceIdiom.Unknown)]
                                                        : options[Default],
                        nameof(DeviceIdiom.Phone) => options.ContainsKey(nameof(DeviceIdiom.Phone))
                                                        ? options[nameof(DeviceIdiom.Phone)]
                                                        : options[Default],
                        nameof(DeviceIdiom.Tablet) => options.ContainsKey(nameof(DeviceIdiom.Tablet))
                                                        ? options[nameof(DeviceIdiom.Tablet)]
                                                        : options[Default],
                        nameof(DeviceIdiom.Desktop) => options.ContainsKey(nameof(DeviceIdiom.Desktop))
                                                        ? options[nameof(DeviceIdiom.Desktop)]
                                                        : options[Default],
                        nameof(DeviceIdiom.TV) => options.ContainsKey(nameof(DeviceIdiom.TV))
                                                        ? options[nameof(DeviceIdiom.TV)]
                                                        : options[Default],
                        nameof(DeviceIdiom.Watch) => options.ContainsKey(nameof(DeviceIdiom.Watch))
                                                        ? options[nameof(DeviceIdiom.Watch)]
                                                        : options[Default],
                        _ => options[Default],
                    };
#endif
                }
                else if (markupId == OnPlatform)
                {
#if NETSTANDARD2_0
                    rowIndex = Device.RuntimePlatform switch
                    {
                        Device.iOS => options.ContainsKey(nameof(Device.iOS))
                                                        ? options[nameof(Device.iOS)]
                                                        : options[Default],
                        Device.Android => options.ContainsKey(nameof(Device.Android))
                                                        ? options[nameof(Device.Android)]
                                                        : options[Default],
                        Device.UWP => options.ContainsKey(nameof(Device.UWP))
                                                        ? options[nameof(Device.UWP)]
                                                        : options[Default],
                        Device.macOS => options.ContainsKey(nameof(Device.macOS))
                                                        ? options[nameof(Device.macOS)]
                                                        : options[Default],
                        Device.GTK => options.ContainsKey(nameof(Device.GTK))
                                                        ? options[nameof(Device.GTK)]
                                                        : options[Default],
                        Device.Tizen => options.ContainsKey(nameof(Device.Tizen))
                                                        ? options[nameof(Device.Tizen)]
                                                        : options[Default],
                        Device.WPF => options.ContainsKey(nameof(Device.WPF))
                                                        ? options[nameof(Device.WPF)]
                                                        : options[Default],
                        _ => options[Default],
                    };
#elif NET6_0_OR_GREATER
                    rowIndex = DeviceInfo.Platform.ToString() switch
                    {
                        nameof(DevicePlatform.iOS) => options.ContainsKey(nameof(DevicePlatform.iOS))
                                                        ? options[nameof(DevicePlatform.iOS)]
                                                        : options[Default],
                        nameof(DevicePlatform.Android) => options.ContainsKey(nameof(DevicePlatform.Android))
                                                        ? options[nameof(DevicePlatform.Android)]
                                                        : options[Default],
                        nameof(DevicePlatform.WinUI) => options.ContainsKey(nameof(DevicePlatform.WinUI))
                                                        ? options[nameof(DevicePlatform.WinUI)]
                                                        : options[Default],
                        nameof(DevicePlatform.macOS) => options.ContainsKey(nameof(DevicePlatform.macOS))
                                                        ? options[nameof(DevicePlatform.macOS)]
                                                        : options[Default],
                        nameof(DevicePlatform.MacCatalyst) => options.ContainsKey(nameof(DevicePlatform.MacCatalyst))
                                                        ? options[nameof(DevicePlatform.MacCatalyst)]
                                                        : options[Default],
                        /*nameof(DevicePlatform.GTK) => options.ContainsKey(nameof(DevicePlatform.GTK))
                                                        ? options[nameof(DevicePlatform.GTK)]
                                                        : options[Default],*/
                        nameof(DevicePlatform.Tizen) => options.ContainsKey(nameof(DevicePlatform.Tizen))
                                                        ? options[nameof(DevicePlatform.Tizen)]
                                                        : options[Default],
                        /*nameof(DevicePlatform.WPF) => options.ContainsKey(nameof(DevicePlatform.WPF))
                                                        ? options[nameof(DevicePlatform.WPF)]
                                                        : options[Default],*/
                        _ => options[Default],
                    };
#endif
                }
                else
                {
                    // Added to remove the compiler error
                    throw new ArgumentOutOfRangeException(nameof(markup), "Currently only OnIdiom and OnPlatform markup extension format is supported.");
                }

                view.SetValue(Grid.RowProperty, rowIndex);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(markup), "Markup input is not in the expected format.");
            }

            return view;
        }

        public static TView Column<TView>(this TView view, string markup)
            where TView : View
        {
            if (markup.StartsWith("{") && markup.EndsWith("}"))
            {
                var content = markup[1..^1];

                string markupId = content.Substring(0, content.IndexOf("\x20"));

                if (!(markupId == OnIdiom || markupId == OnPlatform))
                {
                    throw new ArgumentOutOfRangeException(nameof(markup), "Currently only OnIdiom and OnPlatform markup extension format is supported.");
                }

                var options = new Dictionary<string, int>();

                var matches = Regex.Matches(content, @"(?'key'\w+)\s*\=\s*((\'(?'value'[^\']+)\')+|(?'value'\w+)+)");

                foreach (Match match in matches)
                {
                    if (match.Success)
                    {
                        options.Add(match.Groups["key"].Value, match.Groups["value"].Value.ToInt());
                    }
                }

                int columnIndex;

                if (markupId == OnIdiom)
                {
#if NETSTANDARD2_0
                    columnIndex = Device.Idiom switch
                    {
                        TargetIdiom.Unsupported => options.ContainsKey(nameof(TargetIdiom.Unsupported))
                                                        ? options[nameof(TargetIdiom.Unsupported)]
                                                        : options[Default],
                        TargetIdiom.Phone => options.ContainsKey(nameof(TargetIdiom.Phone))
                                                        ? options[nameof(TargetIdiom.Phone)]
                                                        : options[Default],
                        TargetIdiom.Tablet => options.ContainsKey(nameof(TargetIdiom.Tablet))
                                                        ? options[nameof(TargetIdiom.Tablet)]
                                                        : options[Default],
                        TargetIdiom.Desktop => options.ContainsKey(nameof(TargetIdiom.Desktop))
                                                        ? options[nameof(TargetIdiom.Desktop)]
                                                        : options[Default],
                        TargetIdiom.TV => options.ContainsKey(nameof(TargetIdiom.TV))
                                                        ? options[nameof(TargetIdiom.TV)]
                                                        : options[Default],
                        TargetIdiom.Watch => options.ContainsKey(nameof(TargetIdiom.Watch))
                                                        ? options[nameof(TargetIdiom.Watch)]
                                                        : options[Default],
                        _ => options[Default],
                    };
#elif NET6_0_OR_GREATER
                    columnIndex = DeviceInfo.Idiom.ToString() switch
                    {
                        nameof(DeviceIdiom.Unknown) => options.ContainsKey(nameof(DeviceIdiom.Unknown))
                                                        ? options[nameof(DeviceIdiom.Unknown)]
                                                        : options[Default],
                        nameof(DeviceIdiom.Phone) => options.ContainsKey(nameof(DeviceIdiom.Phone))
                                                        ? options[nameof(DeviceIdiom.Phone)]
                                                        : options[Default],
                        nameof(DeviceIdiom.Tablet) => options.ContainsKey(nameof(DeviceIdiom.Tablet))
                                                        ? options[nameof(DeviceIdiom.Tablet)]
                                                        : options[Default],
                        nameof(DeviceIdiom.Desktop) => options.ContainsKey(nameof(DeviceIdiom.Desktop))
                                                        ? options[nameof(DeviceIdiom.Desktop)]
                                                        : options[Default],
                        nameof(DeviceIdiom.TV) => options.ContainsKey(nameof(DeviceIdiom.TV))
                                                        ? options[nameof(DeviceIdiom.TV)]
                                                        : options[Default],
                        nameof(DeviceIdiom.Watch) => options.ContainsKey(nameof(DeviceIdiom.Watch))
                                                        ? options[nameof(DeviceIdiom.Watch)]
                                                        : options[Default],
                        _ => options[Default],
                    };
#endif
                }
                else if (markupId == OnPlatform)
                {
#if NETSTANDARD2_0
                    columnIndex = Device.RuntimePlatform switch
                    {
                        Device.iOS => options.ContainsKey(nameof(Device.iOS))
                                                        ? options[nameof(Device.iOS)]
                                                        : options[Default],
                        Device.Android => options.ContainsKey(nameof(Device.Android))
                                                        ? options[nameof(Device.Android)]
                                                        : options[Default],
                        Device.UWP => options.ContainsKey(nameof(Device.UWP))
                                                        ? options[nameof(Device.UWP)]
                                                        : options[Default],
                        Device.macOS => options.ContainsKey(nameof(Device.macOS))
                                                        ? options[nameof(Device.macOS)]
                                                        : options[Default],
                        Device.GTK => options.ContainsKey(nameof(Device.GTK))
                                                        ? options[nameof(Device.GTK)]
                                                        : options[Default],
                        Device.Tizen => options.ContainsKey(nameof(Device.Tizen))
                                                        ? options[nameof(Device.Tizen)]
                                                        : options[Default],
                        Device.WPF => options.ContainsKey(nameof(Device.WPF))
                                                        ? options[nameof(Device.WPF)]
                                                        : options[Default],
                        _ => options[Default],
                    };
#elif NET6_0_OR_GREATER
                    columnIndex = DeviceInfo.Platform.ToString() switch
                    {
                        nameof(DevicePlatform.iOS) => options.ContainsKey(nameof(DevicePlatform.iOS))
                                                        ? options[nameof(DevicePlatform.iOS)]
                                                        : options[Default],
                        nameof(DevicePlatform.Android) => options.ContainsKey(nameof(DevicePlatform.Android))
                                                        ? options[nameof(DevicePlatform.Android)]
                                                        : options[Default],
                        nameof(DevicePlatform.WinUI) => options.ContainsKey(nameof(DevicePlatform.WinUI))
                                                        ? options[nameof(DevicePlatform.WinUI)]
                                                        : options[Default],
                        nameof(DevicePlatform.macOS) => options.ContainsKey(nameof(DevicePlatform.macOS))
                                                        ? options[nameof(DevicePlatform.macOS)]
                                                        : options[Default],
                        nameof(DevicePlatform.MacCatalyst) => options.ContainsKey(nameof(DevicePlatform.MacCatalyst))
                                                        ? options[nameof(DevicePlatform.MacCatalyst)]
                                                        : options[Default],
                        /*nameof(DevicePlatform.GTK) => options.ContainsKey(nameof(DevicePlatform.GTK))
                                                        ? options[nameof(DevicePlatform.GTK)]
                                                        : options[Default],*/
                        nameof(DevicePlatform.Tizen) => options.ContainsKey(nameof(DevicePlatform.Tizen))
                                                        ? options[nameof(DevicePlatform.Tizen)]
                                                        : options[Default],
                        /*nameof(DevicePlatform.WPF) => options.ContainsKey(nameof(DevicePlatform.WPF))
                                                        ? options[nameof(DevicePlatform.WPF)]
                                                        : options[Default],*/
                        _ => options[Default],
                    };
#endif
                }
                else
                {
                    // Added to remove the compiler error
                    throw new ArgumentOutOfRangeException(nameof(markup), "Currently only OnIdiom and OnPlatform markup extension format is supported.");
                }

                view.SetValue(Grid.ColumnProperty, columnIndex);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(markup), "Markup input is not in the expected format.");
            }

            return view;
        }

        public static TView Cell<TView>(this TView view, int row, int column)
            where TView : View
        {
            view.SetValue(Grid.RowProperty, row);
            view.SetValue(Grid.ColumnProperty, column);
            return view;
        }

        public static TView Cell<TView, TRow, TColumn>(this TView view, TRow row, TColumn column)
            where TView : View
            where TRow : Enum
            where TColumn : Enum
        {
            var rowIndex = row.ToInt();
            var colIndex = column.ToInt();
            view.SetValue(Grid.RowProperty, rowIndex);
            view.SetValue(Grid.ColumnProperty, colIndex);
            return view;
        }

        public static TView GridCell<TView>(this TView view, int row, int column)
            where TView : View
        {
            view.SetValue(Grid.RowProperty, row);
            view.SetValue(Grid.ColumnProperty, column);
            return view;
        }

        public static TView GridCell<TView, TRow, TColumn>(this TView view, TRow row, TColumn column)
            where TView : View
            where TRow : Enum
            where TColumn : Enum
        {
            var rowIndex = row.ToInt();
            var colIndex = column.ToInt();
            view.SetValue(Grid.RowProperty, rowIndex);
            view.SetValue(Grid.ColumnProperty, colIndex);
            return view;
        }

        static int ToInt(this Enum enumValue) => Convert.ToInt32(enumValue, CultureInfo.InvariantCulture);

        static int ToInt(this string value) => Convert.ToInt32(value, CultureInfo.InvariantCulture);
    }
}
