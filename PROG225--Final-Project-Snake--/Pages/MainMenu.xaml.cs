using System;
using System.Diagnostics;
using System.Timers;
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
        private static Timer? videoTimer;
        private int videoCount = 0;

        public MainMenu()
        {
            InitializeComponent();
            backgroundVideo.Play();
            videoTimer = new Timer();
            videoTimer.Interval = 1000;
            videoTimer.Elapsed += VideoTimer_Tick;
            videoTimer.Start();
            GameController.MovementEvent += Snake.HandleInput;
            
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
            GameScreen newGameScreen = new GameScreen();
            GameController.CurrentGameScreen = newGameScreen;
            GameController.MainWindow!.UpdateContent(newGameScreen);
            backgroundVideo.Stop();
            videoTimer!.Stop();
        }
    }
}
