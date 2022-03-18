namespace VijayAnand.MauiToolkit
{
    public static class MauiAppBuilderExtensions
    {
        public static MauiAppBuilder UseVijayAnandMauiToolkit(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<IDialogService, DialogService>();
            builder.Services.AddSingleton<IMauiDialogService, DialogService>();
            builder.Services.AddSingleton<INavigationService, NavigationService>();
            builder.Services.AddSingleton<IShareService, ShareService>();
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
