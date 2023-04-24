namespace VijayAnand.MauiToolkit.Core.ViewModels
{
	public interface IViewModel
	{
		/// <summary>
		/// If <see langword="true"/>, implies the View is getting initialized asynchronously.
		/// </summary>
		bool Async { get; set; }

		/// <summary>
		/// If <see langword="true"/>, the View is busy in processing an activity.
		/// </summary>
		bool IsBusy { get; set; }

		/// <summary>
		/// The message user sees when the View is busy in processing an activity.
		/// </summary>
		string? StatusMessage { get; set; }

		/// <summary>
		/// Title of the View.
		/// </summary>
		string? Title { get; set; }

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
