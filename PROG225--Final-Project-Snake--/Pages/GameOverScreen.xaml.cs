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

        public GameOverScreen(int score)
        {
            InitializeComponent();

            GameController.CreateGameOverTimer();
            GameController.GameOverLabelsTimer!.Elapsed += FlashingLabel;

            Background = GameController.GameBackground;
            lblScore.Content = $"Score: {score}";
        }

        public void FlashingLabel(object? sender, ElapsedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                if (lblReturnToMenu.Visibility == Visibility.Visible)
                {
                    lblReturnToMenu.Visibility = Visibility.Hidden;
                }
                else
                {
                    lblReturnToMenu.Visibility = Visibility.Visible;
                }
            }));
        }
    }
}
