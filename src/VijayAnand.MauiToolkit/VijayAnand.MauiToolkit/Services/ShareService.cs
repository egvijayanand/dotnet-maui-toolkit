namespace VijayAnand.MauiToolkit.Services
{
    public class ShareService : IShareService
    {
        private readonly IShare share;

        public ShareService(IShare share)
        {
            this.share = share;
        }

        public async Task ShareText(string title, string text)
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

        public async Task ShareUri(string title, string text, string uri)
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
}
