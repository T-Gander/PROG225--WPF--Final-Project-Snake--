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
        public static Grid GameGrid = GameController.BuildGameGrid();

        public GameScreen()
        {
            InitializeComponent();
            GameController.CreateTimer();

            Content = GameGrid;
            BuildSnake();
            GameController.FoodEvent += SpawnFood;
            GameController.CreateFoodTimer();
        }

        private void BuildSnake()
        {
            int startX = GameGrid.ColumnDefinitions.Count / 2;
            int startY = GameGrid.RowDefinitions.Count / 2;

            Snake.PlayerHead = new SnakeHead(startX, startY);

            Grid.SetRow(Snake.PlayerHead.SnakeBounds, Snake.PlayerHead.YLocation);
            Grid.SetColumn(Snake.PlayerHead.SnakeBounds, Snake.PlayerHead.XLocation);

            GameGrid.Children.Add(Snake.PlayerHead.SnakeBounds);

            Snake.Grow();
            Snake.Grow();
            Snake.Grow();
        }

        public static void SpawnFood()
        {
            new SnakeFood();
        }
    }
}
