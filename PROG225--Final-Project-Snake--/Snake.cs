using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using static PROG225__Final_Project_Snake__.GameController;

namespace PROG225__Final_Project_Snake__
{
    public static class Snake
    {
        public static SnakeHead? PlayerHead;
        public static List<SnakeBody> Bodys = new List<SnakeBody>();
        public static List<SnakeNode> Nodes = new List<SnakeNode>();
        public static List<SnakeFood> Foods = new List<SnakeFood>();

        public static void Grow()
        {
            if (Bodys.Count == 0)
            {
                SnakeBody newBody = new SnakeBody(PlayerHead!.XLocation, PlayerHead.YLocation, PlayerHead.XSpeed, PlayerHead.YSpeed);
                Grid.SetColumn(newBody.SnakeBounds, newBody.XLocation);
                Grid.SetRow(newBody.SnakeBounds, newBody.YLocation);
                Grid.SetZIndex(newBody.SnakeBounds, 1);
                GameScreen.GameGrid.Children.Add(newBody.SnakeBounds);
                Bodys.Add(newBody);
            }
            else
            {
                SnakeBody lastBody = Bodys[Bodys.Count - 1];
                SnakeBody newBody = new SnakeBody(lastBody.XLocation, lastBody.YLocation, lastBody.XSpeed, lastBody.YSpeed);
                Grid.SetColumn(newBody.SnakeBounds, newBody.XLocation);
                Grid.SetRow(newBody.SnakeBounds, newBody.YLocation);
                Grid.SetZIndex(newBody.SnakeBounds, 1);
                GameScreen.GameGrid.Children.Add(newBody.SnakeBounds);
                Bodys.Add(newBody);
            }
        }

        public static void CreateSnakeNode()
        {
            SnakeNode snakeNode = new SnakeNode(PlayerHead!.XLocation, PlayerHead!.YLocation, PlayerHead!.XSpeed, PlayerHead!.YSpeed);
            GameScreen.GameGrid.Children.Add(snakeNode.SnakeBounds);
        }

        public static void HandleInput()
        {
            if(GameState == State.Play)
            {
                switch (MoveDirection)
                {
                    case MovementDirection.Up:
                        if (PlayerHead!.YSpeed != 1)
                        {
                            PlayerHead.XSpeed = 0;
                            PlayerHead.YSpeed = -1;
                            CreateSnakeNode();
                        }
                        break;

                    case MovementDirection.Down:
                        if (PlayerHead!.YSpeed != -1)
                        {
                            PlayerHead.XSpeed = 0;
                            PlayerHead.YSpeed = 1;
                            CreateSnakeNode();
                        }
                        break;

                    case MovementDirection.Left:
                        if (PlayerHead!.XSpeed != 1)
                        {
                            PlayerHead.YSpeed = 0;
                            PlayerHead.XSpeed = -1;
                            CreateSnakeNode();
                        }
                        break;

                    case MovementDirection.Right:
                        if (PlayerHead!.XSpeed != -1)
                        {
                            PlayerHead.XSpeed = 1;
                            PlayerHead.YSpeed = 0;
                            CreateSnakeNode();
                        }
                        break;

                    default: break;
                }
            }
        }

        public static void Reset()
        {
            MovementEvent -= PlayerHead!.Move;
            CollisionEvent -= PlayerHead!.CheckCollision;
            PlayerHead = null;
            Bodys.ForEach(body => MovementEvent -= body.Move);
            Bodys.Clear();
            Nodes.ForEach(node => CollisionEvent -= node.CheckForCollision);
            Nodes.Clear();
            Foods.ForEach(food => CollisionEvent -= food.CheckForCollision);
            Foods.Clear();
        }
    }
}
