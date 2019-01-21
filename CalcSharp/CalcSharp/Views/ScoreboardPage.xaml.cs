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
            var database = Xamarin.Forms.DependencyService.Get<ISQL>().GetConnection();

            BindingContext = database.Table<Scoreboard>().ToList();
            InitializeComponent ();

            ToolbarItems.Add(new ToolbarItem("Reset", null, () =>
            {
                Reset();
            }));
        }

        private void Reset()
        {
            var database = Xamarin.Forms.DependencyService.Get<ISQL>().GetConnection();
            scoreboardDataAccess.DeleteAllScores();
            BindingContext = null;
            BindingContext = database.Table<Scoreboard>().ToList();
        }
    }
}