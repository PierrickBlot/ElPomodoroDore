using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElPomodoro.DAO
{
    public class Jour
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Intitule { get; set; }
        public int Fragment { get; set; }

        public Jour() {}

        public void Insert()
        {
            InitBDD bdd = new InitBDD();
            var con = bdd.ConnectionBDD();
            con.Open();
            var cmd = new SQLiteCommand(con);
            this.Intitule = "'" + this.Intitule + "'";

            cmd.CommandText = "INSERT INTO jour(dateJour, intitule, fragment) VALUES(\'" + this.Date+ "\',"+this.Intitule+","+Fragment+");";
            cmd.ExecuteNonQuery();
            long oui = con.LastInsertRowId;
            Id = Convert.ToInt32(oui);
            con.Close();
        }
    }
}
