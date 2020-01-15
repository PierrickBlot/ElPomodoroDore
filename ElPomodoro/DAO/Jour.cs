using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElPomodoro.DAO
{
    class Jour
    {
        public int id;
        public DateTime? date;
        public string intitule;


        public Jour() {}

        public void Insert()
        {
            InitBDD bdd = new InitBDD();
            var con = bdd.ConnectionBDD();
            con.Open();
            var cmd = new SQLiteCommand(con);
            this.intitule = "'" + this.intitule + "'";

            cmd.CommandText = "INSERT INTO jour(dateJour, intitule) VALUES(\'" + this.date+ "\',"+this.intitule+");";
            cmd.ExecuteNonQuery();

            con.Close();
        }
    }
}
