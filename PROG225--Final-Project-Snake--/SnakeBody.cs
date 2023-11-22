using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG225__Final_Project_Snake__
{
    public class SnakeBody : SnakeBase
    {
        public SnakeBody(int x, int y, int xSpeed, int ySpeed)
        {
            XLocation = x-xSpeed;
            YLocation = y-ySpeed;
            XSpeed = xSpeed;
            YSpeed = ySpeed;
        }
    }
}
