namespace VijayAnand.MauiToolkit.Core.Services
{
    public interface IShareService
    {
        /// <summary>
        /// Opens the dialog to share the text
        /// </summary>
        /// <param name="title">The title of the share dialog.</param>
        /// <param name="text">The text to be shared.</param>
        /// <returns></returns>
        Task ShareText(string title, string text);

        /// <summary>
        /// Opens the dialog to share an uri
        /// </summary>
        /// <param name="title">The title of the share dialog.</param>
        /// <param name="text">The text to be displayed.</param>
        /// <param name="uri">The uri to be shared.</param>
        /// <returns></returns>
        Task ShareUri(string title, string text, string uri);
    }
}
