﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PROG225__Final_Project_Snake__.GameController;

namespace PROG225__Final_Project_Snake__
{
    public static class Snake
    {
        public static SnakeHead? PlayerHead;
        public static List<SnakeBody> Body = new List<SnakeBody>();

        public static void Grow()
        {
            if (Body.Count == 0)
            {
                SnakeBody newBody = new SnakeBody(PlayerHead!.XLocation, PlayerHead.YLocation, PlayerHead.XSpeed, PlayerHead.YSpeed);
                GameScreen.GameGrid.Children.Add(newBody.SnakeBounds);
                Body.Add(newBody);
            }
            else
            {
                SnakeBody lastBody = Body[Body.Count - 1];
                SnakeBody newBody = new SnakeBody(lastBody.XLocation, lastBody.YLocation, lastBody.XSpeed, lastBody.YSpeed);
                GameScreen.GameGrid.Children.Add(newBody.SnakeBounds);
                Body.Add(newBody);
            }
        }

        public static void CreateSnakeNode()
        {
            SnakeNode snakeNode = new SnakeNode(PlayerHead!.XLocation, PlayerHead!.YLocation, PlayerHead!.XSpeed, PlayerHead!.YSpeed);
            GameScreen.GameGrid.Children.Add(snakeNode.SnakeBounds);
        }

        public static void HandleInput()
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
}
