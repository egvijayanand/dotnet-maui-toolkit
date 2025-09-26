using static VijayAnand.MauiToolkit.StatusOrientation;

namespace VijayAnand.MauiToolkit.Converters;

public class StatusOrientationConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        => value switch
        {
            StatusOrientation orientation => orientation switch
            {
                Horizontal => StackOrientation.Horizontal,
                VerticalTop or VerticalBottom => StackOrientation.Vertical,
                _ => StackOrientation.Horizontal,
            },
            _ => StackOrientation.Horizontal
        };

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotSupportedException();
}
