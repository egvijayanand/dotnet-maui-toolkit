namespace VijayAnand.MauiToolkit.Markup;

public static class BindableObjectExtensions
{
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
