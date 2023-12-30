namespace VijayAnand.Toolkit.Markup
{
    public static partial class VisualElementExtensions
    {
        public static TVisualElement Background<TVisualElement>(this TVisualElement visualElement, Brush value)
            where TVisualElement : VisualElement
        {
            visualElement.Background = value;
            return visualElement;
        }

        public static TVisualElement BackgroundColor<TVisualElement>(this TVisualElement visualElement, Color value)
            where TVisualElement : VisualElement
        {
            visualElement.BackgroundColor = value;
            return visualElement;
        }

        public static TVisualElement Anchor<TVisualElement>(this TVisualElement visualElement, double xValue, double yValue)
            where TVisualElement : VisualElement
        {
            visualElement.AnchorX = xValue;
            visualElement.AnchorY = yValue;
            return visualElement;
        }

        public static TVisualElement AnchorX<TVisualElement>(this TVisualElement visualElement, double value)
            where TVisualElement : VisualElement
        {
            visualElement.AnchorX = value;
            return visualElement;
        }

        public static TVisualElement AnchorY<TVisualElement>(this TVisualElement visualElement, double value)
            where TVisualElement : VisualElement
        {
            visualElement.AnchorY = value;
            return visualElement;
        }

        public static TVisualElement Behaviors<TVisualElement>(this TVisualElement visualElement, Behavior value)
            where TVisualElement : VisualElement
        {
            visualElement.Behaviors.Add(value);
            return visualElement;
        }

        public static TVisualElement FlowDirection<TVisualElement>(this TVisualElement visualElement, FlowDirection value)
            where TVisualElement : VisualElement
        {
            visualElement.FlowDirection = value;
            return visualElement;
        }

        public static TVisualElement InputTransparent<TVisualElement>(this TVisualElement visualElement, bool value)
            where TVisualElement : VisualElement
        {
            visualElement.InputTransparent = value;
            return visualElement;
        }

        public static TVisualElement IsEnabled<TVisualElement>(this TVisualElement visualElement, bool value)
            where TVisualElement : VisualElement
        {
            visualElement.IsEnabled = value;
            return visualElement;
        }

        public static TVisualElement IsTabStop<TVisualElement>(this TVisualElement visualElement, bool value)
            where TVisualElement : VisualElement
        {
            visualElement.IsTabStop = value;
            return visualElement;
        }

        public static TVisualElement IsVisible<TVisualElement>(this TVisualElement visualElement, bool value)
            where TVisualElement : VisualElement
        {
            visualElement.IsVisible = value;
            return visualElement;
        }

        public static TVisualElement Opacity<TVisualElement>(this TVisualElement visualElement, double value)
            where TVisualElement : VisualElement
        {
            visualElement.Opacity = value;
            return visualElement;
        }

        public static TVisualElement Rotation<TVisualElement>(this TVisualElement visualElement, double value)
            where TVisualElement : VisualElement
        {
            visualElement.Rotation = value;
            return visualElement;
        }

        public static TVisualElement RotationX<TVisualElement>(this TVisualElement visualElement, double value)
            where TVisualElement : VisualElement
        {
            visualElement.RotationX = value;
            return visualElement;
        }

        public static TVisualElement RotationY<TVisualElement>(this TVisualElement visualElement, double value)
            where TVisualElement : VisualElement
        {
            visualElement.RotationY = value;
            return visualElement;
        }

        public static TVisualElement Scale<TVisualElement>(this TVisualElement visualElement, double value)
            where TVisualElement : VisualElement
        {
            visualElement.Scale = value;
            return visualElement;
        }

        public static TVisualElement ScaleX<TVisualElement>(this TVisualElement visualElement, double value)
            where TVisualElement : VisualElement
        {
            visualElement.ScaleX = value;
            return visualElement;
        }

        public static TVisualElement ScaleY<TVisualElement>(this TVisualElement visualElement, double value)
            where TVisualElement : VisualElement
        {
            visualElement.ScaleY = value;
            return visualElement;
        }

        public static TVisualElement TranslationX<TVisualElement>(this TVisualElement visualElement, double value)
            where TVisualElement : VisualElement
        {
            visualElement.TranslationX = value;
            return visualElement;
        }

        public static TVisualElement TranslationY<TVisualElement>(this TVisualElement visualElement, double value)
            where TVisualElement : VisualElement
        {
            visualElement.TranslationY = value;
            return visualElement;
        }

        // Already defined in Xamarin.CommunityToolkit.Markup NuGet package.
        /*
        public static TVisualElement Height<TVisualElement>(this TVisualElement visualElement, double value)
            where TVisualElement : VisualElement
        {
            visualElement.HeightRequest = value;
            return visualElement;
        }

        public static TVisualElement MinHeight<TVisualElement>(this TVisualElement visualElement, double value)
            where TVisualElement : VisualElement
        {
            visualElement.MinimumHeightRequest = value;
            return visualElement;
        }

        public static TVisualElement Width<TVisualElement>(this TVisualElement visualElement, double value)
            where TVisualElement : VisualElement
        {
            visualElement.WidthRequest = value;
            return visualElement;
        }

        public static TVisualElement MinWidth<TVisualElement>(this TVisualElement visualElement, double value)
            where TVisualElement : VisualElement
        {
            visualElement.MinimumWidthRequest = value;
            return visualElement;
        }

        /// <summary>Size of same width and height.</summary>
        public static TVisualElement Size<TVisualElement>(this TVisualElement visualElement, double value)
            where TVisualElement : VisualElement
        {
            visualElement.WidthRequest = value;
            visualElement.HeightRequest = value;
            return visualElement;
        }

        /// <summary>Size in terms of width and height.</summary>
        public static TVisualElement Size<TVisualElement>(this TVisualElement visualElement, double width, double height)
            where TVisualElement : VisualElement
        {
            visualElement.WidthRequest = width;
            visualElement.HeightRequest = height;
            return visualElement;
        }

        /// <summary>Minimum size of same width and height.</summary>
        public static TVisualElement MinSize<TVisualElement>(this TVisualElement visualElement, double value)
            where TVisualElement : VisualElement
        {
            visualElement.WidthRequest = value;
            visualElement.HeightRequest = value;
            return visualElement;
        }

        /// <summary>Minimum size in terms of width and height.</summary>
        public static TVisualElement MinSize<TVisualElement>(this TVisualElement visualElement, double width, double height)
            where TVisualElement : VisualElement
        {
            visualElement.MinimumWidthRequest = width;
            visualElement.MinimumHeightRequest = height;
            return visualElement;
        }

        public static TVisualElement MinSize<TVisualElement>(this TVisualElement visualElement, Size value)
            where TVisualElement : VisualElement
        {
            visualElement.MinimumWidthRequest = value.Width;
            visualElement.MinimumHeightRequest = value.Height;
            return visualElement;
        }
        */
    }
}
