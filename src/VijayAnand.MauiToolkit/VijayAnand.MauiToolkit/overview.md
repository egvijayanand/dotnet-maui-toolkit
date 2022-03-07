### VijayAnand.MauiToolkit

This is a toolkit with a set of helper methods and classes to simplify working with .NET MAUI and Blazor.

Published as a NuGet package - [VijayAnand.MauiToolkit](https://www.nuget.org/packages/VijayAnand.MauiToolkit/)

It depends on [VijayAnand.MauiToolkit.Core](https://www.nuget.org/packages/VijayAnand.MauiToolkit.Core/) NuGet package.

To start with, implements the concrete definition of the abstractions defined in Core package:

* Dialogs - `DialogService` (works with MainPage or Shell definition)
  - Additional abstraction specific to .NET MAUI with `FlowDirection`
* Navigation - `NavigationService` (based on Shell Navigation pattern)
* Share - `ShareService` (based on Maui Essentials)

Most importantly, provides the below method to register these services in .NET MAUI host builder startup:

`UseVijayAnandMauiToolkit()`

Usage:

```cs
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>()
               .UseVijayAnandMauiToolkit();
        return builder.Build();
    }
}
```
