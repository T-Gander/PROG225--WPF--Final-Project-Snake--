using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Timers;

namespace PROG225__Final_Project_Snake__.Pages
{
    /// <summary>
    /// Interaction logic for HighscoreScreen.xaml
    /// </summary>
    public partial class GameOverScreen : Page
    {
        public static StringBuilder PlayerName = new StringBuilder();
        public static Label? PlayerNameLabel, ReturnToMenuLabel;
        public GameOverScreen(int score)
        {
            InitializeComponent();

            PlayerNameLabel = lblPlayerName;
            ReturnToMenuLabel = lblReturnToMenu;

            GameController.GameOverLabelsTimer!.Start();
            GameController.GameOverContinue!.Start();

            Background = GameController.GameBackground;
            lblScore.Content = $"Score: {score}";
        }

        public static void UpdatePlayerNameLabel(object? sender, ElapsedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                PlayerNameLabel!.Content = $"Name: {PlayerName}_";
            }));
        }

        public static void FlashingLabel(object? sender, ElapsedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                if (ReturnToMenuLabel!.Visibility == Visibility.Visible)
                {
                    ReturnToMenuLabel!.Visibility = Visibility.Hidden;
                }
                else
                {
                    ReturnToMenuLabel!.Visibility = Visibility.Visible;
                }
            }));
        }
    }
}
