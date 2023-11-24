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

            Snake.PlayerHead = new SnakeHead(startX, startY);

            Grid.SetRow(Snake.PlayerHead.SnakeBounds, Snake.PlayerHead.YLocation);
            Grid.SetColumn(Snake.PlayerHead.SnakeBounds, Snake.PlayerHead.XLocation);

            GameGrid.Children.Add(Snake.PlayerHead.SnakeBounds);

            Grow();
            Grow();
            Grow();

            SpawnFood();
            SpawnFood();
            SpawnFood();
        }

        public static void Grow()
        {
            if(Snake.Body.Count == 0)
            {
                SnakeBody newBody = new SnakeBody(Snake.PlayerHead.XLocation, Snake.PlayerHead.YLocation, Snake.PlayerHead.XSpeed, Snake.PlayerHead.YSpeed);
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

        public static SnakeFood SpawnFood()
        {
            return new SnakeFood();
        }

        
    }
}
