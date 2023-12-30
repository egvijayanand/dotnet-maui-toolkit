#if NET6_0_OR_GREATER
using Microsoft.Maui.Controls.Internals;
using FontElement = Microsoft.Maui.Controls.Label;
#else
using Xamarin.Forms.Internals;
using FontElement = Xamarin.Forms.Label;
#endif

namespace VijayAnand.Toolkit.Markup
{
    public static class ElementExtensions
    {
        public static TFontElement FontSize<TFontElement>(this TFontElement fontElement, NamedSize namedSize)
            where TFontElement : Element, IFontElement
        {
            fontElement.SetValue(FontElement.FontSizeProperty, Device.GetNamedSize(namedSize, fontElement));
            return fontElement;
        }

        public static TElement AutomationId<TElement>(this TElement element, string value)
            where TElement : Element
        {
            element.AutomationId = value;
            return element;
        }

        public static TElement ClassId<TElement>(this TElement element, string value)
            where TElement : Element
        {
            element.ClassId = value;
            return element;
        }

        public static TElement StyleId<TElement>(this TElement element, string value)
            where TElement : Element
        {
            element.StyleId = value;
            return element;
        }
    }
}
