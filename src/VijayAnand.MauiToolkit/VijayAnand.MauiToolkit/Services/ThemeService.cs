namespace VijayAnand.MauiToolkit.Services;

public class ThemeService(IPreferences preferences) : IThemeService
{
    public int Theme => preferences.Get(nameof(Theme), (int)AppTheme.Unspecified, null);

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
