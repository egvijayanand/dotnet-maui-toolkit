namespace VijayAnand.Toolkit.Markup;

public static partial class StyleExtensions
{
    /// <summary>Convert generic Markup Style to non-generic .NET MAUI Style.</summary>
    public static Style MauiStyle<T>(this Style<T> style)
        where T : BindableObject
        => style.MauiStyle;

    /// <summary>Convert non-generic .NET MAUI Style to generic Markup Style.</summary>
    public static Style<T> MarkupStyle<T>(this Style style)
        where T : BindableObject
        => style;

    /// <summary>Creates a Setter instance using the given parameter values and appends it to the Style's Setters collection.</summary>
    public static Style<T> Add<T>(this Style<T> style, BindableProperty property, object value, string? targetName = null)
        where T : BindableObject
    {
        style.MauiStyle.Setters.Add(new Setter()
        {
            Property = property,
            Value = value,
            TargetName = targetName
        });

        return style;
    }
}
