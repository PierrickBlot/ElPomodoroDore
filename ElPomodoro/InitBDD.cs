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
            SQLiteConnection con = new SQLiteConnection(@"Datasource=C:\Users\remig\Desktop\Cours\.Net\ElPomodoroDore\ElPomodoreDore.db");
            con.Open();

            var cmd = new SQLiteCommand(con);

            cmd.CommandText = "CREATE TABLE IF NOT EXISTS jour(idJour INTERGER PRIMARY KEY, jour DATE)";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "CREATE TABLE IF NOT EXISTS pomodoro(idPomodoro INTERGER PRIMARY KEY, motClef VARCHAR(50), idJour INTERGER)";
            cmd.ExecuteNonQuery();
        }

    }
}
