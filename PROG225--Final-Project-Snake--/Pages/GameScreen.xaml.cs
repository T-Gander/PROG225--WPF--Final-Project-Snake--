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

            Grid.SetRow(Snake.Player.SnakeBounds, Snake.Player.YLocation);
            Grid.SetColumn(Snake.Player.SnakeBounds, Snake.Player.XLocation);

            GameGrid.Children.Add(Snake.Player.SnakeBounds);

            Grow();
            Grow();
            Grow();
        }

        private void Grow()
        {
            if(Snake.Body.Count == 0)
            {
                SnakeBody newBody = new SnakeBody(Snake.Player.XLocation, Snake.Player.YLocation, Snake.Player.XSpeed, Snake.Player.YSpeed);
                GameGrid.Children.Add(newBody.SnakeBounds);
                Snake.Body.Add(newBody);
            }
            else
            {
                SnakeBody lastBody = Snake.Body[Snake.Body.Count - 1];
                SnakeBody newBody = new SnakeBody(lastBody.XLocation, lastBody.YLocation, lastBody.XSpeed, lastBody.YSpeed);
                GameGrid.Children.Add(newBody.SnakeBounds);
                Snake.Body.Add(newBody);
            }
        }
    }
}
