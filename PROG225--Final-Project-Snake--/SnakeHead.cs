using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

namespace PROG225__Final_Project_Snake__
{
    public class SnakeHead : SnakeBase
    {
        public SnakeHead(int x, int y) 
        {
            SnakeBounds = BuildBody();
            XLocation = x;
            YLocation = y;
            GameController.CollisionEvent += CheckCollision;
        }

        private void CheckCollision()
        {
            Snake.Body.ForEach(body =>
            {
                if(body.XLocation == XLocation && body.YLocation == YLocation)
                {
                    GameController.GameOver();
                }
            });
        }

        protected override void Move()
        {
            XLocation += XSpeed;
            YLocation += YSpeed;

            if (XLocation == GameScreen.GameGrid.ColumnDefinitions.Count || YLocation == GameScreen.GameGrid.RowDefinitions.Count || XLocation == -1 || YLocation == -1)
            {
                GameController.GameOver();
                return;
            }

            Grid.SetColumn(SnakeBounds, XLocation);
            Grid.SetRow(SnakeBounds, YLocation);
            Grid.SetZIndex(SnakeBounds, 1);
        }
    }
}
