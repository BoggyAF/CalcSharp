using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CalcSharp.Views
{
    public partial class MainPage : ContentPage
    {
        SettingsPage settings = new SettingsPage();
        public MainPage()
        {
            InitializeComponent();
        }

        private void NrPrimButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NrPrimPage());
            
        }

        private void QuizButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new QuizPage());
        }

        private void ScoreboardButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ScoreboardPage());
        }

        private void SettingsButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SettingsPage());
            
        }
    }
}
