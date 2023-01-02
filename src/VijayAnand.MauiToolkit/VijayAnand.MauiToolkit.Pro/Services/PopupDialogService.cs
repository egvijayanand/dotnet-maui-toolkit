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

            object? result;

            if (Shell.Current is not null)
            {
                result = await Shell.Current.ShowPopupAsync(dialog);
            }
            else
            {
                result = await Application.Current!.MainPage!.ShowPopupAsync(dialog);
            }

            return result?.ToString() ?? string.Empty;
        }

        public async Task<string> DisplayActionSheetAsync(string title, string cancel, string destruction, FlowDirection flowDirection, params string[] buttons)
        {
            var dialog = new ActionSheetPopup(title, string.Empty, cancel, destruction, null, buttons);

            if (dialog.Content is not null)
            {
                dialog.Content.FlowDirection = flowDirection;
            }

            object? result;

            if (Shell.Current is not null)
            {
                result = await Shell.Current.ShowPopupAsync(dialog);
            }
            else
            {
                result = await Application.Current!.MainPage!.ShowPopupAsync(dialog);
            }

            return result?.ToString() ?? string.Empty;
        }

        public Task DisplayAlertAsync(string title, string message, string cancel)
        {
            var dialog = new AlertPopup(title, message, cancel);

            if (Shell.Current is not null)
            {
                return Shell.Current.ShowPopupAsync(dialog);
            }
            else
            {
                return Application.Current!.MainPage!.ShowPopupAsync(dialog);
            }
        }

        public async Task<bool> DisplayAlertAsync(string title, string message, string accept, string cancel)
        {
            var dialog = new AlertPopup(title, message, accept, cancel);

            object? result;

            if (Shell.Current is not null)
            {
                result = await Shell.Current.ShowPopupAsync(dialog);
            }
            else
            {
                result = await Application.Current!.MainPage!.ShowPopupAsync(dialog);
            }

            return result is true;
        }

        public Task DisplayAlertAsync(string title, string message, string cancel, FlowDirection flowDirection)
        {
            var dialog = new AlertPopup(title, message, cancel);

            if (dialog.Content is not null)
            {
                dialog.Content.FlowDirection = flowDirection;
            }

            if (Shell.Current is not null)
            {
                return Shell.Current.ShowPopupAsync(dialog);
            }
            else
            {
                return Application.Current!.MainPage!.ShowPopupAsync(dialog);
            }
        }

        public async Task<bool> DisplayAlertAsync(string title, string message, string accept, string cancel, FlowDirection flowDirection)
        {
            var dialog = new AlertPopup(title, message, accept, cancel);

            if (dialog.Content is not null)
            {
                dialog.Content.FlowDirection = flowDirection;
            }

            object? result;

            if (Shell.Current is not null)
            {
                result = await Shell.Current.ShowPopupAsync(dialog);
            }
            else
            {
                result = await Application.Current!.MainPage!.ShowPopupAsync(dialog);
            }

            return result is true;
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

            object? result;

            if (Shell.Current is not null)
            {
                result = await Shell.Current.ShowPopupAsync(dialog);
            }
            else
            {
                result = await Application.Current!.MainPage!.ShowPopupAsync(dialog);
            }

            return result?.ToString() ?? string.Empty;

        }

        private static Keyboard GetKeyboard(InputType inputType) => inputType switch
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
    }
}
