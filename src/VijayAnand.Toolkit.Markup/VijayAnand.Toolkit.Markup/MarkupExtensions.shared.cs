#if NETSTANDARD2_0_OR_GREATER
using TextElement = Xamarin.Forms.Label;
#elif NET6_0_OR_GREATER
using TextElement = Microsoft.Maui.Controls.Label;
#endif

namespace VijayAnand.Toolkit.Markup
{
    public static class MarkupExtensions
    {
        // Colors
#if NETSTANDARD2_0_OR_GREATER
        public static TView TextColor<TView>(this TView view, Color color)
            where TView : View
        {
            view.SetValue(TextElement.TextColorProperty, color);
            return view;
        }

        public static Color AsColor(this string hexValue)
        {
            return FromHex(hexValue);
        }
#elif NET6_0_OR_GREATER
        /*public static TView TextColor<TView>(this TView view, Color color)
            where TView : View, IText, ITextStyle
        {
            view.SetValue(TextElement.TextColorProperty, color);
            return view;
        }*/

        public static Color AsColor(this string hexValue)
        {
            return Color.Parse(hexValue);
        }
#endif

        public static TElement BackColor<TElement>(this TElement view, Color color)
            where TElement : VisualElement
        {
            view.SetValue(VisualElement.BackgroundColorProperty, color);
            return view;
        }

        #region Stack
        public static TStackLayout InHorizontal<TStackLayout>(this TStackLayout stack)
            where TStackLayout : StackLayout
        {
            stack.Orientation = StackOrientation.Horizontal;
            return stack;
        }

#if NETSTANDARD2_0_OR_GREATER
        public static TStackLayout Spacing<TStackLayout>(this TStackLayout stack, double value)
            where TStackLayout : StackLayout
        {
            stack.Spacing = value;
            return stack;
        }
#elif NET6_0_OR_GREATER
        public static TStackLayout Spacing<TStackLayout>(this TStackLayout stack, double value)
            where TStackLayout : StackBase
        {
            stack.Spacing = value;
            return stack;
        }
#endif
        #endregion
    }
}
