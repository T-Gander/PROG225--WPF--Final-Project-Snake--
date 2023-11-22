using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media;

namespace PROG225__Final_Project_Snake__
{
    internal class SnakeNode : SnakeBase
    {
        public int Decay { get; set; }
        public int BodyCountOnCreation { get; set; }
        public SnakeNode(int x, int y, int setXSpeed, int setYSpeed)
        {
            BodyCountOnCreation = Snake.Body.Count;
            Decay = Snake.Body.Count;
            XLocation = x;
            YLocation = y;
            XSpeed = setXSpeed;
            YSpeed = setYSpeed;
            SnakeBounds!.Background = Brushes.Transparent;
            GameController.MovementEvent += CheckCollision;
        }

        private void CheckCollision()
        {
            if(Decay == 0)
            {
                GameController.MovementEvent -= CheckCollision;
                GameScreen.GameGrid.Children.Remove(SnakeBounds);
            }
            else
            {
                if (Snake.Body.Count > BodyCountOnCreation)
                {
                    BodyCountOnCreation++;
                    Decay++;
                }

                Snake.Body.ForEach(body =>
                {
                    if (body.XLocation == XLocation && body.YLocation == YLocation)
                    {
                        body.XSpeed = XSpeed;
                        body.YSpeed = YSpeed;
                    }
                });
            }
            Decay--;
        }

        override protected void Move()
        {
            //Don't move
        }
    }
}
