namespace VijayAnand.MauiToolkit.Services;


/// <summary>
/// Platform-specific .NET MAUI dialog invocation for both <seealso cref="IMauiDialogService"/> and <seealso cref="IDialogService"/> methods.
/// </summary>
internal sealed class DialogService : IMauiDialogService, IDialogService
{
    public Task<string> DisplayActionSheetAsync(string title, string message, string cancel, string? destruction, string? defaultButton, params string[] buttons)

#if NET10_0_OR_GREATER
        => GetMainPage().DisplayActionSheetAsync(title, cancel, destruction, buttons);
#else
        => GetMainPage().DisplayActionSheet(title, cancel, destruction, buttons);
#endif

    public Task<string> DisplayActionSheetAsync(string title, string cancel, string destruction, FlowDirection flowDirection, params string[] buttons)
    {
        var mainPage = GetMainPage();

#if NET10_0_OR_GREATER
        if (mainPage is Shell)
        {
            return Shell.Current.DisplayActionSheetAsync(title, cancel, destruction, flowDirection, buttons);
        }
        else
        {
            return mainPage.DisplayActionSheetAsync(title, cancel, destruction, flowDirection, buttons);
        }
#else
        if (mainPage is Shell)
        {
            return Shell.Current.DisplayActionSheet(title, cancel, destruction, flowDirection, buttons);
        }
        else
        {
            return mainPage.DisplayActionSheet(title, cancel, destruction, flowDirection, buttons);
        }
#endif
    }

    public Task DisplayAlertAsync(string title, string message, string cancel)
#if NET10_0_OR_GREATER
        => GetMainPage().DisplayAlertAsync(title, message, cancel);
#else
        => GetMainPage().DisplayAlert(title, message, cancel);
#endif

    public Task<bool> DisplayAlertAsync(string title, string message, string accept, string cancel)
#if NET10_0_OR_GREATER
        => GetMainPage().DisplayAlertAsync(title, message, accept, cancel);
#else
        => GetMainPage().DisplayAlert(title, message, accept, cancel);
#endif

    public Task DisplayAlertAsync(string title, string message, string cancel, FlowDirection flowDirection)
#if NET10_0_OR_GREATER
        => GetMainPage().DisplayAlertAsync(title, message, cancel, flowDirection);
#else
        => GetMainPage().DisplayAlert(title, message, cancel, flowDirection);
#endif

    public Task<bool> DisplayAlertAsync(string title, string message, string accept, string cancel, FlowDirection flowDirection)
#if NET10_0_OR_GREATER
        => GetMainPage().DisplayAlertAsync(title, message, accept, cancel, flowDirection);
#else
        => GetMainPage().DisplayAlert(title, message, accept, cancel, flowDirection);
#endif

    public Task<string> DisplayPromptAsync(string title, string message, FlowDirection flowDirection, string accept = "OK", string cancel = "Cancel", string? placeholder = null, int maxLength = -1, Keyboard? keyboard = null, string initialValue = "", Func<string, (bool, string)>? predicate = null)
        => GetMainPage().DisplayPromptAsync(title, message, accept, cancel, placeholder, maxLength, keyboard, initialValue);

    public Task<string> DisplayPromptAsync(string title, string message, string accept = "OK", string cancel = "Cancel", string? placeholder = null, int maxLength = -1, InputType inputType = InputType.Default, string initialValue = "", Func<string, (bool, string)>? predicate = null)
        => DisplayPromptAsync(title, message, FlowDirection.MatchParent, accept, cancel, placeholder, maxLength, GetKeyboard(inputType), initialValue, predicate);

    private static Keyboard GetKeyboard(InputType inputType)
        => inputType switch
        {
            InputType.Plain => Keyboard.Plain,
            InputType.Chat => Keyboard.Chat,
            InputType.Decimal => Keyboard.Numeric,
            InputType.Email => Keyboard.Email,
            InputType.Numeric => Keyboard.Numeric,
            InputType.Telephone => Keyboard.Telephone,
            InputType.Text => Keyboard.Text,
            InputType.Url => Keyboard.Url,
            _ => Keyboard.Default
        };

    private static Page GetMainPage()
    {
#if NET9_0_OR_GREATER
        var mainPage = (Application.Current?.Windows?[0]?.Page) ?? throw new InvalidOperationException("Application.Current.Windows[0].Page cannot be null.");
#else
        var mainPage = (Application.Current?.MainPage) ?? throw new InvalidOperationException("Application.Current.MainPage cannot be null.");
#endif
        return mainPage is Shell ? Shell.Current : mainPage;
    }
}
