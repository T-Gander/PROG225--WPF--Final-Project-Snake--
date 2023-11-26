using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media;

namespace PROG225__Final_Project_Snake__
{
    public class SnakeNode : SnakeBase
    {
        public int Decay { get; set; }
        public int BodyCountOnCreation { get; set; }
        public SnakeNode(int x, int y, int setXSpeed, int setYSpeed)
        {
            BodyCountOnCreation = Snake.Bodys.Count;
            Decay = Snake.Bodys.Count;
            XLocation = x;
            YLocation = y;
            XSpeed = setXSpeed;
            YSpeed = setYSpeed;
            SnakeBounds!.Background = Brushes.Transparent;
            GameController.CollisionEvent += CheckForCollision;
            Snake.Nodes.Add(this);
        }

        public void CheckForCollision()
        {
            if(Decay == 0)
            {
                GameController.CollisionEvent -= CheckForCollision;
                GameScreen.GameGrid.Children.Remove(SnakeBounds);
            }
            else
            {
                if (Snake.Bodys.Count > BodyCountOnCreation)
                {
                    BodyCountOnCreation++;
                    Decay++;
                }

                Snake.Bodys.ForEach(body =>
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

        override public void Move()
        {
            //Don't move
        }
    }
}
