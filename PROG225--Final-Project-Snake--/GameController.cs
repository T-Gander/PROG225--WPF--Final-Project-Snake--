﻿using PROG225__Final_Project_Snake__.Pages;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace PROG225__Final_Project_Snake__
{
    public static class GameController
    {
        public delegate void UIManager();
        public static event UIManager? MovementEvent;
        public static event UIManager? CollisionEvent;
        public static event UIManager? LabelsEvent;
        public static event UIManager? FoodEvent;

        private static int foodSpawnCounter;

        public static MainWindow? MainWindow { get; set; }
        public static Brush GameBackground { get; set; } = Brushes.LightGray;
        public static Timer? MovementTimer, FoodTimer, InputTimer, GameOverLabelsTimer;

        public enum MovementDirection { Left, Right, Up, Down, None }

        public static MovementDirection MoveDirection { get; set; } = MovementDirection.None;

        public enum Difficulty { Easy, Normal, Hard }

        public static Difficulty GameDifficulty { get; set; } = Difficulty.Normal;

        private static bool gameOver = false;

        public static int Score = 0;

        private static double GetDifficulty()
        {
            //Weird intellisense suggestion to shorten switch statement?
            //this is skipping writing case each time and treating a switch like it has properties. The _ represents default.

            return GameDifficulty switch
            {
                Difficulty.Easy => 150,
                Difficulty.Hard => 75,
                _ => (double)125,
            };
        }

        public static void CreateTimer()
        {
            MovementTimer = new Timer();
            MovementTimer.Interval = GetDifficulty();
            MovementTimer.Elapsed += MovementTimer_Tick;
            MovementTimer.Start();
        }

        public static void CreateGameOverTimer()
        {
            GameOverLabelsTimer = new Timer();
            GameOverLabelsTimer.Interval = 800;
            GameOverLabelsTimer.Start();
        }

        public static void CreateFoodTimer()
        {
            FoodTimer = new Timer();
            FoodTimer.Interval = GetDifficulty();
            FoodTimer.Elapsed += FoodTimer_Tick;
            FoodTimer.Start();
        }

        private static void FoodTimer_Tick(object? sender, EventArgs e)
        {
            if (foodSpawnCounter == 20)
            {
                foodSpawnCounter = 0;
                Application.Current.Dispatcher.Invoke(FoodEvent);
            }
            foodSpawnCounter++;
        }

        private static void MovementTimer_Tick(object? sender, EventArgs e)
        {
            //if(foodSpawnCounter == 20)
            //{
            //    foodSpawnCounter = 0;
            //    Application.Current.Dispatcher.Invoke(new Action(() => GameScreen.SpawnFood()));
            //}

            if (CollisionEvent != null)
            {
                Application.Current.Dispatcher.Invoke(CollisionEvent);
            }

            if (MovementEvent != null && gameOver != true)
            {
                Application.Current.Dispatcher.Invoke(MovementEvent);
            }

            //foodSpawnCounter++;

            MoveDirection = MovementDirection.None;

            if (gameOver)
            {
                Application.Current.Dispatcher.Invoke(new Action(() => MainWindow!.UpdateContent(new GameOverScreen(Score))));
            }
        }

        public static Grid BuildGameGrid()
        {
            Grid newGrid = new Grid();
            int w = 40;
            for (int i = 0; i < w; ++i)
            {
                newGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            int h = 23;
            for(int i = 0; i<h; i++)
            {
                newGrid.RowDefinitions.Add(new RowDefinition());
            }

            newGrid.Background = GameBackground;

            return newGrid;
        }

        public static void GameOver()
        {
            gameOver = true;
            MovementTimer!.Stop();
        }
    }
}
