using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CalcSharp.Utilities
{
    [Table("Scores")]
    public class Scoreboard
    {
        private int _id;
        [PrimaryKey, AutoIncrement]

        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                this._id = value;
            }
        }

        private int _score;
        [NotNull]

        public int Score
        {
            get
            {
                return _score;
            }

            set
            {
                this._score = value;
            }
        }

        private DateTime _date;
        [NotNull]

        public DateTime Date
        {
            get
            {
                return _date;
            }

            set
            {
                this._date = value;
            }
        }

        public Scoreboard() { }
        public Scoreboard(int Score, DateTime Date)
        {
            this.Score = Score;
            this.Date = Date;
        }

        public override string ToString()
        {
            return $"{this.Id} {this.Score*10}% {this.Date}";
        }

    }
}
