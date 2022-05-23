namespace VijayAnand.Toolkit.Markup
{
    public static class VisualElementExtensions
    {
        // Rotation

        public static TVisualElement RotationX<TVisualElement>(this TVisualElement visualElement,
                                                               double value)
            where TVisualElement : VisualElement
        {
            visualElement.RotationX = value;
            return visualElement;
        }

        public static TVisualElement RotationY<TVisualElement>(this TVisualElement visualElement,
                                                               double value)
            where TVisualElement : VisualElement
        {
            visualElement.RotationY = value;
            return visualElement;
        }

        // Scaling

        public static TVisualElement ScaleX<TVisualElement>(this TVisualElement visualElement,
                                                            double value)
            where TVisualElement : VisualElement
        {
            visualElement.ScaleX = value;
            return visualElement;
        }

        public static TVisualElement ScaleY<TVisualElement>(this TVisualElement visualElement,
                                                            double value)
            where TVisualElement : VisualElement
        {
            visualElement.ScaleY = value;
            return visualElement;
        }

        // Translation

        public static TVisualElement TranslationX<TVisualElement>(this TVisualElement visualElement,
                                                                  double value)
            where TVisualElement : VisualElement
        {
            visualElement.TranslationX = value;
            return visualElement;
        }

        public static TVisualElement TranslationY<TVisualElement>(this TVisualElement visualElement,
                                                                  double value)
            where TVisualElement : VisualElement
        {
            visualElement.TranslationY = value;
            return visualElement;
        }

        public static TVisualElement AddInlineCss<TVisualElement>(this TVisualElement visualElement,
                                                                   string inlineCss)
            where TVisualElement : VisualElement
        {
            if (!string.IsNullOrEmpty(inlineCss))
            {
                visualElement.Resources.Add(StyleSheet.FromString(inlineCss));
            }

            return visualElement;
        }

        public static TVisualElement AddStyleSheet<TVisualElement>(this TVisualElement visualElement,
                                                                   StyleSheet styleSheet)
            where TVisualElement : VisualElement
        {
            if (styleSheet != null)
            {
                visualElement.Resources.Add(styleSheet);
            }

            return visualElement;
        }

        public static TVisualElement AddVisualState<TVisualElement>(this TVisualElement visualElement,
                                                                    VisualStateGroupList value)
            where TVisualElement : VisualElement
        {
            VisualStateManager.SetVisualStateGroups(visualElement, value);
            return visualElement;
        }

        public static TVisualElement AddStyle<TVisualElement>(this TVisualElement visualElement,
                                                                      Style style)
            where TVisualElement : VisualElement
        {
            visualElement.Resources.Add(style);
            return visualElement;
        }

        public static TVisualElement AddResource<TVisualElement>(this TVisualElement visualElement,
                                                                 string key,
                                                                 object value)
            where TVisualElement : VisualElement
        {
            visualElement.Resources.Add(key, value);
            return visualElement;
        }
    }
}
