namespace VijayAnand.MauiToolkit.Services
{
    /// <summary>
    /// Abstraction for the commonly used dialogs with support for layout direction (LTR or RTL).
    /// </summary>
    public interface IMauiDialogService : IDialogService
    {
        /// <summary>
        /// Displays an action sheet.
        /// </summary>
        /// <param name="title">The title of the action sheet.</param>
        /// <param name="cancel">The cancellation action.</param>
        /// <param name="destruction">The destructive action.</param>
        /// <param name="flowDirection">Localization option.</param>
        /// <param name="buttons">The list of actions to be displayed.</param>
        /// <returns>The name of the action that the user has opted for.</returns>
        Task<string> DisplayActionSheetAsync(string title, string cancel, string destruction, FlowDirection flowDirection, params string[] buttons);

        /// <summary>
        /// Displays an alert.
        /// </summary>
        /// <param name="title">The title of the alert.</param>
        /// <param name="message">The message to be shown in the alert.</param>
        /// <param name="cancel">The text on the cancel button.</param>
        /// <param name="flowDirection">Localization option.</param>
        /// <returns></returns>
        Task DisplayAlertAsync(string title, string message, string cancel, FlowDirection flowDirection);

        /// <summary>
        /// Displays an alert with an option to accept or cancel.
        /// </summary>
        /// <param name="title">The title of the alert.</param>
        /// <param name="message">The message to be shown in the alert.</param>
        /// <param name="accept">The text on the accept button.</param>
        /// <param name="cancel">The text on the cancel button.</param>
        /// <param name="flowDirection">Localization option.</param>
        /// <returns><c>True</c> if the user clicks on the <paramref name="accept"/> button. Otherwise <c>false</c>.</returns>
        Task<bool> DisplayAlertAsync(string title, string message, string accept, string cancel, FlowDirection flowDirection);

        /// <summary>
        /// Displays a prompt to get input from the user.
        /// </summary>
        /// <param name="title">The title of the prompt.</param>
        /// <param name="message">The message to be shown in the prompt.</param>
        /// <param name="flowDirection">Localization option.</param>
        /// <param name="accept">The text on the accept button.</param>
        /// <param name="cancel">The text on the cancel button.</param>
        /// <param name="placeholder">The placeholder text when the prompt is blank.</param>
        /// <param name="maxLength">The maximum length of the user input.</param>
        /// <param name="keyboard">The type of the user input.</param>
        /// <param name="initialValue">The initial value, if any.</param>
        /// <param name="predicate">
        /// A function that validates the value entered by the user.<br />
        /// This will get invoked when the user clicks/taps on the accept button.<br />
        /// If it returns <see langword="true"/>, the dialog will be dismissed, otherwise remain presented.<br />
        /// Not supported on SDK implemented dialogs.
        /// </param>
        /// <returns>The value entered in the prompt if the user clicks on the accept button. Otherwise blank.</returns>
        Task<string> DisplayPromptAsync(string title, string message, FlowDirection flowDirection, string accept = "OK", string cancel = "Cancel", string? placeholder = null, int maxLength = -1, Keyboard? keyboard = null, string initialValue = "", Func<string, (bool, string)>? predicate = null);
    }
}
