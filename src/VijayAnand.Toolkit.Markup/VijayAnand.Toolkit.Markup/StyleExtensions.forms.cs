namespace VijayAnand.Toolkit.Markup;

public static partial class StyleExtensions
{
    /// <summary>Convert generic Markup Style to non-generic Xamarin.Forms Style.</summary>
    public static Style FormsStyle<T>(this Style<T> style)
        where T : BindableObject
        => style.FormsStyle;

    /// <summary>Creates a Setter instance using the given parameter values and appends it to the Style's Setters collection.</summary>
    public static Style<T> Add<T>(this Style<T> style, BindableProperty property, object value, string? targetName = null)
        where T : BindableObject
    {
        style.FormsStyle.Setters.Add(new Setter()
        {
            Property = property,
            Value = value,
            TargetName = targetName
        });

        return style;
    }
}
