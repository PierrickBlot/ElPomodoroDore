using ElPomodoro.DAO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ElPomodoro.Pages
{
    /// <summary>
    /// Logique d'interaction pour RemplissageFragments.xaml
    /// </summary>
    public partial class RemplissageFragments : Page
    {
        //DateTime heureDebut = new DateTime(0, 0, 0, 8, 0, 0);
        DateTime oDate = DateTime.Parse("11:00");
        List<Pomodore> listF = new List<Pomodore>();
        List<Pomodore> listR = new List<Pomodore>();

        //public string heureDebut = "08:00";
        public RemplissageFragments(Jour jour)
        {
            var pause = 0;
            //DateTime heureMinutes = oDate.Hour + oDate.Minute;
            var dateAndTime = DateTime.Now;
            InitializeComponent();
            Label label = new Label();
            //var laDate = Convert.ToDateTime(jour.Date);
            var laDate = DateTime.ParseExact(jour.Date, "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy");
            label.Content = "Pomodoro du " + laDate;
            label.HorizontalAlignment = HorizontalAlignment.Center;
            label.VerticalAlignment = VerticalAlignment.Top;
            label.Width = 392;
            label.FontSize = 30;
            label.FontFamily = new FontFamily("Algerian");
            label.Foreground = Brushes.Brown;
            RootGrid.Children.Add(label);


            for (int i = 0; i < jour.Fragment; i++)
            {
                //var test = new DateTime(0, 0, 0, 12, 1, 0);
                //TestTime.AddMinutes(30);
                var minutes = i * 30 + pause * 60;
                if (oDate.AddMinutes(minutes).ToString("HH:mm") == "11:30")
                {
                    pause = 1;
                    //minutes = minutes + 30;
                }
                listF.Add(new Pomodore() { Numero = i + 1, MotClef = null, Heure = oDate.AddMinutes(minutes).ToString("HH:mm"), IdJour = jour.Id});
                DataGrid.ItemsSource = listF;
            }
        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in listF)
            {
                item.Insert();
            }
            Accueil rf = new Accueil();
            this.NavigationService.Navigate(rf);
            /*InitBDD bdd = new InitBDD();
            var con = bdd.ConnectionBDD();
            con.Open();
            var cmd = new SQLiteCommand(con);

            cmd.CommandText = "SELECT * FROM pomodoro WHERE idJour = 2";
            cmd.ExecuteNonQuery();
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("ID_POMODORO : "+reader.GetInt32(0)+" | MOT_CLEF : "+reader.GetString(1)+" | HEURE : "+reader.GetDateTime(2)+ " | ID_JOUR : "+reader.GetInt32(3));
            }*/
        }
    }
}
