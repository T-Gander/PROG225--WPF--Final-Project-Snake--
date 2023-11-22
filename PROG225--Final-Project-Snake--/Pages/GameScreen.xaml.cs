using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
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
using System.Windows.Threading;

namespace PROG225__Final_Project_Snake__
{
    /// <summary>
    /// Interaction logic for GameScreen.xaml
    /// </summary>
    public partial class GameScreen : Page
    {
        public static Grid GameGrid;
        //private DispatcherTimer gameScreenTimer;

        public GameScreen()
        {
            InitializeComponent();
            GameController.CreateTimer();

            GameGrid = GameController.BuildGameGrid();

            Content = GameGrid;

            BuildSnake();
        }

        private void BuildSnake()
        {
            int startX = GameGrid.ColumnDefinitions.Count / 2;
            int startY = GameGrid.RowDefinitions.Count / 2;

            Snake.Player = new SnakeHead(startX, startY);

            GameGrid.Children.Add(Snake.Player.SnakeBounds);

            Grid.SetRow(Snake.Player.SnakeBounds, Snake.Player.YLocation);
            Grid.SetColumn(Snake.Player.SnakeBounds, Snake.Player.XLocation);
        }

        private void Grow()
        {
            if(Snake.Body.Count == 0)
            {

            }
            else
            {

            }
        }
    }
}
