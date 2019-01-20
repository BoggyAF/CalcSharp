using System;
using SQLite;
using System.Collections.Generic;
using System.Text;
using CalcSharp.Utilities;
using System.Linq;

namespace CalcSharp.Data
{
    public class ScoreboardDataAccess
    {
        private SQLite.SQLiteConnection database;
        private static readonly object collisionLock = new object();

        //public System.Collections.ObjectModel.ObservableCollection<Scoreboard> Scores { get; set; } //Represents a dynamic data collection that provides notifications when items get added, removed, or when the whole list is refreshed.

        public ScoreboardDataAccess()
        {
            database = Xamarin.Forms.DependencyService.Get<ISQL>().GetConnection();
            database.CreateTable<Scoreboard>();

            //this.Scores = new System.Collections.ObjectModel.ObservableCollection<Scoreboard>(database.Table<Scoreboard>());

        }

        public Scoreboard GetScoreboard()
        {
            lock (collisionLock)
            {
                if (database.Table<Scoreboard>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Table<Scoreboard>().First();
                }
            }
        }

        public int SaveScore(Scoreboard scoreInstance)
        {
            lock(collisionLock)
            {
                if (scoreInstance.Id != 0)
                {
                    database.Update(scoreInstance);
                    return scoreInstance.Id;
                }
                else
                {
                    database.Insert(scoreInstance);
                    return scoreInstance.Id;
                }
            }
        }

        public int DeleteScore(Scoreboard scoreInstance)
        {
            if (scoreInstance.Id != 0)
            {
                lock (collisionLock)
                {
                    database.Delete<Scoreboard>(scoreInstance.Id);
                }
            }
            //this.Scores.Remove(scoreInstance);
            return scoreInstance.Id;
        }

        public void SaveAllScores()
        {
            lock (collisionLock)
            {
                foreach (var scoreInstance in database.Table<Scoreboard>())
                {
                    if (scoreInstance.Id != 0)
                    {
                        database.Update(scoreInstance);
                    }
                    else
                    {
                        database.Insert(scoreInstance);
                    }
                }
            }
        }

        public void DeleteAllScores()
        {
            lock (collisionLock)
            {
                database.DropTable<Scoreboard>();
                database.CreateTable<Scoreboard>();
            }
        }



    }
}
