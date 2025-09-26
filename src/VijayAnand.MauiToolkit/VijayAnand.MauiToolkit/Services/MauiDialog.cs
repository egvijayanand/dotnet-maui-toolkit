namespace VijayAnand.MauiToolkit.Services;

/// <summary>
/// Static type to access the instance of <seealso cref="DialogService" /> type.
/// </summary>
public static class MauiDialog
{
    private static IMauiDialogService? _dialogService;

    /// <summary>
    /// Provides access to the instance of <see cref="DialogService" />.
    /// </summary>
    public static IMauiDialogService Instance => _dialogService ??= new DialogService();
}
