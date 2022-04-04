using System.Text;

namespace VijayAnand.MauiToolkit.Services
{
    public class NavigationService : INavigationService
    {
        public Task GoToAsync(string route)
        {
            if (Shell.Current is null)
            {
                throw new NotSupportedException($"Navigation with the '{nameof(GoToAsync)}' method is currently supported only with a Shell-enabled application.");
            }

            return Shell.Current.GoToAsync(route);
        }

        public Task GoToAsync(string route, string key, string value)
        {

            if (Shell.Current is null)
            {
                throw new NotSupportedException($"Navigation with the '{nameof(GoToAsync)}' method is currently supported only with a Shell-enabled application.");
            }

            return Shell.Current.GoToAsync($"{route}?{key}={value}");
        }

        public Task GoToAsync(string route, IDictionary<string, object> routeParameters)
        {
            if (Shell.Current is null)
            {
                throw new NotSupportedException($"Navigation with the '{nameof(GoToAsync)}' method is currently supported only with a Shell-enabled application.");
            }

            return Shell.Current.GoToAsync(BuildUri(route, routeParameters));
        }

        public Task GoBackAsync()
        {
            if (Shell.Current is null)
            {
                throw new NotSupportedException($"Navigation with the '{nameof(GoBackAsync)}' method is currently supported only with a Shell-enabled application.");
            }

            return Shell.Current.GoToAsync("..");
        }

        private static string BuildUri(string route, IDictionary<string, object> parameters)
        {
            var uri = new StringBuilder(route);

            if (parameters?.Count > 0)
            {
                uri.Append('?');
                uri.Append(string.Join("&", parameters.Select(item => $"{item.Key}={(item.Value is not null ? Uri.EscapeDataString(item.Value.ToString()) : string.Empty)}")));
            }

            return uri.ToString();
        }
    }
}
