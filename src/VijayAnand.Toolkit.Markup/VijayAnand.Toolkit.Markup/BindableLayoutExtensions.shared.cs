namespace VijayAnand.Toolkit.Markup
{
    public static partial class BindableLayoutExtensions
    {
        /// <summary>Binds to the <seealso cref="BindableLayout.ItemsSourceProperty"/>.</summary>
        public static TLayout ItemsSource<TLayout, TBindingContext, TSource>(
            this TLayout layout,
            Expression<Func<TBindingContext, TSource>> expression,
            BindingMode mode = BindingMode.Default,
            IValueConverter? converter = null,
            object? converterParameter = null,
            string? stringFormat = null,
            object? source = null,
            object? targetNullValue = null,
            object? fallbackValue = null)
#if NET6_0_OR_GREATER
            where TLayout : BindableObject, Microsoft.Maui.ILayout
#else
            where TLayout : Layout<View>
#endif
        {
            layout.Bindv2(BindableLayout.ItemsSourceProperty,
                expression,
                mode,
                converter,
                converterParameter,
                stringFormat,
                source,
                targetNullValue,
                fallbackValue);
            return layout;
        }
    }
}
