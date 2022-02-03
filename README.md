### .NET MAUI Blazor Toolkit

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
