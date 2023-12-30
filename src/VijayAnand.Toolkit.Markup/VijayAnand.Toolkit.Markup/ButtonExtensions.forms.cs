namespace VijayAnand.Toolkit.Markup
{
    public static class ButtonExtensions
    {
        public static TButton Text<TButton>(this TButton button, string value)
            where TButton : Button
        {
            button.Text = value;
            return button;
        }
    }
}
