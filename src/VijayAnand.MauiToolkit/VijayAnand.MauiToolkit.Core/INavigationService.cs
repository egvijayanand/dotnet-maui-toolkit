namespace VijayAnand.MauiToolkit.Core
{
    public interface INavigationService
    {
        Task GoToAsync(string uri);

        Task GoToAsync(string uri, string key, string value);

        Task GoToAsync(string uri, Dictionary<string, object> parameters);

        Task GoBackAsync(bool modal = false);
    }
}
