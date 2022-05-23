using System;
using System.Collections.Generic;
using System.Text;

namespace VijayAnand.Toolkit.Markup
{
    public static partial class BindableObjectExtensions
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
        #endregion
    }
}
