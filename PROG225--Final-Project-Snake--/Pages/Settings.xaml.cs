using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
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

namespace PROG225__Final_Project_Snake__.Pages
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        public Settings()
        {
            InitializeComponent();
            Background = GameController.GameBackground;
            cmbDifficulty.SelectedIndex = (int)GameController.GameDifficulty;
        }

        private void cmbDifficulty_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GameController.GameDifficulty = (GameController.Difficulty)cmbDifficulty.SelectedIndex;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            GameController.MainWindow!.UpdateContent(new MainMenu());

            try
            {
                string jsonString = JsonConvert.SerializeObject(GameController.GameDifficulty);
                File.WriteAllText(".\\DifficultySettings.json", jsonString);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Saving failed... Check logs.");
                File.WriteAllText(".\\log.txt", ex.Message);
            }
        }
    }
}
