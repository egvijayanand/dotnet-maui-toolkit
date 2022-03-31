namespace VijayAnand.MauiToolkit.Services
{
    public class ThemeService : IThemeService
    {
        private readonly IPreferences preferences;

        public ThemeService(IPreferences preferences)
        {
            this.preferences = preferences;
        }

        public int Theme => preferences.Get(nameof(Theme), 0, null);

        public void SetTheme()
        {
            if (Application.Current is not null)
            {
                Application.Current.UserAppTheme = Theme switch
                {
                    1 => AppTheme.Light,
                    2 => AppTheme.Dark,
                    _ => AppTheme.Unspecified
                };
            }
        }
    }
}
