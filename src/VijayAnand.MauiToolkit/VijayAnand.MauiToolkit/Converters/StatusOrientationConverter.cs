namespace VijayAnand.MauiToolkit.Converters
{
    public class StatusOrientationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is StatusOrientation orientation)
            {
                switch (orientation)
                {
                    case StatusOrientation.Horizontal:
                        return StackOrientation.Horizontal;
                    case StatusOrientation.VerticalTop:
                    case StatusOrientation.VerticalBottom:
                        return StackOrientation.Vertical;
                }
            }

            return StackOrientation.Horizontal;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotSupportedException();
    }
}
