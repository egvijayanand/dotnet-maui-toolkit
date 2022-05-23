namespace VijayAnand.Toolkit.Markup
{
    public static class InputViewExtensions
    {
#if NETSTANDARD2_0
        public static TInputView Placeholder<TInputView>(this TInputView inputView, string placeholder)
            where TInputView : InputView
        {
            inputView.Placeholder = placeholder;
            return inputView;
        }
#endif

        public static TInputView Placeholder<TInputView>(this TInputView inputView,
                                                         string placeholder,
                                                         Color textColor)
            where TInputView : InputView
        {
            inputView.Placeholder = placeholder;
            inputView.PlaceholderColor = textColor;
            return inputView;
        }

        public static TInputView MaxLength<TInputView>(this TInputView inputView, int maxLength)
            where TInputView : InputView
        {
            inputView.MaxLength = maxLength;
            return inputView;
        }

        public static TInputView Keyboard<TInputView>(this TInputView inputView, Keyboard kind)
            where TInputView : InputView
        {
            inputView.Keyboard = kind;
            return inputView;
        }

        public static TInputView ReadOnly<TInputView>(this TInputView inputView)
            where TInputView : InputView
        {
            inputView.IsReadOnly = true;
            return inputView;
        }

        public static TInputView TextTransform<TInputView>(this TInputView inputView, TextTransform value)
            where TInputView : InputView
        {
            inputView.TextTransform = value;
            return inputView;
        }
    }
}
