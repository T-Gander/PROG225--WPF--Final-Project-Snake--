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

            GameController.Highscores.ForEach(highscore =>
            {
                if(highscore.Score < GameController.Score)
                {
                    GameController.GameState = GameController.State.NewHighscore;
                }
            });

            if(GameController.GameState == GameController.State.NewHighscore)
            {
                GameController.GameOverLabelsTimer!.Start();
            }
            else
            {
                lblMadeLeaderboard.Visibility = Visibility.Hidden;
                PlayerNameLabel!.Visibility = Visibility.Hidden;
            }

            GameController.GameOverContinue!.Start();

            Background = GameController.GameBackground;
            lblScore.Content = $"Score: {score}";
        }

        public static void UpdatePlayerNameLabel(object? sender, ElapsedEventArgs e)
        {
            try
            {
                GameController.UIThread.Invoke(new Action(() =>
                {
                    PlayerNameLabel!.Content = $"Name: {PlayerName}_";
                }));
            }
            catch { }
                
        }

        public static void FlashingLabel(object? sender, ElapsedEventArgs e)
        {
            try
            {
                GameController.UIThread.Invoke(new Action(() =>
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
            catch { }
        }
    }
}
