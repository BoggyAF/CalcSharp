using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CalcSharp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        Utilities.Settings settings = new Utilities.Settings();

        public SettingsPage()
        {
            InitializeComponent();
            if (Utilities.Settings.SwitchState == "on")
            {
                settings.SetTheme(Utilities.Theme.Dark);
                nightmodeSwitch.IsToggled = true;
            }
            else
            {
                settings.SetTheme(Utilities.Theme.Light);
                nightmodeSwitch.IsToggled = false;
            }
        }

        private void NightmodeSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            if (nightmodeSwitch.IsToggled)
            {
                nightmodeLabel.Text = "Night mode: On";
                CalcSharp.Utilities.Settings.SwitchState = "on";
                System.Diagnostics.Debug.WriteLine(nightmodeSwitch.IsToggled);
                settings.SetTheme(Utilities.Theme.Dark);
            }
            else
            {
                nightmodeLabel.Text = "Night mode: Off";
                CalcSharp.Utilities.Settings.SwitchState = "off";
                System.Diagnostics.Debug.WriteLine(nightmodeSwitch.IsToggled);
                settings.SetTheme(Utilities.Theme.Light);
            }
        }


    }
}