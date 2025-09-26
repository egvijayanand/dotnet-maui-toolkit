namespace VijayAnand.MauiToolkit.Converters;

public class BoolToObjectConverter : BoolToObjectConverter<object>;

public class BoolToObjectConverter<T> : IValueConverter
{
    public T? TrueObject { get; set; }

    public T? FalseObject { get; set; }

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        => value is bool b ? b is true ? TrueObject : FalseObject : FalseObject;

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => value?.Equals(TrueObject);
}
