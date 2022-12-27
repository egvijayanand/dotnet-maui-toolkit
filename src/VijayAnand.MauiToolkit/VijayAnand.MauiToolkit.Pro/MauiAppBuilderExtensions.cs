namespace VijayAnand.MauiToolkit.Pro
{
    public static class MauiAppBuilderExtensions
    {
        public static MauiAppBuilder UseVijayAnandMauiToolkitPro(this MauiAppBuilder builder,
                                                                 ServiceRegistrations configuration = ServiceRegistrations.All)
        {
            if (configuration.HasFlag(ServiceRegistrations.Dialogs) || configuration.HasFlag(ServiceRegistrations.All))
            {
                builder.Services.AddSingleton<IDialogService, DialogService>();
            }

            return builder;
        }

        private static bool HasFlag(this ServiceRegistrations configured, ServiceRegistrations option)
            => (configured & option) == option;
    }
}
