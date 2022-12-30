namespace VijayAnand.MauiToolkit.Pro.Services
{
    /// <summary>
    /// Static type to access the implementation instance of <seealso cref="IDialogService" />.
    /// </summary>
    public static class PopupDialog
    {
        private static IDialogService? _dialogService;

        /// <summary>
        /// Provides access to an instance of <see cref="PopupDialogService" /> type.
        /// </summary>
        public static IDialogService Instance => _dialogService ??= new PopupDialogService();
    }
}
