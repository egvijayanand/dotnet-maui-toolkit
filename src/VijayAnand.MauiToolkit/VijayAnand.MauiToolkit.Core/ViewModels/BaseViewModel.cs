using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace VijayAnand.MauiToolkit.Core.ViewModels;

public class BaseViewModel : INotifyPropertyChanging, INotifyPropertyChanged, IViewModel
{
    private bool async;
    private bool isBusy;
    private bool isNotBusy = true;
    private bool canLoadMore;
    private string? title = string.Empty;
    private string? subtitle = string.Empty;
    private string? icon = string.Empty;
    private string? header = string.Empty;
    private string? footer = string.Empty;
    private string? statusMessage = "Loading ...";

    public event PropertyChangingEventHandler? PropertyChanging;
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// Determines whether the View is getting initialized asynchronously or not.
    /// </summary>
    public bool Async
    {
        get => async;
        set => SetProperty(ref async, value);
    }

    /// <summary>
    /// Title of the View.
    /// </summary>
    public string? Title
    {
        get => title;
        set => SetProperty(ref title, value);
    }

    /// <summary>
    /// Subtitle of the View, if any.
    /// </summary>
    public string? Subtitle
    {
        get => subtitle;
        set => SetProperty(ref subtitle, value);
    }

    /// <summary>
    /// Icon of the View, if any.
    /// </summary>
    public string? Icon
    {
        get => icon;
        set => SetProperty(ref icon, value);
    }

    /// <summary>
    /// If <see langword="true"/>, the View is busy in processing an activity.
    /// </summary>
    public bool IsBusy
    {
        get => isBusy;
        set
        {
            if (SetProperty(ref isBusy, value))
            {
                IsNotBusy = !value;
            }
        }
    }

    /// <summary>
    /// Inverse value of <seealso cref="IsBusy" />
    /// </summary>
    public bool IsNotBusy
    {
        get => isNotBusy;
        set
        {
            if (SetProperty(ref isNotBusy, value))
            {
                IsBusy = !value;
            }
        }
    }

    /// <summary>
    /// Indicates that more data can be loaded into the View.
    /// </summary>
    public bool CanLoadMore
    {
        get => canLoadMore;
        set => SetProperty(ref canLoadMore, value);
    }

    /// <summary>
    /// Header of the View.
    /// </summary>
    public string? Header
    {
        get => header;
        set => SetProperty(ref header, value);
    }

    /// <summary>
    /// Footer of the View.
    /// </summary>
    public string? Footer
    {
        get => footer;
        set => SetProperty(ref footer, value);
    }

    /// <summary>
    /// The message user sees when the View is busy in processing an activity.
    /// </summary>
    public string? StatusMessage
    {
        get => statusMessage;
        set => SetProperty(ref statusMessage, value);
    }

    /// <summary>
    /// Code that runs to initialize the ViewModel state.
    /// </summary>
    /// <param name="parameter"></param>
    public virtual void Initialize(object? parameter = null) { }

    /// <summary>
    /// Code that runs to initialize the ViewModel state and runs async.
    /// </summary>
    /// <param name="parameter"></param>
    /// <returns></returns>
    public virtual Task InitializeAsync(object? parameter = null) => Task.CompletedTask;

    /// <summary>
    /// Sets the property and raises the notification.
    /// </summary>
    /// <typeparam name="T">Type parameter of the field &amp; property.</typeparam>
    /// <param name="backingField">Backing field.</param>
    /// <param name="value">Value.</param>
    /// <param name="propertyName">Property name.</param>
    /// <param name="onChanging">Code that runs before changing the property value.</param>
    /// <param name="onChanged">Code that runs after changing the property value.</param>
    /// <param name="validateValue">Code that validates the value.</param>
    /// <returns><c>true</c>, if property was set, <c>false</c> otherwise.</returns>
    protected virtual bool SetProperty<T>(ref T backingField,
                                          T value,
                                          [CallerMemberName] string? propertyName = null,
                                          Action? onChanging = null,
                                          Action? onChanged = null,
                                          Func<T, T, bool>? validateValue = null)
    {
        // If value didn't change
        if (EqualityComparer<T>.Default.Equals(backingField, value))
        {
            return false;
        }

        // If value changed but didn't validate
        if (validateValue != null && !validateValue(backingField, value))
        {
            return false;
        }

        onChanging?.Invoke();
        OnPropertyChanging(propertyName);
        backingField = value;
        onChanged?.Invoke();
        OnPropertyChanged(propertyName);
        return true;
    }

    protected virtual void OnPropertyChanging([CallerMemberName] string? propertyName = null)
        => PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
