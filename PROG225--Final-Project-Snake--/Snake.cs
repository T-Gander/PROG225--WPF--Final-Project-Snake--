using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG225__Final_Project_Snake__
{
    public static class Snake
    {
        public static SnakeHead Player;
        public static List<SnakeBody> Body = new List<SnakeBody>();

        public static void CreateSnakeNode()
        {
            SnakeNode snakeNode = new SnakeNode(Player.XLocation, Player.YLocation, Player.XSpeed, Player.YSpeed);
            GameScreen.GameGrid.Children.Add(snakeNode.SnakeBounds);
        }
    }
}
