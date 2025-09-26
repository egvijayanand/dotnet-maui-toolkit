namespace VijayAnand.MauiToolkit;

/// <summary>
/// Auto Wire ViewModel for a .NET MAUI page.
/// </summary>
public static class ViewModelLocator
{
    public static readonly BindableProperty AutoWireViewModelProperty =
        BindableProperty.CreateAttached(
            nameof(AutoWireViewModelProperty),
            typeof(bool),
            typeof(ViewModelLocator),
            default(bool),
            propertyChanged: OnAutoWireViewModelChanged);

    public static bool GetAutoWireViewModel(BindableObject bindable)
        => (bool)bindable.GetValue(AutoWireViewModelProperty);

    public static void SetAutoWireViewModel(BindableObject bindable, bool value)
        => bindable.SetValue(AutoWireViewModelProperty, value);

    private static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is not BasePage page)
        {
            return;
        }

        var viewType = page.GetType();
        var viewName = viewType.FullName;
        var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;

        var viewModelName = viewName?.Replace(".Views.", ".ViewModels.")?.Replace("Page", "ViewModel");
        var viewModelTypeName = string.Format(CultureInfo.InvariantCulture, $"{viewModelName}, {viewAssemblyName}");
        var viewModelType = Type.GetType(viewModelTypeName);

        if (viewModelType is null)
        {
            return;
        }

        page.ViewModel = AppService.GetService(viewModelType) as BaseViewModel;
        page.BindingContext = page.ViewModel;
    }
}
