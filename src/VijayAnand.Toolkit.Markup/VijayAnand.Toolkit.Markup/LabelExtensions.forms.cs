namespace VijayAnand.Toolkit.Markup
{
    public static class LabelExtensions
    {
        public static TLabel Text<TLabel>(this TLabel label, string value)
            where TLabel : Label
        {
            label.Text = value;
            return label;
        }
    }
}
