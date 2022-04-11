namespace VijayAnand.MauiToolkit.Services
{
    public interface IMauiDialogService : IDialogService
    {
        Task<string> DisplayActionSheetAsync(string title, string cancel, string destruction, FlowDirection flowDirection, params string[] buttons);

        Task DisplayAlertAsync(string title, string message, string cancel, FlowDirection flowDirection);

        Task<bool> DisplayAlertAsync(string title, string message, string accept, string cancel, FlowDirection flowDirection);

        Task<string> DisplayPromptAsync(string title, string message, string accept = "OK", string cancel = "Cancel", string? placeholder = null, int maxLength = -1, Keyboard? keyboard = null, string initialValue = "");
    }
}
