namespace VijayAnand.Toolkit.Markup
{
    public static class SpanExtensions
    {
        public static TSpan Text<TSpan>(this TSpan label, string value)
            where TSpan : Span
        {
            label.Text = value;
            return label;
        }
    }
}
