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
    public partial class NrPrimPage : ContentPage
    {
        private string number;
        SettingsPage settings = new SettingsPage();
        public NrPrimPage()
        {
            InitializeComponent();
 
            ButtonsColorChange(2);
            
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            App.Current.Resources["BackgroundColor"] = App.Current.Resources["DefaultBackgroundColor"];
            App.Current.Resources["ButtonBackgroundColor"] = App.Current.Resources["AccentBackgroundColor"];
        }

        public void ButtonsColorChange(int input)
        {
            switch (input)
            {
                case 1:
                      App.Current.Resources["ButtonBackgroundColor"] = App.Current.Resources["GreenButtonBackgroundColor"];
                      App.Current.Resources["ButtonTextColor"] = App.Current.Resources["TextColorWhite"];
                      break;
                case 0:
                      App.Current.Resources["ButtonBackgroundColor"] = App.Current.Resources["RedButtonBackgroundColor"];
                      App.Current.Resources["ButtonTextColor"] = App.Current.Resources["TextColorWhite"];
                      break;
                case 2:
                      App.Current.Resources["ButtonBackgroundColor"] = App.Current.Resources["AccentBackgroundColor"];
                      App.Current.Resources["ButtonTextColor"] = App.Current.Resources["TextColor"];
                      break;
            }
        }

        public void Button_Click(View view, EventArgs e)
        {
            Button button = (Button)view;
            if ("0123456789".Contains(button.Text))
                AddDigit(button.Text);
            else if ("Calculate" == button.Text)
                Calculate();
            else
                Reset();
        }

        private void AddDigit(string value)
        {
            if (number == "0")
            {
                number = null;
                calculatorLabel.Text = "0";
                resultLabel.Text = "Va rugam introduceti un numar valid.";
                UpdateCalculator();
                return;
            }

            number += value;

            UpdateCalculator();
        }

        private void Calculate()
        {
            if (number == "0")
            {
                number = null;
                calculatorLabel.Text = "0";
                resultLabel.Text = "Va sa rugam introduceti un numar valid.";
                UpdateCalculator();
                return;
            }

            if (int.TryParse(number, out int prim))
            {

            }
            else
            {

                resultLabel.Text = "Va rugam sa introduceti un numar valid.";
                calculatorLabel.Text = "0";
                UpdateCalculator();
                return;
            }

            if (IsPrime(prim))
            {
                App.Current.Resources["BackgroundColor"] = App.Current.Resources["GreenBackgroundColor"];
                ButtonsColorChange(1);
                resultLabel.Text = "Numarul este prim!";
            }
            else
            {
                App.Current.Resources["BackgroundColor"] = App.Current.Resources["RedBackgroundColor"];
                ButtonsColorChange(0);
                resultLabel.Text = "Numarul nu este prim!";
            }
        }

        public static bool IsPrime(int nr)
        {
            if (nr <= 1) return false;
            if (nr == 2) return true;
            if (nr % 2 == 0) return false;

            for (int i = 3; i <= nr / 2; i += 1)
                if (nr % i == 0)
                    return false;

            return true;
        }

        private void Reset()
        {
            number = null;
            resultLabel.Text = "";
            UpdateCalculator();
            ButtonsColorChange(2);
            App.Current.Resources["BackgroundColor"] = App.Current.Resources["DefaultBackgroundColor"];
            App.Current.Resources["ButtonBackgroundColor"] = App.Current.Resources["AccentBackgroundColor"];
        }

        private void UpdateCalculator()
        {
            calculatorLabel.Text = number;
            //System.Diagnostics.Debug.WriteLine(number);
        }
    }
}