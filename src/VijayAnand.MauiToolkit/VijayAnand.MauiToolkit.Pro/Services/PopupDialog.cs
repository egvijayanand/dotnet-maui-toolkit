namespace VijayAnand.MauiToolkit.Pro.Services
{
    /// <summary>
    /// Static type to access the instance of <seealso cref="DialogService" /> type.
    /// </summary>
    public static class PopupDialog
    {
        private static IDialogService? _dialogService;

        public static IDialogService Instance => _dialogService ??= new DialogService();
    }
}
