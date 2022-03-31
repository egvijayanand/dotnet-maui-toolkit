using Microsoft.Maui.Essentials.Implementations;

#nullable enable

namespace VijayAnand.MauiToolkit
{
    public static class MauiAppBuilderExtensions
    {
        public static MauiAppBuilder UseVijayAnandMauiToolkit(this MauiAppBuilder builder,
                                                              ServiceRegistrations configuration = ServiceRegistrations.All)
        {
            if (configuration is ServiceRegistrations.Dialogs or ServiceRegistrations.All)
            {
                builder.Services.AddSingleton<IDialogService, DialogService>();
                builder.Services.AddSingleton<IMauiDialogService, DialogService>();
            }

            if (configuration is ServiceRegistrations.Navigation or ServiceRegistrations.All)
            {
                builder.Services.AddSingleton<INavigationService, NavigationService>();
            }

            if (configuration is ServiceRegistrations.Share or ServiceRegistrations.All)
            {
                builder.Services.AddSingleton<IShareService, ShareService>();
            }

            if (configuration is ServiceRegistrations.Theme or ServiceRegistrations.All)
            {
                builder.Services.AddSingleton<IPreferences, PreferencesImplementation>();
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

        private static bool HasFlag(this ServiceRegistrations configured, ServiceRegistrations option)
            => (configured & option) == option;
    }

    [Flags]
    public enum ServiceRegistrations
    {
        Dialogs = 1,
        Navigation = 2,
        Share = 4,
        Theme = 8,
        All = 2147483647
    }
}
