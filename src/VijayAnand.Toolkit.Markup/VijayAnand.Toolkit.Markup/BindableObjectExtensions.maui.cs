namespace VijayAnand.Toolkit.Markup
{
    public static partial class BindableObjectExtensions
    {
        #region Automation Properties
        public static TBindable AutoExcludedWithChildren<TBindable>(this TBindable bindable, bool value)
            where TBindable : BindableObject
        {
            AutomationProperties.SetExcludedWithChildren(bindable, value);
            return bindable;
        }
        #endregion
    }
}
