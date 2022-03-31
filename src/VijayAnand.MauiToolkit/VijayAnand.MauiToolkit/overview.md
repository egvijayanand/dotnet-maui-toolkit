### VijayAnand.MauiToolkit

This is a toolkit with a set of helper methods and classes to simplify working with .NET MAUI and Blazor.

Published as a NuGet package - [VijayAnand.MauiToolkit](https://www.nuget.org/packages/VijayAnand.MauiToolkit/)

It depends on [VijayAnand.MauiToolkit.Core](https://www.nuget.org/packages/VijayAnand.MauiToolkit.Core/) NuGet package.

To start with, implements the concrete definition of the abstractions defined in Core package:

* Dialogs - `DialogService` (works with MainPage or Shell definition)
  - Additional abstraction specific to .NET MAUI with `FlowDirection`
* Navigation - `NavigationService` (based on Shell Navigation pattern)
* Share - `ShareService` (based on Maui Essentials)
* Theme - `ThemeService` (based on UserAppTheme property)

And includes a set of Markup extension methods for rapid application development with C#.

These fluent APIs are made available in the `VijayAnand.MauiToolkit.Markup` namespace.

Most importantly, provides an extension method to register these services in .NET MAUI host builder startup:

`UseVijayAnandMauiToolkit()`

Now it's possible to selectively register the services required into the DI container.

Added a configuration parameter of type ServiceRegistrations (Flags-attributed) enum to the `UseVijayAnandMauiToolkit()` method

To illustrate with a sample, if only interested in NavigationService:

Then, invoke `UseVijayAnandMauiToolkit(ServiceRegistrations.Navigation)`

And if DialogService is required along with NavigationService:

Then, invoke `UseVijayAnandMauiToolkit(ServiceRegistrations.Dialogs | ServiceRegistrations.Navigation)`

By default, the default value of configuration parameter is set to `ServiceRegistrations.All`

Usage:

```cs
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>()
               .UseVijayAnandMauiToolkit(); // Implicit value of ServiceRegistrations.All passed as configuration parameter
        return builder.Build();
    }
}
```
