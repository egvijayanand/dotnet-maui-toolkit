namespace VijayAnand.MauiToolkit
{
    public class ShareService : IShareService
    {
        public async Task ShareText(string title, string text)
        {
            try
            {
                await Share.RequestAsync(new ShareTextRequest(text, title));
            }
            catch
            {
                throw;
            }
        }

        public async Task ShareUri(string title, string text, string uri)
        {
            try
            {
                await Share.RequestAsync(new ShareTextRequest() { Title = $"{title} - {text}", Uri = uri });
            }
            catch
            {
                throw;
            }
        }
    }
}
