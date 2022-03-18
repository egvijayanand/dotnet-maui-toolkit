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
        Task GoToAsync(string route, string name, string value);

        /// <summary>
        /// Navigates to the specified route with a set of parameters.
        /// </summary>
        /// <param name="route">Target route.</param>
        /// <param name="routeParameters">Set of parameters of Name/Value pairs.</param>
        /// <returns></returns>
        Task GoToAsync(string route, IDictionary<string, object> routeParameters);

        /// <summary>
        /// Navigates one step backward.
        /// </summary>
        /// <returns></returns>
        Task GoBackAsync();
    }
}
