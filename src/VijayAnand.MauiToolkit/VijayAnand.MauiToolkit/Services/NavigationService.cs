using System.Text;

namespace VijayAnand.MauiToolkit.Services
{
    public class NavigationService : INavigationService
    {
        private const string BackNavigationRoute = "..";

        public Task GoToAsync(string route)
        {
            if (Shell.Current is null)
            {
                throw new NotSupportedException($"Navigation with the '{nameof(GoToAsync)}' method is currently supported only with a Shell-enabled application.");
            }

            return Shell.Current.GoToAsync(route);
        }

        public Task GoToAsync(string route, string key, object value)
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

        public Task GoToAsync(string route, params (string key, object value)[] routeParameters)
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

            return Shell.Current.GoToAsync(BackNavigationRoute);
        }

        public Task GoBackAsync(string key, object value)
        {
            if (Shell.Current is null)
            {
                throw new NotSupportedException($"Navigation with the '{nameof(GoBackAsync)}' method is currently supported only with a Shell-enabled application.");
            }

            return Shell.Current.GoToAsync($"{BackNavigationRoute}?{key}={value}");
        }

        public Task GoBackAsync(IDictionary<string, object> routeParameters)
        {
            if (Shell.Current is null)
            {
                throw new NotSupportedException($"Navigation with the '{nameof(GoBackAsync)}' method is currently supported only with a Shell-enabled application.");
            }

            return Shell.Current.GoToAsync(BuildUri(BackNavigationRoute, routeParameters));
        }

        public Task GoBackAsync(params (string key, object value)[] routeParameters)
        {
            if (Shell.Current is null)
            {
                throw new NotSupportedException($"Navigation with the '{nameof(GoBackAsync)}' method is currently supported only with a Shell-enabled application.");
            }

            return Shell.Current.GoToAsync(BuildUri(BackNavigationRoute, routeParameters));
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

        private static string BuildUri(string route, params (string key, object value)[] parameters)
        {
            var uri = new StringBuilder(route);

            if (parameters?.Length > 0)
            {
                uri.Append('?');
                uri.Append(string.Join("&", parameters.Select(item => $"{item.key}={(item.value is not null ? Uri.EscapeDataString(item.value.ToString()) : string.Empty)}")));
            }

            return uri.ToString();
        }
    }
}
