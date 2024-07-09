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

        public static TSpan Text<TSpan>(this TSpan span, string text, Color textColor)
            where TSpan : Span
        {
            span.Text = text;
            span.TextColor = textColor;
            return span;
        }

        public static TSpan TextColor<TSpan>(this TSpan span, Color value)
            where TSpan : Span
        {
            span.TextColor = value;
            return span;
        }
    }
}
