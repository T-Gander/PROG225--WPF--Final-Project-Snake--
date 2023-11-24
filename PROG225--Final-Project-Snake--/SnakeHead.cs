using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
