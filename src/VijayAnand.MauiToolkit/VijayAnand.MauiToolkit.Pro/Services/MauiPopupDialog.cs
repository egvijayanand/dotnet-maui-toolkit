using VijayAnand.MauiToolkit.Services;

namespace VijayAnand.MauiToolkit.Pro.Services
{
    /// <summary>
    /// Static type to access the implementation instance of <seealso cref="IMauiDialogService" />.
    /// </summary>
    public static class MauiPopupDialog
    {
        private static IMauiDialogService? _dialogService;

        /// <summary>
        /// Provides access to an instance of <see cref="PopupDialogService" /> type.
        /// </summary>
        public static IMauiDialogService Instance => _dialogService ??= new PopupDialogService();
    }
}
