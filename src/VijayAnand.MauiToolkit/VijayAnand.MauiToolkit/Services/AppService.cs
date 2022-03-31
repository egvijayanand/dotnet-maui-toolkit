﻿namespace VijayAnand.MauiToolkit.Services
{
    public static class AppService
    {
        public static TService? GetService<TService>() => Current.GetService<TService>();

        internal static IServiceProvider Current =>
#if ANDROID
            MauiApplication.Current.Services;
#elif IOS || MACCATALYST
            MauiUIApplicationDelegate.Current.Services;
#elif WINDOWS10_0_17763_0_OR_GREATER
            MauiWinUIApplication.Current.Services;
#else
            throw new PlatformNotSupportedException();
#endif
    }
}