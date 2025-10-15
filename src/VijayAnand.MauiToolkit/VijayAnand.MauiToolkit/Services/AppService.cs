using Microsoft.Extensions.DependencyInjection;

namespace VijayAnand.MauiToolkit.Services;

public static class AppService
{
    /// <summary>
    /// Gets the service object of the specified type.
    /// </summary>
    /// <param name="serviceType">An object that specifies the type of service object to get.</param>
    /// <returns>A service object of type <paramref name="serviceType"/>. -or- null if there is no service object of type <paramref name="serviceType"/>.</returns>
    public static object? GetService(Type serviceType) => Current?.GetService(serviceType);

    /// <summary>
    /// Get service of type <typeparamref name="TService"/> from the System.IServiceProvider.
    /// </summary>
    /// <typeparam name="TService">The type of service object to get.</typeparam>
    /// <returns>A service object of type <typeparamref name="TService"/> or null if there is no such service.</returns>
    public static TService? GetService<TService>() =>
        Current is null ? default : Current.GetService<TService>();

    /// <summary>
    /// Gets the service object of the specified type.
    /// </summary>
    /// <param name="serviceType">An object that specifies the type of service object to get.</param>
    /// <returns>A service object of type <paramref name="serviceType"/>. -or- raises an <see cref="InvalidOperationException"/> if there is no such service.</returns>
    public static object GetRequiredService(Type serviceType) =>
        Current is null ? throw new InvalidOperationException("Platform Application cannot be null.") : Current.GetRequiredService(serviceType);

    /// <summary>
    /// Get service of type <typeparamref name="TService"/> from the System.IServiceProvider.
    /// </summary>
    /// <typeparam name="TService">The type of service object to get.</typeparam>
    /// <returns>A service object of type <typeparamref name="TService"/> -or- raises an <see cref="InvalidOperationException"/> if there is no such service.</returns>
    public static TService GetRequiredService<TService>() where TService : notnull =>
            Current is null ? throw new InvalidOperationException("Platform Application cannot be null.") : Current.GetRequiredService<TService>();

#if NET8_0_OR_GREATER
    /// <summary>
    /// Get service of type <typeparamref name="TService"/> from the System.IServiceProvider.
    /// </summary>
    /// <typeparam name="TService">The type of service object to get.</typeparam>
    /// <param name="serviceKey">An object that specifies the key of service object to get.</param>
    /// <param name="fallbackToGlobal">If true, and the keyed service is not found, the global service without a key will be returned if it exists.</param>
    /// <returns>A service object of type <typeparamref name="TService"/> or null if there is no such service.</returns>
    public static TService? GetKeyedService<TService>(object? serviceKey, bool fallbackToGlobal = false)
        => Current switch
        {
            null => default,
            _ => Current.GetKeyedService<TService>(serviceKey) ?? (fallbackToGlobal ? Current.GetService<TService>() : default)
        };

    /// <summary>
    /// Gets the service object of the specified type.
    /// </summary>
    /// <param name="serviceType">An object that specifies the type of service object to get.</param>
    /// <param name="serviceKey">An object that specifies the key of service object to get.</param>
    /// <returns>A service object of type <paramref name="serviceType"/>. -or- raises an <see cref="InvalidOperationException"/> if there is no such service.</returns>
    public static object GetRequiredKeyedService(Type serviceType, object? serviceKey) =>
        Current is null ? throw new InvalidOperationException("Platform Application cannot be null.") : Current.GetRequiredKeyedService(serviceType, serviceKey);

    /// <summary>
    /// Get service of type <typeparamref name="TService"/> from the System.IServiceProvider.
    /// </summary>
    /// <typeparam name="TService">The type of service object to get.</typeparam>
    /// <param name="serviceKey">An object that specifies the key of service object to get.</param>
    /// <returns>A service object of type <typeparamref name="TService"/> -or- raises an <see cref="InvalidOperationException"/> if there is no such service.</returns>
    public static TService GetRequiredKeyedService<TService>(object? serviceKey) where TService : notnull =>
            Current is null ? throw new InvalidOperationException("Platform Application cannot be null.") : Current.GetRequiredKeyedService<TService>(serviceKey);

    public static IServiceProvider? Current =>
        IPlatformApplication.Current?.Services;
#else
    public static IServiceProvider Current =>
#if ANDROID || TIZEN
        MauiApplication.Current.Services;
#elif IOS || MACCATALYST
        MauiUIApplicationDelegate.Current.Services;
#elif WINDOWS10_0_17763_0_OR_GREATER
        MauiWinUIApplication.Current.Services;
#else
        throw new PlatformNotSupportedException();
#endif
#endif
}
