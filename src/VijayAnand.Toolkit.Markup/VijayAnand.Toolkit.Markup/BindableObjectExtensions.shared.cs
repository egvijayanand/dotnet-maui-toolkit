namespace VijayAnand.Toolkit.Markup
{
    public static partial class BindableObjectExtensions
    {
        const string bindingContextPath = Binding.SelfPath;

        /// <summary>Binds to the default bindable property.</summary>
        /// <param name="expression">Lambda expression of the source property to bind to.</param>
        public static TBindable Bindv2<TBindable, TBindingContext, TSource>(
            this TBindable bindable,
            Expression<Func<TBindingContext, TSource>> expression,
            BindingMode mode = BindingMode.Default,
            IValueConverter? converter = null,
            object? converterParameter = null,
            string? stringFormat = null,
            object? source = null,
            object? targetNullValue = null,
            object? fallbackValue = null)
            where TBindable : BindableObject
            => bindable.Bind(
                PropertyName(expression),
                mode,
                converter,
                converterParameter,
                stringFormat,
                source,
                targetNullValue,
                fallbackValue);

        /// <summary>Binds to the specified bindable property.</summary>
        /// <param name="expression">Lambda expression of the source property to bind to.</param>
        public static TBindable Bindv2<TBindable, TBindingContext, TSource>(
            this TBindable bindable,
            BindableProperty property,
            Expression<Func<TBindingContext, TSource>> expression,
            BindingMode mode = BindingMode.Default,
            IValueConverter? converter = null,
            object? converterParameter = null,
            string? stringFormat = null,
            object? source = null,
            object? targetNullValue = null,
            object? fallbackValue = null)
            where TBindable : BindableObject
            => bindable.Bind(property,
                PropertyName(expression),
                mode,
                converter,
                converterParameter,
                stringFormat,
                source,
                targetNullValue,
                fallbackValue);

        /// <summary>Bind to the <typeparamref name="TBindable"/>'s default Command and CommandParameter properties.</summary>
        /// <param name="expression">Lambda expression of the source property to bind to.</param>
        /// <param name="parameterPath">If null, no binding is created for the CommandParameter property.</param>
        public static TBindable BindCommandv2<TBindable, TBindingContext, TSource>(
            this TBindable bindable,
            Expression<Func<TBindingContext, TSource>> expression,
            object? source = null,
            string? parameterPath = bindingContextPath,
            object? parameterSource = null)
            where TBindable : BindableObject
            where TSource : ICommand
            => bindable.BindCommand(
                PropertyName(expression),
                source,
                parameterPath,
                parameterSource);

        /// <summary>Bind to the <typeparamref name="TBindable"/>'s default Command and assign <paramref name="parameterValue"/> value to CommandParameter property.</summary>
        /// <param name="parameterValue">If null, not assigned to the CommandParameter property</param>
        public static TBindable BindCommandWithParameter<TBindable>(
            this TBindable bindable,
            string path = bindingContextPath,
            object? source = null,
            object? parameterValue = null)
            where TBindable : BindableObject
        {
            // Explicit value of null to parameterPath as value of CommandParameter is static in nature
            bindable.BindCommand(path, source, null);
            _ = bindable switch
            {
                Button button => button.CommandParameter = parameterValue,
                Entry entry => entry.ReturnCommandParameter = parameterValue,
                ImageButton imgButton => imgButton.CommandParameter = parameterValue,
                BackButtonBehavior backBtnBehavior => backBtnBehavior.CommandParameter = parameterValue,
                MenuItem menuItem => menuItem.CommandParameter = parameterValue,
                SearchBar searchBar => searchBar.SearchCommandParameter = parameterValue,
                SearchHandler searchHandler => searchHandler.CommandParameter = parameterValue,
                SwipeItemView swipeItemView => swipeItemView.CommandParameter = parameterValue,
#pragma warning disable CS0618 // Type or member is obsolete
                TextCell textCell => textCell.CommandParameter = parameterValue,
#pragma warning restore CS0618 // Type or member is obsolete
#if !NET10_0_OR_GREATER
                // .NET 10.0+ ClickGestureRecognizer is not available
#pragma warning disable CS0618 // Type or member is obsolete
                ClickGestureRecognizer clickGesture => clickGesture.CommandParameter = parameterValue,
#pragma warning restore CS0618 // Type or member is obsolete
#endif
                DropGestureRecognizer dropGesture => dropGesture.DropCommandParameter = parameterValue,
                SwipeGestureRecognizer swipeGesture => swipeGesture.CommandParameter = parameterValue,
                TapGestureRecognizer tapGesture => tapGesture.CommandParameter = parameterValue,
                RefreshView refreshView => refreshView.CommandParameter = parameterValue,
                //EventToCommandBehavior eventToCommand => eventToCommand.CommandParameter = parameterValue,
                //UserStoppedTypingBehavior userStoppedTyping => userStoppedTyping.CommandParameter = parameterValue,
                _ => throw new Exception($"{typeof(TBindable)} does not implement commanding."),
            };

            return bindable;
        }

        /// <summary>Bind to the <typeparamref name="TBindable"/>'s default Command and assign <paramref name="parameterValue"/> value to CommandParameter property.</summary>
        /// <param name="parameterValue">If null, not assigned to the CommandParameter property</param>
        public static TBindable BindCommandWithParameterv2<TBindable, TBindingContext, TSource>(
            this TBindable bindable,
            Expression<Func<TBindingContext, TSource>> expression,
            object? source = null,
            object? parameterValue = null)
            where TBindable : BindableObject
            where TSource : ICommand
        {
            // Explicit value of null to parameterPath as value of CommandParameter is static in nature
            bindable.BindCommand(PropertyName(expression), source, null);
            _ = bindable switch
            {
                Button button => button.CommandParameter = parameterValue,
                Entry entry => entry.ReturnCommandParameter = parameterValue,
                ImageButton imgButton => imgButton.CommandParameter = parameterValue,
                BackButtonBehavior backBtnBehavior => backBtnBehavior.CommandParameter = parameterValue,
                MenuItem menuItem => menuItem.CommandParameter = parameterValue,
                SearchBar searchBar => searchBar.SearchCommandParameter = parameterValue,
                SearchHandler searchHandler => searchHandler.CommandParameter = parameterValue,
                SwipeItemView swipeItemView => swipeItemView.CommandParameter = parameterValue,
#pragma warning disable CS0618 // Type or member is obsolete
                TextCell textCell => textCell.CommandParameter = parameterValue,
#pragma warning restore CS0618 // Type or member is obsolete
#if !NET10_0_OR_GREATER
                // .NET 10.0+ ClickGestureRecognizer is not available
#pragma warning disable CS0618 // Type or member is obsolete
                ClickGestureRecognizer clickGesture => clickGesture.CommandParameter = parameterValue,
#pragma warning restore CS0618 // Type or member is obsolete
#endif
                DropGestureRecognizer dropGesture => dropGesture.DropCommandParameter = parameterValue,
                SwipeGestureRecognizer swipeGesture => swipeGesture.CommandParameter = parameterValue,
                TapGestureRecognizer tapGesture => tapGesture.CommandParameter = parameterValue,
                RefreshView refreshView => refreshView.CommandParameter = parameterValue,
                //EventToCommandBehavior eventToCommand => eventToCommand.CommandParameter = parameterValue,
                //UserStoppedTypingBehavior userStoppedTyping => userStoppedTyping.CommandParameter = parameterValue,
                _ => throw new Exception($"{typeof(TBindable)} does not implement commanding."),
            };

            return bindable;
        }

        /// <summary>
        /// Utility method to assign a static CommandParameter value on the objects that supports commanding.<br />
        /// Ensure this is invoked after the BindCommand method call, otherwise the latter will override the value set
        /// </summary>
        /// <typeparam name="TBindable"></typeparam>
        /// <param name="bindable"></param>
        /// <param name="parameterValue"></param>
        /// <returns></returns>
        public static TBindable CommandParameter<TBindable>(this TBindable bindable,
                                                            object parameterValue)
            where TBindable : BindableObject
        {
            _ = bindable switch
            {
                Button button => button.CommandParameter = parameterValue,
                Entry entry => entry.ReturnCommandParameter = parameterValue,
                ImageButton imgButton => imgButton.CommandParameter = parameterValue,
                BackButtonBehavior backBtnBehavior => backBtnBehavior.CommandParameter = parameterValue,
                MenuItem menuItem => menuItem.CommandParameter = parameterValue,
                SearchBar searchBar => searchBar.SearchCommandParameter = parameterValue,
                SearchHandler searchHandler => searchHandler.CommandParameter = parameterValue,
                SwipeItemView swipeItemView => swipeItemView.CommandParameter = parameterValue,
#pragma warning disable CS0618 // Type or member is obsolete
                TextCell textCell => textCell.CommandParameter = parameterValue,
#pragma warning restore CS0618 // Type or member is obsolete
#if !NET10_0_OR_GREATER
                // .NET 10.0+ ClickGestureRecognizer is not available
#pragma warning disable CS0618 // Type or member is obsolete
                ClickGestureRecognizer clickGesture => clickGesture.CommandParameter = parameterValue,
#pragma warning restore CS0618 // Type or member is obsolete
#endif
                DropGestureRecognizer dropGesture => dropGesture.DropCommandParameter = parameterValue,
                SwipeGestureRecognizer swipeGesture => swipeGesture.CommandParameter = parameterValue,
                TapGestureRecognizer tapGesture => tapGesture.CommandParameter = parameterValue,
                RefreshView refreshView => refreshView.CommandParameter = parameterValue,
                //EventToCommandBehavior eventToCommand => eventToCommand.CommandParameter = parameterValue,
                //UserStoppedTypingBehavior userStoppedTyping => userStoppedTyping.CommandParameter = parameterValue,
                _ => throw new Exception($"{typeof(TBindable)} does not implement commanding."),
            };

            return bindable;
        }

        #region Automation Properties
        public static TBindable AutoIsInAccessibleTree<TBindable>(this TBindable bindable, bool value)
            where TBindable : BindableObject
        {
            AutomationProperties.SetIsInAccessibleTree(bindable, value);
            return bindable;
        }

        public static TBindable AutoHelpText<TBindable>(this TBindable bindable, string value)
            where TBindable : BindableObject
        {
            AutomationProperties.SetHelpText(bindable, value);
            return bindable;
        }

        public static TBindable AutoLabeledBy<TBindable>(this TBindable bindable, VisualElement value)
            where TBindable : BindableObject
        {
            AutomationProperties.SetLabeledBy(bindable, value);
            return bindable;
        }

        public static TBindable AutoName<TBindable>(this TBindable bindable, string value)
            where TBindable : BindableObject
        {
            AutomationProperties.SetName(bindable, value);
            return bindable;
        }
        #endregion
    }
}
