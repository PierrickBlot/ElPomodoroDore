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
        int fragment;
        bool pause = true;

        public JouerJour(DAO.Jour jour)
        {
            InitializeComponent();
            currentTime = new TimeSpan(0, 25, 0);
            fragment = jour.Fragment;
            Titre.Content = jour.Intitule;
            dt.Tick += new EventHandler(dt_Tick);
            dt.Interval = new TimeSpan(0, 0, 1);
        }

        void dt_Tick(object sender, EventArgs e)
        {
            if (sw.IsRunning && currentTime != new TimeSpan(0,0,0) && fragment!=0)
            {
                TimeSpan ts = sw.Elapsed;
                currentTime = currentTime.Add(TimeSpan.FromSeconds(-1));
                clocktxtblock.Text = currentTime.ToString();
            }
            else if (pause == true)
            {
                currentTime = currentTime.Add(TimeSpan.FromMinutes(5));
                pause = false;
            }
            else if (currentTime == new TimeSpan(0, 0, 0) && pause == false)
            {
                fragment--;
                currentTime = currentTime.Add(TimeSpan.FromMinutes(25));
                pause = true;
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
