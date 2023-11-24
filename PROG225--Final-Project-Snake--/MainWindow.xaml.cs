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
using System.Windows.Navigation;
using System.Windows.Shapes;
using PROG225__Final_Project_Snake__.Pages;

namespace PROG225__Final_Project_Snake__
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GameController.MainWindow = this;
            GameController.UpdateContent();
            PreviewKeyDown += GameScreen_KeyDown;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            KeyDown += new KeyEventHandler(GameScreen_KeyDown);
        }

        private void GameScreen_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up:
                    GameController.MoveDirection = GameController.MovementDirection.Up;
                    break;

                case Key.Down:
                    GameController.MoveDirection = GameController.MovementDirection.Down;
                    break;

                case Key.Left:
                    GameController.MoveDirection = GameController.MovementDirection.Left;
                    break;

                case Key.Right:
                    GameController.MoveDirection = GameController.MovementDirection.Right;
                    break;

                default: break;
            }
        }
    }
}
