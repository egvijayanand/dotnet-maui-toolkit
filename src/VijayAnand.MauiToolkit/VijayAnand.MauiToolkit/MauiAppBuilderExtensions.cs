namespace VijayAnand.MauiToolkit
{
    public static class MauiAppBuilderExtensions
    {
        /// <summary>
        /// An extension method that registers the dependencies in the .NET MAUI startup pipeline.
        /// </summary>
        /// <param name="builder">App builder instance on which this method is invoked.</param>
        /// <param name="configuration">Selective service registration(s).</param>
        /// <returns>Same app builder instance on which this method is invoked.</returns>
        public static MauiAppBuilder UseVijayAnandMauiToolkit(this MauiAppBuilder builder,
                                                              ServiceRegistrations configuration = ServiceRegistrations.All)
        {
            if (configuration.HasFlag(ServiceRegistrations.Dialogs) || configuration.HasFlag(ServiceRegistrations.All))
            {
                builder.Services.AddSingleton<IDialogService, DialogService>();
                builder.Services.AddSingleton<IMauiDialogService, DialogService>();
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

        public static MauiAppBuilder ConfigureServices(this MauiAppBuilder builder,
                                                       Action<IServiceCollection>? configureDelegate)
        {
            configureDelegate?.Invoke(builder.Services);
            return builder;
        }
    }
}
