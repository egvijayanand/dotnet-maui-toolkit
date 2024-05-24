namespace VijayAnand.Toolkit.Markup
{
    public static class SpanExtensions
    {
        public static TSpan Text<TSpan>(this TSpan span, string value)
            where TSpan : Span
        {
            span.Text = value;
            return span;
        }
    }
}
