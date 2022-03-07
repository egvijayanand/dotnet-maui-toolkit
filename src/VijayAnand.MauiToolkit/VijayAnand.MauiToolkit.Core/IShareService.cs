namespace VijayAnand.MauiToolkit.Core
{
    public interface IShareService
    {
        Task ShareText(string title, string text);

        Task ShareUri(string title, string text, string uri);
    }
}
