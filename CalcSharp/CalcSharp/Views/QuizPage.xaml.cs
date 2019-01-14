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
    public partial class QuizPage : ContentPage
    {
        private string number;
        private int wrongScore;
        private int rightScore;
        private int operatorIndex;
        private int randomNumber1;
        private int randomNumber2;
        private string operatorString;
        private int result;
        private int questionNumber = 1;
        private int count = 16;
        private bool stop;

        Random generator = new Random();
        public QuizPage()
        {
            InitializeComponent();

            ToolbarItems.Add(new ToolbarItem("Reset", null, () =>
            {
                Reset();
            }));

            operatorIndex = generator.Next(1, 4);
            UpdateNumbers();
            UpdateText();
            TimerStart();
        }

        private void TimerStart()
        {
            stop = false;
            count = 16;

            Xamarin.Forms.Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                if (stop)
                {
                    return false;
                }
                else
                {
                    if (count == 0)
                    {
                        Calculate();
                        count = 16;
                    }
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        count = count - 1;
                        TimeSpan _TimeSpan = TimeSpan.FromSeconds(count);
                        timeLabel.Text = $"Time: {count}";
                        if (questionNumber >= 11 || rightScore + wrongScore == 10)
                        {
                            Results();

                            return;
                        }
                    });
                    return true;
                }
            });
        }

        private void TimerStop()
        {
            stop = true;
        }

        public void Button_Click(View view, EventArgs e)
        {
            Button button = (Button)view;
            if ("0123456789".Contains(button.Text))
                AddDigit(button.Text);
            else if ("Calculate" == button.Text)
                Calculate();
            else
                DeleteDigit();
        }

        private void AddDigit(string value)
        {
            if (number == "0")
            {
                number = null;
                UpdateText();
                return;
            }

            number += value;
            UpdateText();
        }

        private void DeleteDigit()
        {
            if (number == null)
                return;

            number = number.Remove(number.Length - 1);
        }

        private void Calculate()
        {
            if (number == null)
            {
                wrongScore += 1;
                questionNumber += 1;
                UpdateNumbers();
                UpdateText();
                return;
            }

            if (int.TryParse(number, out int aux))
            {

            }
            else
            {

                number = null;
                wrongScore += 1;
                questionNumber += 1;
                UpdateNumbers();
                UpdateText();
                return;
            }

            switch (operatorIndex)
            {
                case 1:
                    operatorString = "+";
                    result = randomNumber1 + randomNumber2;
                    UpdateText();
                    break;
                case 2:
                    operatorString = "*";
                    result = randomNumber1 * randomNumber2;
                    UpdateText();
                    break;
                case 3:
                    operatorString = "/";
                    result = randomNumber1 / randomNumber2;
                    UpdateText();
                    break;
                case 4:
                    operatorString = "-";
                    result = randomNumber1 - randomNumber2;
                    UpdateText();
                    break;
            }

            if (aux == result)
            {
                rightScore += 1;
            }
            else
            {
                wrongScore += 1;
            }

            questionNumber += 1;

            if (questionNumber >= 11 || rightScore + wrongScore == 10)
            {
                Results();

                return;
            }

            number = null;
            count = 16;
            UpdateNumbers();
            UpdateText();
        }

        private void Results()
        {
            TimerStop();
            equationLabel.Text = $"Results: {10 * rightScore}%";
            timeLabel.Text = null;
            questionNumberLabel.Text = null;
            wrongLabel.Text = null;
            rightLabel.Text = null;
            DisableButtons(true);
        }

        private void DisableButtons(bool isDisabled)
        {
            ButtonDelete.IsEnabled = !isDisabled;
            ButtonCalculate.IsEnabled = !isDisabled;
            Button0.IsEnabled = !isDisabled;
            Button1.IsEnabled = !isDisabled;
            Button2.IsEnabled = !isDisabled;
            Button3.IsEnabled = !isDisabled;
            Button4.IsEnabled = !isDisabled;
            Button5.IsEnabled = !isDisabled;
            Button6.IsEnabled = !isDisabled;
            Button7.IsEnabled = !isDisabled;
            Button8.IsEnabled = !isDisabled;
            Button9.IsEnabled = !isDisabled;
        }

        private void UpdateNumbers()
        {
            operatorIndex = generator.Next(1, 4);

            switch (operatorIndex)
            {
                case 1:
                    operatorString = "+";
                    randomNumber1 = generator.Next(0, 20);
                    randomNumber2 = generator.Next(0, 20);
                    break;
                case 2:
                    operatorString = "*";
                    randomNumber1 = generator.Next(0, 20);
                    randomNumber2 = generator.Next(0, 20);
                    break;
                case 3:
                    operatorString = "/";
                    randomNumber2 = generator.Next(1, 20);
                    result = generator.Next(1, 10);
                    randomNumber1 = result * randomNumber2;
                    break;
                case 4:
                    operatorString = "-";
                    randomNumber2 = generator.Next(0, 20);
                    result = generator.Next(0, 20);
                    randomNumber1 = result + randomNumber2;
                    break;
            }
        }

        private void Reset()
        {
            if (!stop)
            {
                count = 16;
            }
            else
            {
                TimerStop();
            }
            DisableButtons(false);            
            number = null;
            UpdateNumbers();
            questionNumber = 1;
            wrongScore = 0;
            rightScore = 0;
            UpdateText();
        }

        public void UpdateText()
        {
            equationLabel.Text = $"{randomNumber1} {operatorString} {randomNumber2} = {number}";
            questionNumberLabel.Text = $"Question: {questionNumber}/10";
            wrongLabel.Text = $"Wrong: {wrongScore}";
            rightLabel.Text = $"Right: {rightScore}";
        }
    }
}