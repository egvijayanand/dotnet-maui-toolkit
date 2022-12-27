using System.Reflection;

namespace VijayAnand.MauiToolkit.Pro
{
    internal static class ResourceHelper
    {
        internal static T? AppResource<T>(string key)
        {
            if (Application.Current?.Resources.TryGetValue(key, out var value) is true)
            {
                return (value is T resource) ? resource : default;
            }
            else
            {
                return default;
            }
        }

        internal static Color? AppColor(string resourceKey) => AppResource<Color>(resourceKey);

        internal static IValueConverter? AppConverter(string resourceKey) => AppResource<IValueConverter>(resourceKey);

        internal static Style? AppStyle(string resourceKey) => AppResource<Style>(resourceKey);

        internal static object? AppResource(string key)
        {
            if (Application.Current?.Resources.TryGetValue(key, out var value) is true)
            {
                return value;
            }
            else
            {
                return null;
            }
        }
    }
}
