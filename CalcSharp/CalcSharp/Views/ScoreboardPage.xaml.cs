using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalcSharp.Data;
using CalcSharp.Utilities;
using Xamarin.Forms;

using Xamarin.Forms.Xaml;

namespace CalcSharp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ScoreboardPage : ContentPage
	{
        ScoreboardDataAccess scoreboardDataAccess = new ScoreboardDataAccess();
        public ScoreboardPage ()
		{
            Xamarin.Forms.DataGrid.DataGridComponent.Init();

            InitializeComponent ();
            this.Title = "Scores";

            var database = Xamarin.Forms.DependencyService.Get<ISQL>().GetConnection();
            listView.ItemsSource = database.Table<Scoreboard>().OrderBy(x=>x.Score).ToList();



            stackLayout.Children.Add(listView);

            Content = stackLayout;
        }
	}
}