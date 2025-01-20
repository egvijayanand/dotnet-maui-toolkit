namespace VijayAnand.Toolkit.Markup;

public static partial class StyleExtensions
{
    public static Style ApplyToDerivedTypes(this Style style, bool value = true)
    {
        style.ApplyToDerivedTypes = value;
        return style;
    }

    public static Style BasedOn(this Style style, Style value)
    {
        style.BasedOn = value;
        return style;
    }

    public static Style CanCascade(this Style style, bool value)
    {
        style.CanCascade = value;
        return style;
    }

    /// <summary>Creates a Setter instance using the given parameter values and appends it to the Style's Setters collection.</summary>
    public static Style Add(this Style style, BindableProperty property, object value, string? targetName = null)
    {
        style.Setters.Add(new Setter()
        {
            Property = property,
            Value = value,
            TargetName = targetName
        });

        return style;
    }
}
