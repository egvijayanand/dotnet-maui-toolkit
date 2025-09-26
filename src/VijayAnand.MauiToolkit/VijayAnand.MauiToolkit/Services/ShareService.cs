namespace VijayAnand.MauiToolkit.Services;

public class ShareService(IShare share) : IShareService
{
    public async Task ShareTextAsync(string title, string text)
    {
        try
        {
            await share.RequestAsync(new ShareTextRequest(text, title));
        }
        catch
        {
            throw;
        }
    }

    public async Task ShareUriAsync(string title, string text, string uri)
    {
        try
        {
            await share.RequestAsync(new ShareTextRequest(text, title) { Uri = uri });
        }
        catch
        {
            throw;
        }
    }
}
