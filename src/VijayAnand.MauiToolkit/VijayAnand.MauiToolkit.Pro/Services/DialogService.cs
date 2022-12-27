namespace VijayAnand.MauiToolkit.Pro.Services
{
    public class DialogService : IDialogService
    {
        /// <summary>
        /// Displays an action sheet.
        /// </summary>
        /// <param name="title">The title of the action sheet.</param>
        /// <param name="message">The optional message of the action sheet.</param>
        /// <param name="cancel">The cancellation action.</param>
        /// <param name="destruction">The destructive action.</param>
        /// <param name="defaultButton">The action to be in focus on launch, if supported.</param>
        /// <param name="buttons">The list of actions to be displayed.</param>
        /// <returns>The name of the action that the user has opted for.</returns>
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

        /// <summary>
        /// Displays an alert.
        /// </summary>
        /// <param name="title">The title of the alert.</param>
        /// <param name="message">The message to be shown in the alert.</param>
        /// <param name="cancel">The text on the cancel button.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Displays an alert with an option to accept or cancel.
        /// </summary>
        /// <param name="title">The title of the alert.</param>
        /// <param name="message">The message to be shown in the alert.</param>
        /// <param name="accept">The text on the accept button.</param>
        /// <param name="cancel">The text on the cancel button.</param>
        /// <returns><c>True</c> if the user clicks on the <paramref name="accept"/> button. Otherwise <c>false</c>.</returns>
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

        /// <summary>
        /// Displays a prompt to get input from the user.
        /// </summary>
        /// <param name="title">The title of the prompt.</param>
        /// <param name="message">The message to be shown in the prompt.</param>
        /// <param name="accept">The text on the accept button.</param>
        /// <param name="cancel">The text on the cancel button.</param>
        /// <param name="placeholder">The placeholder text when the prompt is blank.</param>
        /// <param name="maxLength">The maximum length of the user input.</param>
        /// <param name="inputType">The type of the user input.</param>
        /// <param name="initialValue">The initial value, if any.</param>
        /// <returns>The value entered in the prompt if the user clicks on the accept button. Otherwise blank.</returns>
        public async Task<string> DisplayPromptAsync(string title, string message, string accept = "OK", string cancel = "Cancel", string? placeholder = null, int maxLength = -1, InputType inputType = InputType.Default, string initialValue = "")
        {
            var dialog = new PromptPopup(title, message, accept, cancel, placeholder, maxLength, inputType, initialValue);

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
    }
}
