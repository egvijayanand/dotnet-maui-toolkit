### VijayAnand.MauiToolkit.Pro

This is a toolkit with a set of helper methods and classes to simplify working with .NET MAUI and Blazor.

Published as a NuGet package - [VijayAnand.MauiToolkit.Pro](https://www.nuget.org/packages/VijayAnand.MauiToolkit.Pro/)

It depends on the following NuGet packages:

* [CommunityToolkit.Maui](https://www.nuget.org/packages/CommunityToolkit.Maui/)
* [VijayAnand.MauiToolkit.Core](https://www.nuget.org/packages/VijayAnand.MauiToolkit.Core/)

To start with, implements the concrete definition `DialogService` for the `IDialogService` abstraction defined in Core package with the `Popup` type from the `CommunityToolkit.Maui` NuGet package.

Most importantly, provides an extension method to register this service in .NET MAUI host builder startup:

`UseVijayAnandMauiToolkitPro()`

By default, the default value of configuration parameter is set to `ServiceRegistrations.All`.

Usage:

```cs
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>()
               .UseMauiCommunityToolkit()
               .UseVijayAnandMauiToolkitPro(); // Implicit value of ServiceRegistrations.All passed as configuration parameter

        return builder.Build();
    }
}
```
