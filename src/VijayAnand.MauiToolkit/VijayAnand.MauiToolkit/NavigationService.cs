using System.Text;

namespace VijayAnand.MauiToolkit
{
    public class NavigationService : INavigationService
    {
        public async Task GoToAsync(string uri)
        {
            await Shell.Current.GoToAsync(uri);
        }

        public async Task GoToAsync(string uri, string key, string value)
        {
            await Shell.Current.GoToAsync($"{uri}?{key}={value}");
        }

        public async Task GoToAsync(string uri, Dictionary<string, object> parameters)
        {
            await Shell.Current.GoToAsync(BuildUri(uri, parameters));
        }

        public async Task GoBackAsync(bool modal = false)
        {
            if (modal)
            {
                if (Shell.Current.Navigation.ModalStack.Count > 0)
                {
                    await Shell.Current.Navigation.PopModalAsync();
                }
            }
            else
            {
                await Shell.Current.Navigation.PopAsync();
            }
        }

        private static string BuildUri(string uri, Dictionary<string, object> parameters)
        {
            var fullUrl = new StringBuilder(uri);
            fullUrl.Append('?');
            fullUrl.Append(string.Join("&", parameters.Select(item => $"{item.Key}={item.Value}")));
            return fullUrl.ToString();
        }
    }
}
