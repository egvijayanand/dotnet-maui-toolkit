### .NET MAUI Blazor Toolkit

This toolkit a set of fluent helper methods and classes to simplify working with .NET MAUI Blazor in C#.

This toolkit depends on [Microsoft.AspNetCore.Components.WebView.Maui](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebView.Maui) NuGet package.

Most useful method will be `Configure`, which can be invoked on an instance of a BlazorWebView and its derivatives, and it simplifies the initialization of BlazorWebView into a single fluent method call as shown in the below sample.

Note: Gateway is a Razor component.

```CS
// For brevity, only the necessary code is made available. This can be nested anywhere a View can be defined
// The parameter names are shown for clarity and it's optional
// A BlazorWebView can manage multiple RootComponents, to achieve this, add another Tuple with parameter values of that component.
new BlazorWebView().Configure(hostPage: "wwwroot/index.html", (selector: "#app", componentType: typeof(Gateway), parameters: null))
```