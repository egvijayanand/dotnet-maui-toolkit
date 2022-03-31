### VijayAnand.MauiToolkit.Core

This is a toolkit with a set of abstractions to simplify working with .NET MAUI and Blazor.

It's built on top of .NET 6 and published as a NuGet package - [VijayAnand.MauiToolkit.Core](https://www.nuget.org/packages/VijayAnand.MauiToolkit.Core/).

The objective is to ease the development of the `Razor Class Library` (RCL) so that it can be shared with all Blazor targets (.NET MAUI, Server, WebAssembly, Windows Forms, and WPF).

And .NET MAUI targets Android, iOS, macOS (via Mac Catalyst), and Windows (via WinUI 3).

To start with defines the following abstractions:

* Dialogs - `IDialogService`
* Navigation - `INavigationService`
* Share - `IShareService`
* Theme - `IThemeService`

A Model class for UserToken and frequently used Constants for OAuth / OIDC authentication.
