Join me on [**Developer Thoughts**](https://egvijayanand.in/?utm_source=github&utm_medium=readme&utm_campaign=toolkit), an exclusive blog for .NET MAUI and Blazor, for articles on working with these toolkits and much more.

### [VijayAnand.Toolkit.Markup](https://www.nuget.org/packages/VijayAnand.Toolkit.Markup/)

This is a `shared class library NuGet package` with a set of fluent helper methods and classes for Xamarin.Forms / .NET MAUI to facilitate rapid UI development and better reuse in C#.

<!-- [![VijayAnand.Toolkit.Markup - NuGet Package](https://badgen.net/nuget/v/VijayAnand.Toolkit.Markup/)](https://www.nuget.org/packages/VijayAnand.Toolkit.Markup/) -->

|Channel|.NET 8|.NET 9|.NET 10|
|:---:|:---:|:---:|:---:|
|Stable|[![.NET 8](https://badgen.net/badge/nuget/v3.6.0/blue?icon=nuget&foo=bar)](https://www.nuget.org/packages/VijayAnand.Toolkit.Markup/3.6.0)|[![.NET 9](https://badgen.net/badge/nuget/v4.2.0/blue?icon=nuget&foo=bar)](https://www.nuget.org/packages/VijayAnand.Toolkit.Markup/4.2.0)|[![.NET 10](https://badgen.net/nuget/v/VijayAnand.Toolkit.Markup/?icon=nuget&foo=bar)](https://www.nuget.org/packages/VijayAnand.Toolkit.Markup/)|
<!--|Preview|-|-|[![.NET 10](https://badgen.net/nuget/v/VijayAnand.Toolkit.Markup/pre?icon=nuget&foo=bar)](https://www.nuget.org/packages/VijayAnand.Toolkit.Markup/absoluteLatest)|-->

This extends the features of the official C# Markup NuGet package from Microsoft.

`netstandard2.0` library targets Xamarin.Forms 5 and works on top of the [Xamarin.CommunityToolkit.Markup](https://www.nuget.org/packages/Xamarin.CommunityToolkit.Markup/) package.

Whereas the `net8.0`, `net9.0`, and `net10.0` library targets .NET MAUI and works on top of the [CommunityToolkit.Maui.Markup](https://www.nuget.org/packages/CommunityToolkit.Maui.Markup/) package.

### [VijayAnand.MauiToolkit.Core](https://www.nuget.org/packages/VijayAnand.MauiToolkit.Core/)

This is a toolkit with a set of abstractions to simplify working with .NET MAUI and Blazor.

|Channel|.NET 8|.NET 9|.NET 10|
|:---:|:---:|:---:|:---:|
|Stable|[![.NET 8](https://badgen.net/badge/nuget/v3.5.0/blue?icon=nuget)](https://www.nuget.org/packages/VijayAnand.MauiToolkit.Core/3.5.0)|[![.NET 9](https://badgen.net/badge/nuget/v4.3.0/blue?icon=nuget)](https://www.nuget.org/packages/VijayAnand.MauiToolkit.Core/4.3.0)|[![.NET 10](https://badgen.net/nuget/v/VijayAnand.MauiToolkit.Core/?icon=nuget&foo=bar)](https://www.nuget.org/packages/VijayAnand.MauiToolkit.Core/)|
<!--
|Preview|-|-|[![.NET 10](https://badgen.net/nuget/v/VijayAnand.MauiToolkit.Core/latest?icon=nuget)](https://www.nuget.org/packages/VijayAnand.MauiToolkit.Core/absoluteLatest)|
-->

The objective is to ease the development of the `Razor Class Library` (RCL) so that it can be shared with all Blazor targets (.NET MAUI, Server, WebAssembly, Windows Forms, and WPF).

And .NET MAUI targets Android, iOS, macOS (via Mac Catalyst), Tizen, and Windows (via WinUI 3).

To start with define the following abstractions:

* Dialogs - `IDialogService`
* Navigation - `INavigationService`
* Share - `IShareService`
* Theme - `IThemeService`

A Model class for UserToken and frequently used Constants for OAuth / OIDC authentication.

### [VijayAnand.MauiToolkit](https://www.nuget.org/packages/VijayAnand.MauiToolkit/)

This is a toolkit with a set of helper methods and classes to simplify working with .NET MAUI and Blazor.

|Channel|.NET 8|.NET 9|.NET 10|
|:---:|:---:|:---:|:---:|
|Stable|[![.NET 8](https://badgen.net/badge/nuget/v3.5.0/blue?icon=nuget)](https://www.nuget.org/packages/VijayAnand.MauiToolkit/3.5.0)|[![.NET 9](https://badgen.net/badge/nuget/v4.3.0/blue?icon=nuget)](https://www.nuget.org/packages/VijayAnand.MauiToolkit/4.3.0)|[![.NET 10](https://badgen.net/nuget/v/VijayAnand.MauiToolkit/?icon=nuget&foo=bar)](https://www.nuget.org/packages/VijayAnand.MauiToolkit/)|
<!--
|Preview|-|-|[![.NET 8](https://badgen.net/nuget/v/VijayAnand.MauiToolkit/latest?icon=nuget)](https://www.nuget.org/packages/VijayAnand.MauiToolkit/absoluteLatest)|
-->

It depends on [VijayAnand.MauiToolkit.Core](https://www.nuget.org/packages/VijayAnand.MauiToolkit.Core/) NuGet package.

#### [Integrated App Hosting Builder Method](https://egvijayanand.in/2025/09/29/integrated-app-hosting-builder-method-for-dotnet-maui-explained/)

The integrated app hosting builder method has been enhanced to support Application, Window, and Page in a single generic method call.

A single place to handle all configuration-related tasks.

The Application type will simply act as a container for global resources and handle startup and shutdown events.

The prebuilt Window type can be used as it is. No need for a factory delegate for simple scenarios.

While using generic overloads, there's no need to register the types in the DI container.

```cs
var builder = MauiApp.CreateBuilder();
builder.UseMauiApp<App, Window, MainPage>(window => window.Title = "MyApp");
// To use Shell as the initial page.
//builder.UseMauiApp<App, Window, AppShell>();
// Rest of the configuration ...
return builder.Build();
```

#### Abstract Implementations

Concrete definition of the abstractions defined in the Core package:

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

By default, the default value of the configuration parameter is set to `ServiceRegistrations.All`.

Usage:

```cs
var builder = MauiApp.CreateBuilder();
builder.UseMauiApp<App>()
       .UseVijayAnandMauiToolkit(); // Implicit value of ServiceRegistrations.All passed as a configuration parameter
return builder.Build();
```
### [VijayAnand.MauiToolkit.Pro](https://www.nuget.org/packages/VijayAnand.MauiToolkit.Pro/)

This is a toolkit with a set of helper methods and classes to simplify working with .NET MAUI and Blazor.

|Channel|.NET 8|.NET 9|
|:---:|:---:|:---:|
|Stable|[![.NET 8](https://badgen.net/badge/nuget/v3.5.0/blue?icon=nuget)](https://www.nuget.org/packages/VijayAnand.MauiToolkit.Pro/3.5.0)|[![.NET 9](https://badgen.net/badge/nuget/v4.3.0/blue?icon=nuget)](https://www.nuget.org/packages/VijayAnand.MauiToolkit.Pro/4.3.0)|
<!--
[![.NET 10](https://badgen.net/nuget/v/VijayAnand.MauiToolkit.Pro/?icon=nuget&foo=bar)](https://www.nuget.org/packages/VijayAnand.MauiToolkit.Pro/)|
-->
<!--
|Preview|-|-|[![.NET 10](https://badgen.net/nuget/v/VijayAnand.MauiToolkit.Pro/latest?icon=nuget)](https://www.nuget.org/packages/VijayAnand.MauiToolkit.Pro/absoluteLatest)|
-->

It depends on the following NuGet packages:

* [CommunityToolkit.Maui](https://www.nuget.org/packages/CommunityToolkit.Maui/)
* [VijayAnand.MauiToolkit](https://www.nuget.org/packages/VijayAnand.MauiToolkit/)

To start with implements the concrete definition `PopupDialogService` for the `IDialogService` abstraction defined in the Core package and `IMauiDialogService` abstraction defined in the Regular package with the `Popup` type from the `CommunityToolkit.Maui` NuGet package.

Provides an extension method to register this service in .NET MAUI host builder startup:

`UseVijayAnandMauiToolkitPro()`

By default, the default value of the configuration parameter is set to `ServiceRegistrations.All`.

Usage:

```cs
var builder = MauiApp.CreateBuilder();
builder.UseMauiApp<App>()
       .UseMauiCommunityToolkit()
       .UseVijayAnandMauiToolkitPro(); // Implicit value of ServiceRegistrations.All passed as configuration parameter
return builder.Build();
```

### [VijayAnand.MauiBlazor.Markup](https://www.nuget.org/packages/VijayAnand.MauiBlazor.Markup/)

This markup package is a set of fluent helper methods and classes to simplify working with .NET MAUI Blazor in C#.

It depends on the [Microsoft.AspNetCore.Components.WebView.Maui](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebView.Maui/) NuGet package.

|Channel|.NET 8|.NET 9|.NET 10|
|:---:|:---:|:---:|:---:|
|Stable|[![.NET 8](https://badgen.net/badge/nuget/v3.0.8/blue?icon=nuget)](https://www.nuget.org/packages/VijayAnand.MauiBlazor.Markup/3.0.8)|[![.NET 9](https://badgen.net/badge/nuget/v4.0.0/blue?icon=nuget)](https://www.nuget.org/packages/VijayAnand.MauiBlazor.Markup/4.0.0)|[![.NET 10](https://badgen.net/nuget/v/VijayAnand.MauiBlazor.Markup/?icon=nuget&foo=bar)](https://www.nuget.org/packages/VijayAnand.MauiBlazor.Markup/)|
<!--
|Preview|-|-|[![.NET 10](https://badgen.net/nuget/v/VijayAnand.MauiBlazor.Markup/latest?icon=nuget&foo=bar)](https://www.nuget.org/packages/VijayAnand.MauiBlazor.Markup/absoluteLatest)|
-->

The most useful method will be `Configure`, which can be invoked on an instance of a BlazorWebView and its derivatives, and it simplifies the initialization of BlazorWebView into a single fluent method call as shown in the below sample.

Note: `Gateway` is a `Razor` component and assumes it can receive a parameter named `Foo` as described in the sample underneath.

```cs
namespace MyApp;

public class HomePage : ContentPage
{
    public HomePage()
    {
        // A BlazorWebView can manage multiple RootComponents, to achieve this, define another Tuple with values of that component
        // The method and Tuple parameter names are shown for clarity and it's optional
        // Blazor component can have initialization parameters, which can be supplied through parameters, a dictionary of keyValues
        // where the key is of type string and value is of type object

        // Without initialization parameters
        Content = new BlazorWebView().Configure(hostPage: "wwwroot/index.html", (selector: "#app", componentType: typeof(Gateway), parameters: null));

        // With optional initialization parameters
        Content = new BlazorWebView().Configure(hostPage: "wwwroot/index.html", (selector: "#app", componentType: typeof(Gateway), parameters: new Dictionary<string, object?> { [nameof(Gateway.Foo)] = "Bar" }));

        // In a simplified form - Real intended usage
        // Without initialization parameters
        Content = new BlazorWebView().Configure("wwwroot/index.html", ("#app", typeof(Gateway), null));
        // Much more simplified, assuming hostPage is wwwroot/index.html and selector as #app
        Content = new BlazorWebView().Configure(typeof(Gateway));

        // With StartPath property introduced in .NET 8 or later, overloaded Configure method
        // Assuming search is the page with which the app is intended to start
        Content = new BlazorWebView().Configure("wwwroot/index.html", "/search", ("#app", typeof(Gateway), null));
        // Much more simplified version, assuming hostPage is wwwroot/index.html and selector as #app
        Content = new BlazorWebView().Configure(typeof(Gateway), "/search");

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
// where the key is of type string and the value is of type object
new BlazorWebView().Configure(hostPage: "wwwroot/index.html", (selector: "#app", componentType: typeof(Gateway), parameters: null))
// Another example with component initialization parameters
new BlazorWebView().Configure(hostPage: "wwwroot/index.html", (selector: "#app", componentType: typeof(Gateway), parameters: new Dictionary<string, object?> { ["Foo"] = "Bar" }))
```
-->
