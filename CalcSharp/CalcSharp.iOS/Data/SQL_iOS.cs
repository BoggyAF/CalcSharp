using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using CalcSharp.Data;
using CalcSharp.iOS.Data;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQL_iOS))] 

namespace CalcSharp.iOS.Data
{
    public class SQL_iOS : ISQL
    {
        public SQL_iOS() { }
        public SQLite.SQLiteConnection GetConnection()
        {
            var sqlFileName = "Scoreboard.db3";
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var libraryPath = System.IO.Path.Combine(documentsPath, "..", "Library");
            var path = System.IO.Path.Combine(libraryPath, sqlFileName);
            var connection = new SQLite.SQLiteConnection(path);

            return connection;
        }
    }
}