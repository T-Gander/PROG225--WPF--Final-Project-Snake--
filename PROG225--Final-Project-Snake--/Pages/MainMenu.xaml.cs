using System;
using System.Diagnostics;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace PROG225__Final_Project_Snake__.Pages
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        public MainMenu()
        {
            InitializeComponent();
            GameController.MovementEvent += Snake.HandleInput;
        }

        private void BackgroundVideo_MediaOpened(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Visible;
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            GameScreen newGameScreen = new GameScreen();
            GameController.MainWindow!.UpdateContent(newGameScreen);
        }

        private void Leaderboard_Click(object sender, RoutedEventArgs e)
        {
            LeaderboardScreen leaderboard = new LeaderboardScreen();
            GameController.MainWindow!.UpdateContent(leaderboard);
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            Settings settings = new Settings();
            GameController.MainWindow!.UpdateContent(settings);
        }
    }
}
