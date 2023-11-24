using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace PROG225__Final_Project_Snake__
{
    public class SnakeFood : SnakeBase
    {
        int gridColumns = GameScreen.GameGrid.ColumnDefinitions.Count;
        int gridRows = GameScreen.GameGrid.RowDefinitions.Count;

        public SnakeFood() 
        {
            Random random = new Random();
            SnakeBounds!.Background = Brushes.Yellow;

            XLocation = random.Next(gridColumns + 1);
            YLocation = random.Next(gridRows + 1);

            Grid.SetColumn(SnakeBounds!, XLocation);
            Grid.SetRow(SnakeBounds!, YLocation);

            GameScreen.GameGrid.Children.Add(SnakeBounds);
            GameController.CollisionEvent += CheckForCollision;
        }

        protected override void Move()
        {
            //Don't move.
        }

        private void CheckForCollision()
        {
            if(Snake.PlayerHead!.XLocation == XLocation && Snake.PlayerHead!.YLocation == YLocation) 
            {
                GameController.CollisionEvent -= CheckForCollision;
                GameScreen.GameGrid.Children.Remove(SnakeBounds);
                GameScreen.Grow();
            }
        }
    }
}
