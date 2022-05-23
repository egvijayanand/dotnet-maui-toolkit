#if NETSTANDARD2_0
using Rectangle = Xamarin.Forms.Rectangle;
#elif NET6_0_OR_GREATER
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Layouts;

using AbsoluteLayout = Microsoft.Maui.Controls.Compatibility.AbsoluteLayout;
using FlexLayout = Microsoft.Maui.Controls.FlexLayout;
using Rectangle = Microsoft.Maui.Graphics.Rect;
#endif

namespace VijayAnand.Toolkit.Markup
{
    public static class ViewExtensions
    {
        #region Margin
        public static TView NoMargin<TView>(this TView view)
            where TView : View => view.Margin(0);

        public static TView MarginLeft<TView>(this TView view, double value)
            where TView : View
        {
            var margin = view.Margin;
            margin.Left = value;
            return view;
        }

        public static TView MarginTop<TView>(this TView view, double value)
            where TView : View
        {
            var margin = view.Margin;
            margin.Top = value;
            return view;
        }

        public static TView MarginRight<TView>(this TView view, double value)
            where TView : View
        {
            var margin = view.Margin;
            margin.Right = value;
            return view;
        }

        public static TView MarginBottom<TView>(this TView view, double value)
            where TView : View
        {
            var margin = view.Margin;
            margin.Bottom = value;
            return view;
        }
        #endregion

        #region Padding
        public static TElement NoPadding<TElement>(this TElement element)
            where TElement : Element, IPaddingElement => element.Padding(0);

        public static TElement PadLeft<TElement>(this TElement element, double value)
            where TElement : Element, IPaddingElement
        {
            var padding = element.Padding;
            padding.Left = value;
            return element;
        }

        public static TElement PadTop<TElement>(this TElement element, double value)
            where TElement : Element, IPaddingElement
        {
            var padding = element.Padding;
            padding.Top = value;
            return element;
        }

        public static TElement PadRight<TElement>(this TElement element, double value)
            where TElement : Element, IPaddingElement
        {
            var padding = element.Padding;
            padding.Right = value;
            return element;
        }

        public static TElement PadBottom<TElement>(this TElement element, double value)
            where TElement : Element, IPaddingElement
        {
            var padding = element.Padding;
            padding.Bottom = value;
            return element;
        }
        #endregion

        #region AbsoluteLayout
        public static TView AbsLayoutBounds<TView>(this TView view, Rectangle bounds)
            where TView : View
        {
            AbsoluteLayout.SetLayoutBounds(view, bounds);
            return view;
        }

        public static TView AbsLayoutBounds<TView>(this TView view, double left, double top, double width, double height)
            where TView : View
        {
            AbsoluteLayout.SetLayoutBounds(view, new Rectangle(left, top, width, height));
            return view;
        }

        public static TView AbsLayoutBounds<TView>(this TView view, Point location, Size size) where
            TView : View
        {
            AbsoluteLayout.SetLayoutBounds(view, new Rectangle(location, size));
            return view;
        }

        public static TView AbsLayoutFlags<TView>(this TView view, AbsoluteLayoutFlags flags)
            where TView : View
        {
            AbsoluteLayout.SetLayoutFlags(view, flags);
            return view;
        }
        #endregion

        #region RelativeLayout
        public static TView RelXConstraint<TView>(this TView view, Constraint value)
            where TView : View
        {
            RelativeLayout.SetXConstraint(view, value);
            return view;
        }

        public static TView RelYConstraint<TView>(this TView view, Constraint value)
            where TView : View
        {
            RelativeLayout.SetYConstraint(view, value);
            return view;
        }

        public static TView RelBoundsConstraint<TView>(this TView view, BoundsConstraint value)
            where TView : View
        {
            RelativeLayout.SetBoundsConstraint(view, value);
            return view;
        }

        public static TView RelWidthConstraint<TView>(this TView view, Constraint value)
            where TView : View
        {
            RelativeLayout.SetWidthConstraint(view, value);
            return view;
        }

        public static TView RelHeightConstraint<TView>(this TView view, Constraint value)
            where TView : View
        {
            RelativeLayout.SetHeightConstraint(view, value);
            return view;
        }
        #endregion

        #region FlexLayout
        public static TView FlexAlignSelf<TView>(this TView view, FlexAlignSelf value)
            where TView : View
        {
            FlexLayout.SetAlignSelf(view, value);
            return view;
        }

        public static TView FlexBasis<TView>(this TView view, FlexBasis value)
            where TView : View
        {
            FlexLayout.SetBasis(view, value);
            return view;
        }

        public static TView FlexOrder<TView>(this TView view, int value)
            where TView : View
        {
            FlexLayout.SetOrder(view, value);
            return view;
        }

        public static TView FlexGrow<TView>(this TView view, float value)
            where TView : View
        {
            FlexLayout.SetGrow(view, value);
            return view;
        }

        public static TView FlexShrink<TView>(this TView view, float value)
            where TView : View
        {
            FlexLayout.SetShrink(view, value);
            return view;
        }
        #endregion
    }
}
