namespace VijayAnand.MauiToolkit.Markup;

public static class Utility
{
    #region Resources

    // App level

    public static object AppResource(string key)
    {
        if (Application.Current?.Resources.TryGetValue(key, out var value) is true)
        {
            return value;
        }
        else
        {
            throw new ArgumentOutOfRangeException(nameof(key), $"Resource not found for key '{key}'.");
        }
    }

    public static T AppResource<T>(string key, T defaultValue)
    {
        if (Application.Current?.Resources.TryGetValue(key, out var value) is true)
        {
            return (value is T resource) ? resource : defaultValue;
        }
        else
        {
            throw new ArgumentOutOfRangeException(nameof(key), $"Resource not found for key '{key}'.");
        }
    }

    public static Color AppColor(string resourceKey)
        => AppResource(resourceKey, KnownColor.Default);

    // Page level

    public static object PageResource<TPage>(this TPage page, string key) where TPage : Page
    {
        if (page.Resources.TryGetValue(key, out var value) is true)
        {
            return value;
        }
        else
        {
            throw new ArgumentOutOfRangeException(nameof(key), $"Resource not found for key '{key}' at the page level.");
        }
    }

    public static T? PageResource<TPage, T>(this TPage page, string key) where TPage : Page
    {
        if (page.Resources.TryGetValue(key, out var value) is true)
        {
            return (value is T resource) ? resource : default;
        }
        else
        {
            throw new ArgumentOutOfRangeException(nameof(key), $"Resource not found for key '{key}' at the page level.");
        }
    }

    // Control level

    public static object Resource<TVisualElement>(this TVisualElement control, string key)
        where TVisualElement : VisualElement
    {
        if (control.Resources.TryGetValue(key, out var value) is true)
        {
            return value;
        }
        else
        {
            throw new ArgumentOutOfRangeException(nameof(key), $"Resource not found for key '{key}' at the control level.");
        }
    }

    public static T? Resource<TVisualElement, T>(this TVisualElement control, string key)
        where TVisualElement : VisualElement
    {
        if (control.Resources.TryGetValue(key, out var value) is true)
        {
            return (value is T resource) ? resource : default;
        }
        else
        {
            throw new ArgumentOutOfRangeException(nameof(key), $"Resource not found for key '{key}' at the control level.");
        }
    }
    #endregion
}
