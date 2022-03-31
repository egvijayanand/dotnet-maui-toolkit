namespace VijayAnand.MauiToolkit.Markup
{
    public static class BindableObjectExtensions
    {
        #region Semantic Properties
        public static TBindable SemanticDesc<TBindable>(this TBindable bindable, string description)
            where TBindable : BindableObject
        {
            SemanticProperties.SetDescription(bindable, description);
            return bindable;
        }

        public static TBindable SemanticHeading<TBindable>(this TBindable bindable, SemanticHeadingLevel headingLevel)
            where TBindable : BindableObject
        {
            SemanticProperties.SetHeadingLevel(bindable, headingLevel);
            return bindable;
        }

        public static TBindable SemanticHint<TBindable>(this TBindable bindable, string hint)
            where TBindable : BindableObject
        {
            SemanticProperties.SetHint(bindable, hint);
            return bindable;
        }
        #endregion

        #region Automation Properties
        public static TBindable AutoExcludedWithChildren<TBindable>(this TBindable bindable, bool value)
            where TBindable : BindableObject
        {
            AutomationProperties.SetExcludedWithChildren(bindable, value);
            return bindable;
        }

        public static TBindable AutoHelpText<TBindable>(this TBindable bindable, string helpText)
            where TBindable : BindableObject
        {
            AutomationProperties.SetHelpText(bindable, helpText);
            return bindable;
        }

        public static TBindable AutoIsInAccessibleTree<TBindable>(this TBindable bindable, bool value)
            where TBindable : BindableObject
        {
            AutomationProperties.SetIsInAccessibleTree(bindable, value);
            return bindable;
        }

        public static TBindable AutoLabeledBy<TBindable>(this TBindable bindable, VisualElement visualElement)
            where TBindable : BindableObject
        {
            AutomationProperties.SetLabeledBy(bindable, visualElement);
            return bindable;
        }

        public static TBindable AutoName<TBindable>(this TBindable bindable, string name)
            where TBindable : BindableObject
        {
            AutomationProperties.SetName(bindable, name);
            return bindable;
        }
        #endregion
    }
}
