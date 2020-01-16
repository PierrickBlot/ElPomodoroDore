using ElPomodoro.DAO;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Logique d'interaction pour AjoutPomodoro.xaml
    /// </summary>
    public partial class AjoutPomodoro : Page
    {
        public AjoutPomodoro()
        {
            InitializeComponent();
            nbFragments.Text = "0";
        }

        private void TextBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (unIntitule.Text == "Intitulé")
            {
                unIntitule.Text = "";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int value = int.Parse(nbFragments.Text);
            if (value < 20)
            {
                value++;
            }
            else
            {
                phraseNbFragments.Visibility = Visibility.Visible;
            }
            nbFragments.Text = value.ToString();
            //= Int32.Parse(nbFragments.Text) + 1
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int value = int.Parse(nbFragments.Text);
            if (value > 0)
            {
                if (phraseNbFragments.Visibility == Visibility.Visible)
                {
                    phraseNbFragments.Visibility = Visibility.Hidden;
                }
                value--;
            }
            nbFragments.Text = value.ToString();
        }

        private void Validation(object sender, RoutedEventArgs e)
        {
           

            Jour j = new Jour();
            //DateTime UpdatedTime = laDate.SelectedDate ?? j.date;
            //this.date = DateTime.Parse(this.date.ToString("YYYY/MM/DD"));
            //var uneDate = laDate.SelectedDate.ToString();
            //DateTime convertDate = Convert.ToDateTime(uneDate);

            if (unIntitule.Text == "" || laDate.Text == "" || nbFragments.Text == "0" || unIntitule.Text == "Intitulé")
            {
                PhraseValidation.Visibility = Visibility.Visible;
            }
            else {
                PhraseValidation.Visibility = Visibility.Hidden;
                InitBDD bdd = new InitBDD();
                var con = bdd.ConnectionBDD();
                j.Date = laDate.SelectedDate.ToString(); //convertDate
                j.Intitule = unIntitule.Text;
                j.Fragment = Int32.Parse(nbFragments.Text);
                j.Insert();

                RemplissageFragments rf = new RemplissageFragments(j);
                this.NavigationService.Navigate(rf);
            }
            
        }
    }
}
