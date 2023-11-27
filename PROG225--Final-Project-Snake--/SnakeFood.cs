using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
        public MediaPlayer eatFood = new MediaPlayer();

        public SnakeFood() 
        {
            eatFood.Open(new Uri("Sounds\\pixel-sound-effect-3-82880.mp3", UriKind.RelativeOrAbsolute));

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
                eatFood.Play();
                Snake.Grow();
                GameController.AddScore();
                GameScreen.GameGrid.Children.Remove(SnakeBounds);
                GameController.CollisionEvent -= CheckForCollision;
            }
        }
    }
}
