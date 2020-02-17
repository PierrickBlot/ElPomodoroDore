using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElPomodoro.DAO
{
    public class Pomodore
    {
        public int Numero { get; set; }

        public int Id { get; set; }
        public string MotClef { get; set; }
        public string Heure { get; set; }
        public int IdJour { get; set; }

        public Pomodore() { }

        public void Insert()
        {
            InitBDD bdd = new InitBDD();
            var con = bdd.ConnectionBDD();
            con.Open();
            var cmd = new SQLiteCommand(con);
            //this.MotClef = "'" + this.MotClef + "'";
            //var test = "\'" + this.MotClef + "\'";
            cmd.CommandText = "INSERT INTO pomodoro(motClef, heure, idJour) VALUES(\'" + this.MotClef + "\',\'" + this.Heure + "\'," + IdJour + ")";
            cmd.ExecuteNonQuery();

            con.Close();
        }
    }
}