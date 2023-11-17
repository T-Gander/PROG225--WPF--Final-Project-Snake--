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
using System.Windows.Threading;

namespace PROG225__Final_Project_Snake__
{
    /// <summary>
    /// Interaction logic for GameScreen.xaml
    /// </summary>
    public partial class GameScreen : Page
    {
        public GameScreen()
        {
            InitializeComponent();
            //Creates 100x100 grid.
            
            GameGrid = GameController.BuildGameGrid();

            Content = GameGrid;

            BuildSnake();
        }

        private void BuildSnake()
        {
            SnakeHead snakeHead = new SnakeHead();
            GameGrid.Children.Add(snakeHead.SnakeBounds);

            Grid.SetRow(snakeHead.SnakeBounds, snakeHead.YLocation);
            Grid.SetColumn(snakeHead.SnakeBounds, snakeHead.XLocation);
        }
    }
}
