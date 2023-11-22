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
            //Need to update code to insert a variable into the next tick to update speed, because if you are quick enough you can kill yourself.
            //Need code to create a snake movement node after a keypress.

            switch (e.Key)
            {
                case Key.Up:
                    if (Snake.Player.YSpeed != 1)
                    {
                        Snake.Player.XSpeed = 0;
                        Snake.Player.YSpeed = -1;
                        Snake.CreateSnakeNode();
                    }
                    break;

                case Key.Down:
                    if (Snake.Player.YSpeed != -1)
                    {
                        Snake.Player.XSpeed = 0;
                        Snake.Player.YSpeed = 1;
                        Snake.CreateSnakeNode();
                    }
                    break;

                case Key.Left:
                    if (Snake.Player.XSpeed != 1)
                    {
                        Snake.Player.YSpeed = 0;
                        Snake.Player.XSpeed = -1;
                        Snake.CreateSnakeNode();
                    }
                    break;

                case Key.Right:
                    if (Snake.Player.XSpeed != -1)
                    {
                        Snake.Player.XSpeed = 1;
                        Snake.Player.YSpeed = 0;
                        Snake.CreateSnakeNode();
                    }
                    break;

                default: break;
            }
        }
    }
}
