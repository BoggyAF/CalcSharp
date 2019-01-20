using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CalcSharp.Data;
using Xamarin.Forms;
using CalcSharp.Droid.Data;

[assembly: Dependency(typeof(SQL_Android))]

namespace CalcSharp.Droid.Data
{
    public class SQL_Android : ISQL
    {
        public SQL_Android() { }
        public SQLite.SQLiteConnection GetConnection()
        {
            var sqlFileName = "Scoreboard.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = System.IO.Path.Combine(documentsPath, sqlFileName);
            var connection = new SQLite.SQLiteConnection(path);

            return connection;
        }
    }
}