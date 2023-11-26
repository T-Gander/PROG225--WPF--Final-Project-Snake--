using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PROG225__Final_Project_Snake__.Pages
{
    /// <summary>
    /// Interaction logic for Leaderboard.xaml
    /// </summary>
    public partial class LeaderboardScreen : Page
    {
        public LeaderboardScreen()
        {
            InitializeComponent();
            Background = GameController.GameBackground;
            DisplayHighscores();
        }

        private void DisplayHighscores()    //ChatGPT generated shortcut. The FindName method is useful!
        {
            for (int i = 0; i < GameController.Highscores.Count; i++)
            {
                string nameLabelName = "lbl" + (i + 1);
                string scoreLabelName = "lblScore" + (i + 1);

                // Find labels by name
                Label nameLabel = (Label)FindName(nameLabelName);
                Label scoreLabel = (Label)FindName(scoreLabelName);

                // Set content
                nameLabel.Content = $"{i+1}. {GameController.Highscores[i].Name}";
                scoreLabel.Content = GameController.Highscores[i].Score;
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
             GameController.MainWindow!.UpdateContent(new MainMenu());
        }
    }
}
