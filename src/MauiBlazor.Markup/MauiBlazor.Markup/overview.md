### .NET MAUI Blazor Toolkit

This [markup](https://www.nuget.org/packages/VijayAnand.MauiBlazor.Markup/) package is a set of fluent helper methods and classes to simplify working with .NET MAUI Blazor in C#.

It depends on the [Microsoft.AspNetCore.Components.WebView.Maui](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebView.Maui) NuGet package.

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
