namespace VijayAnand.MauiToolkit.Converters
{
    public class EnumToBoolConverter : IValueConverter
    {
        public IList<Enum> TrueValues { get; } = new List<Enum>();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return TrueValues.Count == 0 ? CompareEnums(value, parameter as Enum) : TrueValues.Any(item => CompareEnums(value, item));

            static bool CompareEnums(object value, Enum? item)
            {
                if (item is null)
                {
                    return false;
                }

                var valueType = value.GetType();

                if (valueType != item.GetType())
                {
                    return false;
                }

                if (valueType.GetTypeInfo().GetCustomAttribute<FlagsAttribute>() is not null)
                {
                    return item.HasFlag((Enum)value);
                }

                return Equals(value, item);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
