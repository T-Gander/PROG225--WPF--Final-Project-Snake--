using PROG225__Final_Project_Snake__.Pages;
using System;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace PROG225__Final_Project_Snake__
{
    public static class GameController
    {
        public delegate void MovementManager();
        public static event MovementManager? MovementEvent;

        public static object? CurrentContent { get; set; } = new MainMenu();
        public static Window? MainWindow { get; set; }
        public static Brush GameBackground { get; set; } = Brushes.DimGray;
        public static Timer? MovementTimer;
        public enum MovementDirection { Left, Right, Up, Down, None }

        public static MovementDirection MoveDirection { get; set; } = MovementDirection.None;

        public enum Difficulty { Easy, Normal, Hard }

        public static Difficulty GameDifficulty { get; set; } = Difficulty.Normal;

        private static double GetDifficulty()
        {
            switch (GameDifficulty)
            {
                case Difficulty.Easy:
                    return 150;

                case Difficulty.Hard:
                    return 75;

                default:
                    return 125;
            }
        }

        public static void CreateTimer()
        {
            MovementTimer = new Timer();
            MovementTimer.Interval = GetDifficulty();
            MovementTimer.Elapsed += MovementTimer_Tick;
            MovementTimer.Start();
        }

        public static void HandleInput()
        {
            switch (MoveDirection)
            {
                case MovementDirection.Up:
                    if (Snake.Player.YSpeed != 1)
                    {
                        Snake.Player.XSpeed = 0;
                        Snake.Player.YSpeed = -1;
                        Snake.CreateSnakeNode();
                    }
                    break;

                case MovementDirection.Down:
                    if (Snake.Player.YSpeed != -1)
                    {
                        Snake.Player.XSpeed = 0;
                        Snake.Player.YSpeed = 1;
                        Snake.CreateSnakeNode();
                    }
                    break;

                case MovementDirection.Left:
                    if (Snake.Player.XSpeed != 1)
                    {
                        Snake.Player.YSpeed = 0;
                        Snake.Player.XSpeed = -1;
                        Snake.CreateSnakeNode();
                    }
                    break;

                case MovementDirection.Right:
                    if (Snake.Player.XSpeed != -1)
                    {
                        Snake.Player.XSpeed = 1;
                        Snake.Player.YSpeed = 0;
                        Snake.CreateSnakeNode();
                    }
                    break;

                default: break;
            }
        }

        private static void MovementTimer_Tick(object? sender, EventArgs e)
        {
            if (MovementEvent != null)
            {
                Application.Current.Dispatcher.Invoke(MovementEvent);
            }
            MoveDirection = MovementDirection.None;
        }

        public static void UpdateContent() 
        {
            MainWindow!.Content = CurrentContent;
        }

        public static Grid BuildGameGrid()
        {
            Grid newGrid = new Grid();
            int w =80;
            for (int i = 0; i < w; ++i)
            {
                newGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            int h = 45;
            for(int i = 0; i<h; i++)
            {
                newGrid.RowDefinitions.Add(new RowDefinition());
            }

            newGrid.Background = Brushes.Azure;

            return newGrid;
        }

        public static void GameOver()
        {

        }
    }
}
