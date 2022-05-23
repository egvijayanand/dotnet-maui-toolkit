namespace VijayAnand.Toolkit.Markup
{
    public static partial class LayoutExtensions
    {
        public static TLayout RadioButtonGroupName<TLayout>(this TLayout layout, string value)
            where TLayout : Layout<View>
        {
            RadioButtonGroup.SetGroupName(layout, value);
            return layout;
        }
    }
}
