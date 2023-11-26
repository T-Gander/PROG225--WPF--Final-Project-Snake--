using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using static System.Formats.Asn1.AsnWriter;

namespace PROG225__Final_Project_Snake__
{
    public class SnakeFood : SnakeBase
    {
        int gridColumns = GameScreen.GameGrid.ColumnDefinitions.Count;
        int gridRows = GameScreen.GameGrid.RowDefinitions.Count;

        public SnakeFood() 
        {
            Random random = new Random();
            SnakeBounds!.Background = Brushes.Red;

            XLocation = random.Next(gridColumns);
            YLocation = random.Next(gridRows);

            Grid.SetColumn(SnakeBounds!, XLocation);
            Grid.SetRow(SnakeBounds!, YLocation);
            Grid.SetZIndex(SnakeBounds!, 0);

            GameScreen.GameGrid.Children.Add(SnakeBounds);
            GameController.CollisionEvent += CheckForCollision;
            Snake.Foods.Add(this);
        }

        public override void Move()
        {
            //Don't move.
        }

        public void CheckForCollision()
        {
            if(Snake.PlayerHead!.XLocation == XLocation && Snake.PlayerHead!.YLocation == YLocation) 
            {
                Snake.Grow();
                GameController.Score++;
                GameScreen.GameGrid.Children.Remove(SnakeBounds);
                GameController.CollisionEvent -= CheckForCollision;
            }
        }
    }
}
