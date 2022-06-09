namespace VijayAnand.MauiToolkit.Core.Services
{
    public interface INavigationService
    {
        /// <summary>
        /// Navigates to the specified route.
        /// </summary>
        /// <param name="route">Target route.</param>
        /// <returns></returns>
        Task GoToAsync(string route);

        /// <summary>
        /// Navigates to the specified route with a parameter.
        /// </summary>
        /// <param name="route">Target route.</param>
        /// <param name="name">Route parameter name.</param>
        /// <param name="value">Route parameter value.</param>
        /// <returns></returns>
        Task GoToAsync(string route, string name, object value);

        /// <summary>
        /// Navigates to the specified route with a set of parameters.
        /// </summary>
        /// <param name="route">Target route.</param>
        /// <param name="routeParameters">Set of parameters of Name/Value pairs.</param>
        /// <returns></returns>
        Task GoToAsync(string route, IDictionary<string, object> routeParameters);

        /// <summary>
        /// Navigates to the specified route with a set of parameters.
        /// </summary>
        /// <param name="route">Target route.</param>
        /// <param name="routeParameters">Set of parameters represented as Name/Value <see cref="System.Tuple{T1, T2}"/>.</param>
        /// <returns></returns>
        Task GoToAsync(string route, params (string key, object value)[] routeParameters);

        /// <summary>
        /// Navigates one step backward.
        /// </summary>
        /// <returns></returns>
        Task GoBackAsync();

        /// <summary>
        /// Navigates one step backward.
        /// </summary>
        /// <param name="name">Route parameter name.</param>
        /// <param name="value">Route parameter value.</param>
        /// <returns></returns>
        Task GoBackAsync(string key, object value);

        /// <summary>
        /// Navigates one step backward.
        /// </summary>
        /// <param name="routeParameters">Set of parameters of Name/Value pairs.</param>
        /// <returns></returns>
        Task GoBackAsync(IDictionary<string, object> routeParameters);

        /// <summary>
        /// Navigates one step backward.
        /// </summary>
        /// <param name="routeParameters">Set of parameters represented as Name/Value <see cref="System.Tuple{T1, T2}"/>.</param>
        /// <returns></returns>
        Task GoBackAsync(params (string key, object value)[] routeParameters);
    }
}
