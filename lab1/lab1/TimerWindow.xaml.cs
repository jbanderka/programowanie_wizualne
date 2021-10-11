using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Diagnostics;
using System.Windows.Threading;

namespace lab1
{
    /// <summary>
    /// Interaction logic for TimerWindow.xaml
    /// </summary>
    public partial class TimerWindow : Window
    {
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        Stopwatch sWatch = new Stopwatch();
        string current = string.Empty;
        public TimerWindow()
        {
            InitializeComponent();
            dispatcherTimer.Tick += timerTick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            if(!sWatch.IsRunning)
            {
                Time.Content = "00:00:00";
            }
        }

        void timerTick(object sender, EventArgs e)
        {
            if(sWatch.IsRunning)
            {
                TimeSpan timeSpan = sWatch.Elapsed;
                current = String.Format("{0:00}:{1:00}:{2:00}", timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds / 10);
                Time.Content = current;
            }
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            sWatch.Reset();
            sWatch.Start();
            dispatcherTimer.Start();
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            if(sWatch.IsRunning)
            {
                sWatch.Stop();
            }
        }
    }
}
