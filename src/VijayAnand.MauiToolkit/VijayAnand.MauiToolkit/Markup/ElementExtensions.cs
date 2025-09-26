using Microsoft.Maui.Controls.Internals;
using FontElement = Microsoft.Maui.Controls.Label;

namespace VijayAnand.MauiToolkit.Markup;

public static class ElementExtensions
{
    public static TFontElement FontSize<TFontElement>(this TFontElement fontElement, NamedSize namedSize)
        where TFontElement : Element, IFontElement
    {
        fontElement.SetValue(FontElement.FontSizeProperty, Device.GetNamedSize(namedSize, fontElement));
        return fontElement;
    }
}
