namespace VijayAnand.MauiToolkit.Core.Services
{
    public interface IDialogService
    {
        /// <summary>
        /// Displays an action sheet.
        /// </summary>
        /// <param name="title">The title of the action sheet.</param>
        /// <param name="cancel">The cancellation action.</param>
        /// <param name="destruction">The desctructive action.</param>
        /// <param name="buttons">The list of actions to be displayed.</param>
        /// <returns>The name of the action that the user has opted for.</returns>
        Task<string> DisplayActionSheet(string title, string cancel, string destruction, params string[] buttons);

        /// <summary>
        /// Displays an alert.
        /// </summary>
        /// <param name="title">The title of the alert.</param>
        /// <param name="message">The message to be shown in the alert.</param>
        /// <param name="cancel">The text on the cancel button.</param>
        /// <returns></returns>
        Task DisplayAlert(string title, string message, string cancel);

        /// <summary>
        /// Displays an alert with an option to accept or cancel.
        /// </summary>
        /// <param name="title">The title of the alert.</param>
        /// <param name="message">The message to be shown in the alert.</param>
        /// <param name="accept">The text on the accept button.</param>
        /// <param name="cancel">The text on the cancel button.</param>
        /// <returns>True, if the user clicks on the <paramref name="accept"/> button, otherwise false.</returns>
        Task<bool> DisplayAlert(string title, string message, string accept, string cancel);

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
        /// <returns></returns>
        Task<string> DisplayPromptAsync(string title, string message, string accept = "OK", string cancel = "Cancel", string? placeholder = null, int maxLength = -1, InputType inputType = InputType.Default, string initialValue = "");
    }
}
