using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Threading;

namespace ElPomodoro.Pages
{
    /// <summary>
    /// Logique d'interaction pour JouerJouer.xaml
    /// </summary>
    public partial class JouerJour : Page
    {
        DispatcherTimer dt = new DispatcherTimer();
        Stopwatch sw = new Stopwatch();
        TimeSpan currentTime;

        public JouerJour(DAO.Jour jour)
        {
            InitializeComponent();
            currentTime = new TimeSpan(0, 25, 0);
            Titre.Content = jour.Intitule;
            dt.Tick += new EventHandler(dt_Tick);
            dt.Interval = new TimeSpan(0, 0, 1);
        }

        void dt_Tick(object sender, EventArgs e)
        {
            if (sw.IsRunning)
            {
                TimeSpan ts = sw.Elapsed;
                currentTime = currentTime.Add(TimeSpan.FromSeconds(-1));
                clocktxtblock.Text = currentTime.ToString();
            }
        }

        private void Start_button_click(object sender, RoutedEventArgs e)
        {
            sw.Start();
            dt.Start();
        }

        private void Stop_button_click(object sender, RoutedEventArgs e)
        {
            if (sw.IsRunning)
            {
                sw.Stop();
            }
        }
    }
}
