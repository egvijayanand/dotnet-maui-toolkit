Join me on [**Developer Thoughts**](https://egvijayanand.in/), an exclusive blog for .NET MAUI and Blazor, for articles on working with these toolkit and much more.

### VijayAnand.Toolkit.Markup

`VijayAnand.Toolkit.Markup` is a `shared class library NuGet package` with a set of fluent helper methods and classes for Xamarin.Forms / .NET MAUI to facilitate rapid UI development and better reuse in C#.

<!-- [![VijayAnand.Toolkit.Markup - NuGet Package](https://badgen.net/nuget/v/VijayAnand.Toolkit.Markup/)](https://www.nuget.org/packages/VijayAnand.Toolkit.Markup/) -->

|[VijayAnand.Toolkit.Markup](https://www.nuget.org/packages/VijayAnand.Toolkit.Markup/)|.NET 6|.NET 7|
|:---:|:---:|:---:|
|Stable|[![.NET 6](https://badgen.net/badge/nuget/v1.0.2/blue?icon=nuget)](https://www.nuget.org/packages/VijayAnand.Toolkit.Markup/1.0.2)|[![.NET 7](https://badgen.net/nuget/v/VijayAnand.Toolkit.Markup/?icon=nuget)](https://www.nuget.org/packages/VijayAnand.Toolkit.Markup/)|

This extends the features of the official C# Markup NuGet package from Microsoft.

`netstandard2.0` library targets Xamarin.Forms 5 and is dependent on the [Xamarin.CommunityToolkit.Markup](https://www.nuget.org/packages/Xamarin.CommunityToolkit.Markup/) package.

Whereas `net6.0` and `net7.0` library targets .NET MAUI and is dependent on the [CommunityToolkit.Maui.Markup](https://www.nuget.org/packages/CommunityToolkit.Maui.Markup/) package. *Note this is NOT MauiCompat package.*

### VijayAnand.MauiToolkit.Core

This is a toolkit with a set of abstractions to simplify working with .NET MAUI and Blazor.

|[VijayAnand.MauiToolkit.Core](https://www.nuget.org/packages/VijayAnand.MauiToolkit.Core/)|.NET 6|.NET 7|
|:---:|:---:|:---:|
|Stable|[![.NET 6](https://badgen.net/badge/nuget/v1.0.3/blue?icon=nuget)](https://www.nuget.org/packages/VijayAnand.MauiToolkit.Core/1.0.3)|[![.NET 7](https://badgen.net/nuget/v/VijayAnand.MauiToolkit.Core/?icon=nuget)](https://www.nuget.org/packages/VijayAnand.MauiToolkit.Core/)|
|Preview|[![.NET 6](https://badgen.net/badge/nuget/v1.1.0-preview.5/blue?icon=nuget)](https://www.nuget.org/packages/VijayAnand.MauiToolkit.Core/1.1.0-preview.5)|[![.NET 7](https://badgen.net/nuget/v/VijayAnand.MauiToolkit.Core/pre?icon=nuget)](https://www.nuget.org/packages/VijayAnand.MauiToolkit.Core/absoluteLatest)|

The objective is to ease the development of the `Razor Class Library` (RCL) so that it can be shared with all Blazor targets (.NET MAUI, Server, WebAssembly, Windows Forms, and WPF).

And .NET MAUI targets Android, iOS, macOS (via Mac Catalyst), Tizen, and Windows (via WinUI 3).

To start with defines the following abstractions:

* Dialogs - `IDialogService`
* Navigation - `INavigationService`
* Share - `IShareService`
* Theme - `IThemeService`

A Model class for UserToken and frequently used Constants for OAuth / OIDC authentication.

### VijayAnand.MauiToolkit

This is a toolkit with a set of helper methods and classes to simplify working with .NET MAUI and Blazor.

|[VijayAnand.MauiToolkit](https://www.nuget.org/packages/VijayAnand.MauiToolkit/)|.NET 6|.NET 7|
|:---:|:---:|:---:|
|Stable|[![.NET 6](https://badgen.net/badge/nuget/v1.0.3/blue?icon=nuget)](https://www.nuget.org/packages/VijayAnand.MauiToolkit/1.0.3)|[![.NET 7](https://badgen.net/nuget/v/VijayAnand.MauiToolkit/?icon=nuget)](https://www.nuget.org/packages/VijayAnand.MauiToolkit/)|
|Preview|[![.NET 6](https://badgen.net/badge/nuget/v1.1.0-preview.5/blue?icon=nuget)](https://www.nuget.org/packages/VijayAnand.MauiToolkit/1.1.0-preview.5)|[![.NET 7](https://badgen.net/nuget/v/VijayAnand.MauiToolkit/pre?icon=nuget)](https://www.nuget.org/packages/VijayAnand.MauiToolkit/absoluteLatest)|

It depends on [VijayAnand.MauiToolkit.Core](https://www.nuget.org/packages/VijayAnand.MauiToolkit.Core/) NuGet package.

To start with, implements the concrete definition of the abstractions defined in Core package:

* Dialogs - `DialogService` (works with MainPage or Shell definition)
  - Additional abstraction specific to .NET MAUI with `FlowDirection`
* Navigation - `NavigationService` (based on Shell Navigation pattern)
* Share - `ShareService` (based on Maui Essentials)
* Theme - `ThemeService` (based on UserAppTheme property)

And includes a set of Markup extension methods for rapid application development with C#.

These fluent APIs are made available in the `VijayAnand.MauiToolkit.Markup` namespace.

Provides an extension method to register these services in .NET MAUI host builder startup:

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
### VijayAnand.MauiToolkit.Pro

This is a toolkit with a set of helper methods and classes to simplify working with .NET MAUI and Blazor.

|[VijayAnand.MauiToolkit.Pro](https://www.nuget.org/packages/VijayAnand.MauiToolkit.Pro/)|.NET 6|.NET 7|
|:---:|:---:|:---:|
|Preview|[![.NET 6](https://badgen.net/badge/nuget/v1.1.0-preview.5/blue?icon=nuget)](https://www.nuget.org/packages/VijayAnand.MauiToolkit.Pro/1.1.0-preview.5)|[![.NET 7](https://badgen.net/nuget/v/VijayAnand.MauiToolkit.Pro/pre?icon=nuget)](https://www.nuget.org/packages/VijayAnand.MauiToolkit.Pro/absoluteLatest)|

It depends on the following NuGet packages:

* [CommunityToolkit.Maui](https://www.nuget.org/packages/CommunityToolkit.Maui/)
* [VijayAnand.MauiToolkit](https://www.nuget.org/packages/VijayAnand.MauiToolkit/)

To start with, implements the concrete definition `PopupDialogService` for the `IDialogService` abstraction defined in Core package and `IMauiDialogService` abstraction defined in Regular package with the `Popup` type from the `CommunityToolkit.Maui` NuGet package.

Provides an extension method to register this service in .NET MAUI host builder startup:

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

### VijayAnand.MauiBlazor.Markup

This toolkit a set of fluent helper methods and classes to simplify working with .NET MAUI Blazor in C#.

This toolkit depends on [Microsoft.AspNetCore.Components.WebView.Maui](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebView.Maui) NuGet package.

|[VijayAnand.MauiBlazor.Markup](https://www.nuget.org/packages/VijayAnand.MauiBlazor.Markup/)|.NET 6|.NET 7|.NET 8|
|:---:|:---:|:---:|:---:|
|Stable|[![.NET 6](https://badgen.net/badge/nuget/v1.0.10/blue?icon=nuget)](https://www.nuget.org/packages/VijayAnand.MauiBlazor.Markup/1.0.10)|[![.NET 7](https://badgen.net/nuget/v/VijayAnand.MauiBlazor.Markup/?icon=nuget)](https://www.nuget.org/packages/VijayAnand.MauiBlazor.Markup/)|[![.NET 8](https://badgen.net/nuget/v/VijayAnand.MauiBlazor.Markup/pre?icon=nuget)](https://www.nuget.org/packages/VijayAnand.MauiBlazor.Markup/absoluteLatest)|

Most useful method will be `Configure`, which can be invoked on an instance of a BlazorWebView and its derivatives, and it simplifies the initialization of BlazorWebView into a single fluent method call as shown in the below sample.

Note: `Gateway` is a `Razor` component and assumes it can receive a parameter named `Foo` as described in the sample underneath.

```cs
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
