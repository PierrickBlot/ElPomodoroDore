using System;
using System.Collections.Generic;
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
            RemplissageFragments rf = new RemplissageFragments();
            this.Content = rf;
        }
    }
}
