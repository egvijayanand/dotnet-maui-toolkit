namespace VijayAnand.MauiToolkit.Markup;

public static class LayoutExtensions
{
    public static TLayout RadioButtonGroupName<TLayout>(this TLayout layout, string groupName)
        where TLayout : Layout
    {
        RadioButtonGroup.SetGroupName(layout, groupName);
        return layout;
    }

    public static TStackLayout InHorizontal<TStackLayout>(this TStackLayout stack)
        where TStackLayout : StackLayout
    {
        stack.Orientation = StackOrientation.Horizontal;
        return stack;
    }
}
