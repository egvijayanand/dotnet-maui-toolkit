namespace VijayAnand.Toolkit.Markup
{
    public static partial class GestureExtensions
    {
        public static TGestureElement BindClickGesturev2<TGestureElement, TBindingContext, TSource>(
            this TGestureElement gestureElement,
            Expression<Func<TBindingContext, TSource>> expression,
            object? commandSource = null,
            string? parameterPath = null,
            object? parameterSource = null,
            int? numberOfClicksRequired = default)
            where TGestureElement : Element, IGestureRecognizers
            where TSource : ICommand
        {
            gestureElement.BindClickGesture(PropertyName(expression),
                                            commandSource,
                                            parameterPath,
                                            parameterSource);
            return gestureElement;
        }

        public static TGestureElement BindSwipeGesturev2<TGestureElement, TBindingContext, TSource>(
            this TGestureElement gestureElement,
            Expression<Func<TBindingContext, TSource>> expression,
            object? commandSource = null,
            string? parameterPath = null,
            object? parameterSource = null)
            where TGestureElement : Element, IGestureRecognizers
            where TSource : ICommand
        {
            gestureElement.BindSwipeGesture(PropertyName(expression),
                                            commandSource,
                                            parameterPath,
                                            parameterSource);
            return gestureElement;
        }

        public static TGestureElement BindTapGesturev2<TGestureElement, TBindingContext, TSource>(
            this TGestureElement gestureElement,
            Expression<Func<TBindingContext, TSource>> expression,
            object? commandSource = null,
            string? parameterPath = null,
            object? parameterSource = null)
            where TGestureElement : Element, IGestureRecognizers
            where TSource : ICommand
        {
            gestureElement.BindTapGesture(PropertyName(expression),
                                          commandSource,
                                          parameterPath,
                                          parameterSource);
            return gestureElement;
        }
    }
}
