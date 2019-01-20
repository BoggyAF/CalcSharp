using System;
using System.Collections.Generic;
using System.Text;

namespace CalcSharp.Data
{
    public interface ISQL
    {
        SQLite.SQLiteConnection GetConnection();
    }
}
