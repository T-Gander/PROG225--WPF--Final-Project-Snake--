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
            if(Visibility != Visibility.Visible)
            {
                GameController.UIThread.Invoke(new Action(() =>          //Won't show content until the video starts playing. ChatGPT couldn't help with this problem... So this is what I came up with.
                {
                    if (backgroundVideo.Position > new TimeSpan(0, 0, 0))           
                    {
                        Visibility = Visibility.Visible;
                    }
                }));
            }
            
            if(videoCount == 20)
            {
                GameController.UIThread.Invoke(new Action(() => backgroundVideo.Position = new TimeSpan(0,0,0)));
                videoCount = 0;
            }
            else
            videoCount++;

            Debug.WriteLine($"{videoCount}");
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            GameScreen newGameScreen = new GameScreen();
            GameController.MainWindow!.UpdateContent(newGameScreen);
            backgroundVideo.Stop();
            videoTimer!.Stop();
        }

        private void Leaderboard_Click(object sender, RoutedEventArgs e)
        {
            LeaderboardScreen leaderboard = new LeaderboardScreen();
            GameController.MainWindow!.UpdateContent(leaderboard);
            backgroundVideo.Stop();
            videoTimer!.Stop();
        }
    }
}
