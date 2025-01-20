namespace VijayAnand.Toolkit.Markup
{
    public static partial class VisualElementExtensions
    {
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

        public static TVisualElement VisualStates<TVisualElement>(this TVisualElement visualElement,
                                                                  IEnumerable<VisualStateGroup> visualStateGroups)
            where TVisualElement : VisualElement
        {
            var visualStateGroupList = new VisualStateGroupList();

            foreach (var visualStateGroup in visualStateGroups)
            {
                visualStateGroupList.Add(visualStateGroup);
            }

            VisualStateManager.SetVisualStateGroups(visualElement, visualStateGroupList);
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
