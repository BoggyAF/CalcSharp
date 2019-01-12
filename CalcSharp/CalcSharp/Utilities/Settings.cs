// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using CalcSharp.Themes;

namespace CalcSharp.Utilities
{

    public enum Theme
    {
        Dark,
        Light
    }

    public class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        public void SetTheme(Theme theme)
        {
            Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
            {
                switch (theme)
                {
                    case Theme.Dark:
                        Xamarin.Forms.Application.Current.Resources.MergedWith = typeof(DarkTheme);
                        App.Current.Resources["ButtonBackgroundColor"] = App.Current.Resources["AccentBackgroundColor"];
                        break;
                    case Theme.Light:
                        Xamarin.Forms.Application.Current.Resources.MergedWith = typeof(LightTheme);
                        App.Current.Resources["ButtonBackgroundColor"] = App.Current.Resources["AccentBackgroundColor"];
                        break;
                    default:
                        break;
                }
            });
        }

        #region Setting Constants

        private const string SwitchStateKey = "switch_state_key";
        private static readonly string SettingsDefault = string.Empty;

        #endregion


        public static string SwitchState
        {
            get
            {
                return AppSettings.GetValueOrDefault(SwitchStateKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SwitchStateKey, value);
            }
        }

    }
}