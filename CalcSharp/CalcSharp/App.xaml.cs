using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CalcSharp.Data;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CalcSharp
{
    public partial class App : Application
    {
        Views.SettingsPage settingsPage = new Views.SettingsPage();
        Utilities.Settings settings = new Utilities.Settings();
        static ScoreboardDataAccess scoreboardDataAccess;
        public App()
        {
            InitializeComponent();         

            MainPage = new NavigationPage(new Views.MainPage())
            {
                
        };
            NavigationPage.SetHasNavigationBar(MainPage, false);
        }

        protected override void OnStart()
        {
            if (Utilities.Settings.SwitchState == "on")
            {
                settings.SetTheme(Utilities.Theme.Dark);
                
            }
            else
            {
                settings.SetTheme(Utilities.Theme.Light);
            }
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public static ScoreboardDataAccess ScoreboardDataAccess
        {
            get
            {
                if (scoreboardDataAccess == null)
                {
                    scoreboardDataAccess = new ScoreboardDataAccess();
                }
                return scoreboardDataAccess;
            }
        }
    }
}
