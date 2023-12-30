using Microsoft.Extensions.DependencyInjection;

namespace VijayAnand.Toolkit.Markup.Configuration
{
    public static class MauiAppBuilderExtensions
    {
        public static MauiAppBuilder ConfigureServices(this MauiAppBuilder builder,
                                                       Action<IServiceCollection>? configureDelegate)
        {
            configureDelegate?.Invoke(builder.Services);
            return builder;
        }
    }
}
