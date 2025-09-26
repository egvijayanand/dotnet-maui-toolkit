using VijayAnand.MauiToolkit.Services;

namespace VijayAnand.MauiToolkit.Pro.Services
{
    /// <summary>
    /// <seealso cref="Popup"/> based implementation of the <seealso cref="IMauiDialogService"/> and <seealso cref="IDialogService"/> methods.
    /// </summary>
    internal class PopupDialogService : IMauiDialogService, IDialogService
    {
        public async Task<string> DisplayActionSheetAsync(string title, string message, string cancel, string? destruction, string? defaultButton, params string[] buttons)
        {
            var dialog = new ActionSheetPopup(title, message, cancel, destruction, defaultButton, buttons);
            return (await GetMainPage().ShowPopupAsync(dialog))?.ToString() ?? string.Empty;
        }

        public async Task<string> DisplayActionSheetAsync(string title, string cancel, string destruction, FlowDirection flowDirection, params string[] buttons)
        {
            var dialog = new ActionSheetPopup(title, string.Empty, cancel, destruction, null, buttons);

            if (dialog.Content is not null)
            {
                dialog.Content.FlowDirection = flowDirection;
            }

            return (await GetMainPage().ShowPopupAsync(dialog))?.ToString() ?? string.Empty;
        }

        public Task DisplayAlertAsync(string title, string message, string cancel)
            => GetMainPage().ShowPopupAsync(new AlertPopup(title, message, cancel));

        public async Task<bool> DisplayAlertAsync(string title, string message, string accept, string cancel)
            => await GetMainPage().ShowPopupAsync(new AlertPopup(title, message, accept, cancel)) is true;

        public Task DisplayAlertAsync(string title, string message, string cancel, FlowDirection flowDirection)
        {
            var dialog = new AlertPopup(title, message, cancel);

            if (dialog.Content is not null)
            {
                dialog.Content.FlowDirection = flowDirection;
            }

            return GetMainPage().ShowPopupAsync(dialog);
        }

        public async Task<bool> DisplayAlertAsync(string title, string message, string accept, string cancel, FlowDirection flowDirection)
        {
            var dialog = new AlertPopup(title, message, accept, cancel);

            if (dialog.Content is not null)
            {
                dialog.Content.FlowDirection = flowDirection;
            }

            return await GetMainPage().ShowPopupAsync(dialog) is true;
        }

        public Task<string> DisplayPromptAsync(string title, string message, string accept = "OK", string cancel = "Cancel", string? placeholder = null, int maxLength = -1, InputType inputType = InputType.Default, string initialValue = "", Func<string, (bool, string)>? predicate = null)
            => DisplayPromptAsync(title, message, FlowDirection.MatchParent, accept, cancel, placeholder, maxLength, GetKeyboard(inputType), initialValue, predicate);

        public async Task<string> DisplayPromptAsync(string title, string message, FlowDirection flowDirection, string accept = "OK", string cancel = "Cancel", string? placeholder = null, int maxLength = -1, Keyboard? keyboard = null, string initialValue = "", Func<string, (bool, string)>? predicate = null)
        {
            var dialog = new PromptPopup(title, message, accept, cancel, placeholder, maxLength, keyboard, initialValue, predicate);

            if (dialog.Content is not null)
            {
                dialog.Content.FlowDirection = flowDirection;
            }

            return (await GetMainPage().ShowPopupAsync(dialog))?.ToString() ?? string.Empty;
        }

        private static Keyboard GetKeyboard(InputType inputType)
            => inputType switch
            {
                InputType.Plain => Keyboard.Plain,
                InputType.Chat => Keyboard.Chat,
                InputType.Decimal => Keyboard.Numeric,
                InputType.Email => Keyboard.Email,
                InputType.Numeric => Keyboard.Numeric,
                InputType.Telephone => Keyboard.Telephone,
                InputType.Text => Keyboard.Text,
                InputType.Url => Keyboard.Url,
                _ => Keyboard.Default
            };

        private static Page GetMainPage()
        {
#if NET9_0_OR_GREATER
            var mainPage = (Application.Current?.Windows?[0]?.Page) ?? throw new InvalidOperationException("Application.Current.Windows[0].Page cannot be null.");
#else
            var mainPage = (Application.Current?.MainPage) ?? throw new InvalidOperationException("Application.Current.MainPage cannot be null.");
#endif
            return mainPage is Shell ? Shell.Current : mainPage;
        }
    }
}
