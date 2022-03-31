namespace VijayAnand.MauiToolkit.Markup
{
    public static class InputViewExtensions
    {
        public static TInputView Placeholder<TInputView>(this TInputView inputView, string placeholder)
            where TInputView : InputView
        {
            inputView.Placeholder = placeholder;
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

        public static TInputView SpellCheck<TInputView>(this TInputView inputView, bool value)
            where TInputView : InputView
        {
            inputView.IsSpellCheckEnabled = value;
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
