using ElPomodoro.DAO;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
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
    /// Logique d'interaction pour Accueil.xaml
    /// </summary>
    public partial class Accueil : Page
    {
        private DependencyProperty dp;

        public Accueil()
        {
            InitializeComponent();
            InitBDD bdd = new InitBDD();
            var con = bdd.ConnectionBDD();
            con.Open();
            var cmd = new SQLiteCommand(con);

            cmd.CommandText = "SELECT * FROM jour"; 
            cmd.ExecuteNonQuery();
            SQLiteDataReader reader = cmd.ExecuteReader();

            List<Jour> listJ = new List<Jour>();
            /*Button b = new Button();
            DataGridTextColumn col = new DataGridTextColumn();
            col.Header = "Voir";
            DataGrid.Columns.Add(col);*/

            while (reader.Read())
            {
                //DataGrid.Items.Add();
                listJ.Add(new Jour() { Id = reader.GetInt32(0), Date = reader.GetString(1), Intitule = reader.GetString(2), Fragment = reader.GetInt32(3) });
                DataGrid.ItemsSource = listJ;
                /*var idThis = reader.GetInt32(0);
                var dateThis = reader.GetString(1);
                var intituleThis = reader.GetString(1);*/
                //Jour j = new Jour();
                //top = top + 10;
                /*left = left + 10;
                j.id = reader.GetInt32(0);
                j.date = reader.GetString(1);
                j.intitule = reader.GetString(2);
                TextBlock tb = new TextBlock();
                Thickness marginThickness = tb.Margin;
                marginThickness.Left = left;
                tb.Height = 20;
                tb.Width = 50;
                tb.Text = j.intitule.ToString();
                RootGrid.Children.Add(tb);*/
            }
        }

        private void NouveauPomodoro(object sender, RoutedEventArgs e)
        {
            AjoutPomodoro ap = new AjoutPomodoro();
            this.NavigationService.Navigate(ap);
        }

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedItem = DataGrid.SelectedItem as Jour;
            Console.WriteLine(selectedItem);
            JouerJour jj = new JouerJour(selectedItem);
            this.NavigationService.Navigate(jj);
        }
    }
}
