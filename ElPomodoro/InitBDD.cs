using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite.EF6;
using System.Data.SQLite;

namespace ElPomodoro
{
    class InitBDD
    {
        public InitBDD()
        {
            //string cs = @"URI=C:\Users\remig\Desktop\Cours\.Net\ElPomodoroDore\ElPomodoreDore.db";
            var con = ConnectionBDD();
            con.Open();
            var cmd = new SQLiteCommand(con);

            cmd.CommandText = "CREATE TABLE IF NOT EXISTS jour(idJour INTEGER PRIMARY KEY AUTOINCREMENT, dateJour DATE, intitule VARCHAR(50))";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "CREATE TABLE IF NOT EXISTS pomodoro(idPomodoro INTEGER PRIMARY KEY AUTOINCREMENT, motClef VARCHAR(50), idJour INTERGER)";
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public SQLiteConnection ConnectionBDD()
        {
            SQLiteConnection con = new SQLiteConnection(@"Datasource=C:\Users\remig\Desktop\Cours\.Net\ElPomodoroDore\ElPomodoreDore.db");
            return con;
        }

    }
}
