namespace VijayAnand.MauiToolkit.Services
{
    public class DialogService : IMauiDialogService, IDialogService
    {
        public Task<string> DisplayActionSheetAsync(string title, string message, string cancel, string? destruction, string? defaultButton, params string[] buttons)
        {
            if (Application.Current is null)
            {
                throw new InvalidOperationException("Application.Current cannot be null");
            }
            else if (Application.Current.MainPage is null)
            {
                throw new InvalidOperationException("Application.Current.MainPage cannot be null");
            }

            if (Application.Current.MainPage is Shell)
            {
                return Shell.Current.DisplayActionSheet(title, cancel, destruction, buttons);
            }
            else
            {
                return Application.Current.MainPage.DisplayActionSheet(title, cancel, destruction, buttons);
            }
        }

        public Task<string> DisplayActionSheetAsync(string title, string cancel, string destruction, FlowDirection flowDirection, params string[] buttons)
        {
            if (Application.Current is null)
            {
                throw new InvalidOperationException("Application.Current cannot be null");
            }
            else if (Application.Current.MainPage is null)
            {
                throw new InvalidOperationException("Application.Current.MainPage cannot be null");
            }

            if (Application.Current.MainPage is Shell)
            {
                return Shell.Current.DisplayActionSheet(title, cancel, destruction, flowDirection, buttons);
            }
            else
            {
                return Application.Current.MainPage.DisplayActionSheet(title, cancel, destruction, flowDirection, buttons);
            }
        }

        public Task DisplayAlertAsync(string title, string message, string cancel)
        {
            if (Application.Current is null)
            {
                throw new InvalidOperationException("Application.Current cannot be null");
            }
            else if (Application.Current.MainPage is null)
            {
                throw new InvalidOperationException("Application.Current.MainPage cannot be null");
            }

            if (Application.Current.MainPage is Shell)
            {
                return Shell.Current.DisplayAlert(title, message, cancel);
            }
            else
            {
                return Application.Current.MainPage.DisplayAlert(title, message, cancel);
            }
        }

        public Task<bool> DisplayAlertAsync(string title, string message, string accept, string cancel)
        {
            if (Application.Current is null)
            {
                throw new InvalidOperationException("Application.Current cannot be null");
            }
            else if (Application.Current.MainPage is null)
            {
                throw new InvalidOperationException("Application.Current.MainPage cannot be null");
            }

            if (Application.Current.MainPage is Shell)
            {
                return Shell.Current.DisplayAlert(title, message, accept, cancel);
            }
            else
            {
                return Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);
            }
        }

        public Task DisplayAlertAsync(string title, string message, string cancel, FlowDirection flowDirection)
        {
            if (Application.Current is null)
            {
                throw new InvalidOperationException("Application.Current cannot be null");
            }
            else if (Application.Current.MainPage is null)
            {
                throw new InvalidOperationException("Application.Current.MainPage cannot be null");
            }

            if (Application.Current.MainPage is Shell)
            {
                return Shell.Current.DisplayAlert(title, message, cancel, flowDirection);
            }
            else
            {
                return Application.Current.MainPage.DisplayAlert(title, message, cancel, flowDirection);
            }
        }

        public Task<bool> DisplayAlertAsync(string title, string message, string accept, string cancel, FlowDirection flowDirection)
        {
            if (Application.Current is null)
            {
                throw new InvalidOperationException("Application.Current cannot be null");
            }
            else if (Application.Current.MainPage is null)
            {
                throw new InvalidOperationException("Application.Current.MainPage cannot be null");
            }

            if (Application.Current.MainPage is Shell)
            {
                return Shell.Current.DisplayAlert(title, message, accept, cancel, flowDirection);
            }
            else
            {
                return Application.Current.MainPage.DisplayAlert(title, message, accept, cancel, flowDirection);
            }
        }

        public Task<string> DisplayPromptAsync(string title, string message, string accept = "OK", string cancel = "Cancel", string? placeholder = null, int maxLength = -1, Keyboard? keyboard = null, string initialValue = "")
        {
            if (Application.Current is null)
            {
                throw new InvalidOperationException("Application.Current cannot be null");
            }
            else if (Application.Current.MainPage is null)
            {
                throw new InvalidOperationException("Application.Current.MainPage cannot be null");
            }

            if (Application.Current.MainPage is Shell)
            {
                return Shell.Current.DisplayPromptAsync(title, message, accept, cancel, placeholder, maxLength, keyboard, initialValue);
            }
            else
            {
                return Application.Current.MainPage.DisplayPromptAsync(title, message, accept, cancel, placeholder, maxLength, keyboard, initialValue);
            }
        }

        public Task<string> DisplayPromptAsync(string title, string message, string accept = "OK", string cancel = "Cancel", string? placeholder = null, int maxLength = -1, InputType inputType = InputType.Default, string initialValue = "")
        {
            var keyboard = inputType switch
            {
                InputType.Plain => Keyboard.Plain,
                InputType.Chat => Keyboard.Chat,
                InputType.Decimal => Keyboard.Numeric,
                InputType.Default => Keyboard.Default,
                InputType.Email => Keyboard.Email,
                InputType.Numeric => Keyboard.Numeric,
                InputType.Telephone => Keyboard.Telephone,
                InputType.Text => Keyboard.Text,
                InputType.Url => Keyboard.Url,
                _ => Keyboard.Default
            };

            return DisplayPromptAsync(title, message, accept, cancel, placeholder, maxLength, keyboard, initialValue);
        }
    }
}
