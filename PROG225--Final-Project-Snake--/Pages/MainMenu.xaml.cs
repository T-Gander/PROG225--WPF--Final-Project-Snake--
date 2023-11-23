using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace PROG225__Final_Project_Snake__.Pages
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        private static DispatcherTimer videoTimer;
        private int videoCount = 0;

        public MainMenu()
        {
            InitializeComponent();
            backgroundVideo.Play();
            videoTimer = new DispatcherTimer();
            videoTimer.Interval = new TimeSpan(0,0,1);
            videoTimer.Tick += VideoTimer_Tick;
            videoTimer.Start();
            GameController.MovementEvent += GameController.HandleInput;

        }

        private void VideoTimer_Tick(object? sender, EventArgs e)
        {
            if(videoCount == 20)
            {
                backgroundVideo.Position = new TimeSpan(0,0,0);
                videoCount = 0;
            }
            else
            videoCount++;

            Debug.WriteLine($"{videoCount}");
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            GameController.CurrentContent = new GameScreen();
            GameController.UpdateContent();
            backgroundVideo.Stop();
            videoTimer.Stop();
        }
    }
}
