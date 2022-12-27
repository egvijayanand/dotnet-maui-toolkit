namespace VijayAnand.MauiToolkit.Core.ViewModels
{
    public interface IViewModel
    {
        /// <summary>
        /// Code that runs to initialize the ViewModel state.
        /// </summary>
        /// <param name="parameter">The optional value to help initialize the ViewModel state.</param>
        void Initialize(object? parameter = null);

        /// <summary>
        /// Code that runs to initialize the ViewModel state and runs async.
        /// </summary>
        /// <param name="parameter">The optional value to help initialize the ViewModel state.</param>
        /// <returns></returns>
        Task InitializeAsync(object? parameter = null);
    }
}
