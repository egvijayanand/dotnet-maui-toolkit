### VijayAnand.MauiToolkit.Core

This is a toolkit with a set of abstractions to simplify working with .NET MAUI and Blazor.

It's built on top of .NET 6 and published as a NuGet package - [![VijayAnand.MauiToolkit.Core - NuGet Package](https://badgen.net/nuget/v/VijayAnand.MauiToolkit.Core/)](https://www.nuget.org/packages/VijayAnand.MauiToolkit.Core/)

The objective is to ease the development of the `Razor Class Library` (RCL) so that it can be shared with all Blazor targets (.NET MAUI, Server, WebAssembly, Windows Forms, and WPF).

And .NET MAUI targets Android, iOS, macOS (via Mac Catalyst), and Windows (via WinUI 3).

To start with defines the following abstractions:

* Dialogs - `IDialogService`
* Navigation - `INavigationService`
* Share - `IShareService`
* Theme - `IThemeService`

A Model class for UserToken and frequently used Constants for OAuth / OIDC authentication.

### VijayAnand.MauiToolkit

This is a toolkit with a set of helper methods and classes to simplify working with .NET MAUI and Blazor.

Published as a NuGet package - [![VijayAnand.MauiToolkit - NuGet Package](https://badgen.net/nuget/v/VijayAnand.MauiToolkit/)](https://www.nuget.org/packages/VijayAnand.MauiToolkit/)

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

Added a configuration parameter of Enum type `ServiceRegistrations` (Flags-attributed) to the `UseVijayAnandMauiToolkit()` method.

To illustrate with a sample, if only interested in NavigationService:

Then, invoke `UseVijayAnandMauiToolkit(ServiceRegistrations.Navigation)`.

And if DialogService is required along with NavigationService:

Then, invoke `UseVijayAnandMauiToolkit(ServiceRegistrations.Dialogs | ServiceRegistrations.Navigation)`.

By default, the default value of configuration parameter is set to `ServiceRegistrations.All`.

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

### VijayAnand.MauiBlazor.Markup

This toolkit a set of fluent helper methods and classes to simplify working with .NET MAUI Blazor in C#.

This toolkit depends on [Microsoft.AspNetCore.Components.WebView.Maui](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebView.Maui) NuGet package.

|Package|NuGet|
|:---:|:---:|
[.NET MAUI Blazor Toolkit](https://www.nuget.org/packages/VijayAnand.MauiBlazor.Markup/)|[![NuGet Package](https://badgen.net/nuget/v/VijayAnand.MauiBlazor.Markup/)](https://www.nuget.org/packages/VijayAnand.MauiBlazor.Markup/)

Most useful method will be `Configure`, which can be invoked on an instance of a BlazorWebView and its derivatives, and it simplifies the initialization of BlazorWebView into a single fluent method call as shown in the below sample.

Note: `Gateway` is a `Razor` component and assumes it can receive a parameter named `Foo` as described in the sample underneath.

```CS
namespace MyApp;

public class HomePage : ContentPage
{
    public HomePage()
    {
        // A BlazorWebView can manage multiple RootComponents, to achieve this, define another Tuple with values of that component        
        // The method and Tuple parameter names are shown for clarity and it's optional
        // Blazor component can have initialization parameters, which can be supplied thro parameters, a dictionary of keyValues 
        // where key is of type string and value is of type object
        
        // Without initialization parameters
        Content = new BlazorWebView().Configure(hostPage: "wwwroot/index.html", (selector: "#app", componentType: typeof(Gateway), parameters: null));
        
        // With optional initialization parameters
        Content = new BlazorWebView().Configure(hostPage: "wwwroot/index.html", (selector: "#app", componentType: typeof(Gateway), parameters: new Dictionary<string, object?> { [nameof(Gateway.Foo)] = "Bar" }));
        
        // In a much simplified form - Real intended usage        
        // Without initialization parameters
        Content = new BlazorWebView().Configure("wwwroot/index.html", ("#app", typeof(Gateway), null));
        
        // With optional initialization parameters
        Content = new BlazorWebView().Configure("wwwroot/index.html", ("#app", typeof(Gateway), new Dictionary<string, object?> { [nameof(Gateway.Foo)] = "Bar" }));
    }
}
```
```razor
@page "/gateway"

<h2>I'm a razor component named Gateway and I can receive a parameter named Foo.</h2>

@code {
    [Parameter]
    public string Foo { get; set; }
}
```
<!--
```CS
// For brevity, only the necessary code is made available. This can be nested anywhere a View can be defined
// The method and Tuple parameter names are shown for clarity and it's optional
// A BlazorWebView can manage multiple RootComponents, to achieve this, define another Tuple with values of that component
// Blazor component can have initialization parameters, which can be supplied thro parameters, a dictionary of keyValues 
// where key is of type string and value is of type object
new BlazorWebView().Configure(hostPage: "wwwroot/index.html", (selector: "#app", componentType: typeof(Gateway), parameters: null))
// Another example with component initialization parameters
new BlazorWebView().Configure(hostPage: "wwwroot/index.html", (selector: "#app", componentType: typeof(Gateway), parameters: new Dictionary<string, object?> { ["Foo"] = "Bar" }))
```
-->
