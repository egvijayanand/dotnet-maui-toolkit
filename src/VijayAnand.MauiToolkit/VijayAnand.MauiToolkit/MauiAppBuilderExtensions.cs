using Microsoft.Extensions.DependencyInjection.Extensions;

namespace VijayAnand.MauiToolkit;

public static class MauiAppBuilderExtensions
{
    /// <summary>
    /// An extension method that registers the dependencies in the .NET MAUI startup pipeline.
    /// </summary>
    /// <param name="builder">App builder instance on which this method is invoked.</param>
    /// <param name="configuration">Selective service registration(s).</param>
    /// <returns>Same app builder instance on which this method is invoked.</returns>
    public static MauiAppBuilder UseVijayAnandMauiToolkit(
        this MauiAppBuilder builder,
        ServiceRegistrations configuration = ServiceRegistrations.All)
    {
        if (configuration.HasFlag(ServiceRegistrations.Dialogs) || configuration.HasFlag(ServiceRegistrations.All))
        {
            builder.Services.AddSingleton(GenericDialog.Instance);
            builder.Services.AddSingleton(MauiDialog.Instance);
        }

        if (configuration.HasFlag(ServiceRegistrations.Navigation) || configuration.HasFlag(ServiceRegistrations.All))
        {
            builder.Services.AddSingleton<INavigationService, NavigationService>();
        }

        if (configuration.HasFlag(ServiceRegistrations.Share) || configuration.HasFlag(ServiceRegistrations.All))
        {
            builder.Services.AddSingleton(Share.Default);
            builder.Services.AddSingleton<IShareService, ShareService>();
        }

        if (configuration.HasFlag(ServiceRegistrations.Theme) || configuration.HasFlag(ServiceRegistrations.All))
        {
            builder.Services.AddSingleton(Preferences.Default);
            builder.Services.AddSingleton<IThemeService, ThemeService>();
        }

        return builder;
    }

    /// <summary>
    /// Configures services for the application by invoking the specified delegate on the service collection.
    /// </summary>
    /// <param name="builder">The <see cref="MauiAppBuilder"/> instance on which this method is invoked.</param>
    /// <param name="configureDelegate">An optional delegate that provides custom configuration for the application's service collection.
    /// If <see langword="null"/>, no additional configuration is applied.</param>
    /// <returns>Returns the updated <see cref="MauiAppBuilder"/> instance for further configuration.</returns>
    public static MauiAppBuilder ConfigureServices(
        this MauiAppBuilder builder,
        Action<IServiceCollection>? configureDelegate)
    {
        configureDelegate?.Invoke(builder.Services);
        return builder;
    }

    /// <summary>
    /// Configures the MAUI application and registers services for the specified application and window types.
    /// </summary>
    /// <typeparam name="TApp">Application type.</typeparam>
    /// <typeparam name="TWindow">Window type.</typeparam>
    /// <param name="builder">The <see cref="MauiAppBuilder"/> instance on which this method is invoked.</param>
    /// <returns>Returns the updated <see cref="MauiAppBuilder"/> instance for further configuration.</returns>
    public static MauiAppBuilder UseMauiApp<TApp, TWindow>(this MauiAppBuilder builder)
        where TApp : class, IApplication
        where TWindow : Window
    {
        // Invoke the regular method and register the two other services in the pipeline.
        builder.UseMauiApp<TApp>();
        builder.Services.TryAddKeyedSingleton<TWindow>(Startup);
        builder.Services.TryAddSingleton<IWindowCreator, WindowCreator<TWindow>>();
        return builder;
    }

    /// <summary>
    /// Configures the MAUI application by registering the application type, window type, and page type in the service collection.
    /// </summary>
    /// <typeparam name="TApp">Application type.</typeparam>
    /// <typeparam name="TWindow">Window type.</typeparam>
    /// <typeparam name="TPage">Page type.</typeparam>
    /// <param name="builder">The <see cref="MauiAppBuilder"/> instance on which this method is invoked.</param>
    /// <returns>Returns the updated <see cref="MauiAppBuilder"/> instance for further configuration.</returns>
    public static MauiAppBuilder UseMauiApp<TApp, TWindow, TPage>(this MauiAppBuilder builder)
        where TApp : class, IApplication
        where TWindow : Window
        where TPage : Page
    {
        // Invoke the regular method and register the other services in the pipeline.
        builder.UseMauiApp<TApp>();
        builder.Services.TryAddKeyedSingleton<TWindow>(Startup);
        builder.Services.TryAddKeyedSingleton<TPage>(Startup);
        builder.Services.TryAddSingleton<IWindowCreator, WindowCreator<TWindow, TPage>>();
        return builder;
    }

    /// <summary>
    /// Configures the MAUI application by registering an application factory delegate with the specified window type.
    /// </summary>
    /// <typeparam name="TApp">Defines the type of the application that will be created and managed within the Maui framework.</typeparam>
    /// <typeparam name="TWindow">Specifies the type of window that will be used in the application.</typeparam>
    /// <param name="builder">The <see cref="MauiAppBuilder"/> instance on which this method is invoked.</param>
    /// <param name="appFactory">A function that creates an instance of the application using the provided service provider.</param>
    /// <returns>Returns the updated <see cref="MauiAppBuilder"/> instance for further configuration.</returns>
    public static MauiAppBuilder UseMauiApp<TApp, TWindow>(
        this MauiAppBuilder builder,
        Func<IServiceProvider, TApp> appFactory)
        where TApp : class, IApplication
        where TWindow : Window
    {
        // Invoke the regular method and register the two other services in the pipeline.
        builder.UseMauiApp(appFactory);
        builder.Services.TryAddKeyedSingleton<TWindow>(Startup);
        builder.Services.TryAddSingleton<IWindowCreator, WindowCreator<TWindow>>();
        return builder;
    }

    /// <summary>
    /// Configures the MAUI application and registers the application type and the window factory delegate to create the primary window.
    /// </summary>
    /// <typeparam name="TApp">Specifies the application type that implements the application interface and can be instantiated.</typeparam>
    /// <typeparam name="TWindow">Defines the type of window that will be created by the provided factory function.</typeparam>
    /// <param name="builder">The <see cref="MauiAppBuilder"/> instance on which this method is invoked.</param>
    /// <param name="windowFactory">A function that creates instances of the specified window type using a service provider.</param>
    /// <returns>Returns the updated <see cref="MauiAppBuilder"/> instance for further configuration.</returns>
    public static MauiAppBuilder UseMauiApp<TApp, TWindow>(
        this MauiAppBuilder builder,
        Func<IServiceProvider, TWindow> windowFactory)
        where TApp : class, IApplication
        where TWindow : Window
    {
        // Invoke the regular method and register the two other services in the pipeline.
        builder.UseMauiApp<TApp>();
        builder.Services.TryAddSingleton(windowFactory);
        builder.Services.TryAddSingleton<IWindowCreator>(sp => new WindowCreator(sp.GetRequiredService<TWindow>()));
        return builder;
    }

    /// <summary>
    /// Configures the MAUI and registers services for the application and window creation through factory delegates.
    /// </summary>
    /// <typeparam name="TApp">Represents the application type that implements the application interface and can be instantiated.</typeparam>
    /// <typeparam name="TWindow">Represents the window type that will be created for the application.</typeparam>
    /// <param name="builder">The <see cref="MauiAppBuilder"/> instance on which this method is invoked.</param>
    /// <param name="appFactory">A function that creates an instance of the application using the service provider.</param>
    /// <param name="windowFactory">A function that creates an instance of the window using the service provider.</param>
    /// <returns>Returns the updated <see cref="MauiAppBuilder"/> instance for further configuration.</returns>
    public static MauiAppBuilder UseMauiApp<TApp, TWindow>(
        this MauiAppBuilder builder,
        Func<IServiceProvider, TApp> appFactory,
        Func<IServiceProvider, TWindow> windowFactory)
        where TApp : class, IApplication
        where TWindow : Window
    {
        // Invoke the regular method and register the two other services in the pipeline.
        builder.UseMauiApp(appFactory);
        builder.Services.TryAddSingleton(windowFactory);
        builder.Services.TryAddSingleton<IWindowCreator>(sp => new WindowCreator(sp.GetRequiredService<TWindow>()));
        return builder;
    }

    /// <summary>
    /// Configures the MAUI application by registering the application type, window type, and page type in the service collection.
    /// </summary>
    /// <typeparam name="TApp">Application type.</typeparam>
    /// <typeparam name="TWindow">Window type.</typeparam>
    /// <typeparam name="TPage">Page type.</typeparam>
    /// <param name="builder">The <see cref="MauiAppBuilder"/> instance on which this method is invoked.</param>
    /// <param name="pageFactory">A function that creates instances of the specified page type using a service provider.</param>
    /// <returns>Returns the updated <see cref="MauiAppBuilder"/> instance for further configuration.</returns>
    public static MauiAppBuilder UseMauiApp<TApp, TWindow, TPage>(this MauiAppBuilder builder, Func<IServiceProvider, TPage> pageFactory)
        where TApp : class, IApplication
        where TWindow : Window
        where TPage : Page
    {
        // Invoke the regular method and register the other services in the pipeline.
        builder.UseMauiApp<TApp>();
        builder.Services.TryAddKeyedSingleton<TWindow>(Startup);
        builder.Services.TryAddSingleton(pageFactory);
        builder.Services.TryAddSingleton<IWindowCreator, WindowCreator<TWindow, TPage>>();
        return builder;
    }
}
