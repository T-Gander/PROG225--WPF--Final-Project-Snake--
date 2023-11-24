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
        private List<Key> SpecialKeys = new List<Key> {
            Key.LeftShift,Key.RightShift,Key.LeftCtrl,Key.RightCtrl,Key.LeftAlt,Key.RightAlt,Key.F1,Key.F2,Key.F3,Key.F4,Key.F5,
            Key.F6,Key.F7,Key.F8,Key.F9,Key.F10,Key.F11,Key.F12,Key.Escape,Key.Insert,Key.Home,Key.PageUp,Key.Delete,Key.End,
            Key.PageDown,Key.Scroll,Key.Pause,Key.Clear,Key.Tab,Key.CapsLock,Key.LWin, Key.RWin,Key.Left,Key.Right,Key.Up,Key.Down, Key.Oem3
            // Add more keys as needed
        };

        public MainWindow()
        {
            InitializeComponent();
            GameController.MainWindow = this;
            UpdateContent(new MainMenu());
            PreviewKeyDown += GameScreen_KeyDown;
        }

        public void UpdateContent(Page content)
        {
            Content = content;
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

            if (GameController.GameOver)
            {
                switch (e.Key)
                {
                    case Key.Back:
                        if (GameOverScreen.PlayerName.Length > 0)
                            GameOverScreen.PlayerName.Remove(GameOverScreen.PlayerName.Length-1, 1);
                        break;

                    case Key.Space:
                        GameController.GameOver = false;
                        GameScreen.ResetPageContent();
                        UpdateContent(new MainMenu());
                        break;

                    default: 
                        if(!SpecialKeys.Contains(e.Key) && GameOverScreen.PlayerName.Length <= 6)
                        GameOverScreen.PlayerName.Append(e.Key.ToString());
                        break;
                }
            }
        }
    }
}
