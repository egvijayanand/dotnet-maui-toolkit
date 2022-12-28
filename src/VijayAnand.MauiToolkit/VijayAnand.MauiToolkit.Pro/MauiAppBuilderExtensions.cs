namespace VijayAnand.MauiToolkit.Pro
{
    public static class MauiAppBuilderExtensions
    {
        /// <summary>
        /// An extension method that registers the dependencies in the .NET MAUI startup pipeline.
        /// </summary>
        /// <param name="builder">App builder instance on which this method is invoked.</param>
        /// <param name="configuration">Selective service registration(s).</param>
        /// <returns>Same app builder instance on which this method is invoked.</returns>
        public static MauiAppBuilder UseVijayAnandMauiToolkitPro(this MauiAppBuilder builder,
                                                                 ServiceRegistrations configuration = ServiceRegistrations.All)
        {
            if (configuration.HasFlag(ServiceRegistrations.Dialogs) || configuration.HasFlag(ServiceRegistrations.All))
            {
                builder.Services.AddSingleton(PopupDialog.Instance);
            }

            return builder;
        }
    }
}
