using PROG225__Final_Project_Snake__.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Media;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using System.Xml.Linq;

namespace PROG225__Final_Project_Snake__
{
    public static class GameController
    {
        static GameController()
        {
            MovementTimer = new Timer();
            MovementTimer.Elapsed += MovementTimer_Tick;

            FoodTimer = new Timer();
            FoodTimer.Elapsed += FoodTimer_Tick;
            FoodEvent += GameScreen.SpawnFood;

            GameOverLabelsTimer = new Timer();
            GameOverLabelsTimer.Interval = 100;
            GameOverLabelsTimer.Elapsed += GameOverScreen.UpdatePlayerNameLabel;

            GameOverContinue = new Timer();
            GameOverContinue.Interval = 800;
            GameOverContinue.Elapsed += GameOverScreen.FlashingLabel;

            
            //BackgroundVideo = new MediaElement 
            //{ 
            //    Source = new Uri("Videos/static.mp4", UriKind.RelativeOrAbsolute),
            //    Opacity = 0.9,
            //    LoadedBehavior = MediaState.Manual,
            //    Stretch = Stretch.Fill,
            //    HorizontalAlignment = HorizontalAlignment.Stretch,
            //    VerticalAlignment = VerticalAlignment.Stretch
            //};
            //Grid.SetColumnSpan( BackgroundVideo, 2000 );
            //Grid.SetRowSpan(BackgroundVideo, 2000);
            //Grid.SetZIndex(BackgroundVideo, -1);
        }

        public delegate void UIManager();
        public static event UIManager? MovementEvent;
        public static event UIManager? CollisionEvent;
        public static event UIManager? FoodEvent;
        public static Dispatcher UIThread = Application.Current.Dispatcher;

        private static int foodSpawnCounter;

        public static MediaPlayer GameMusic = new MediaPlayer();

        public static MainWindow? MainWindow { get; set; }
        public static Brush GameBackground { get; set; } = Brushes.DarkGray;
        public static Timer? MovementTimer, FoodTimer, InputTimer, GameOverLabelsTimer, GameOverContinue;

        public static List<Timer?> TimerCollection = new List<Timer?>() { MovementTimer, FoodTimer, InputTimer, GameOverLabelsTimer, GameOverContinue };

        public static List<Highscore> Highscores = DatabaseManager.GetHighScores();

        public enum MovementDirection { Left, Right, Up, Down, None }

        public static MovementDirection MoveDirection { get; set; } = MovementDirection.None;

        public enum Difficulty { Easy, Normal, Hard }

        public static Difficulty GameDifficulty { get; set; } = Difficulty.Normal;

        public enum  State { GameOver, MainMenu, Settings, Play, NewHighscore }

        public static State GameState { get; set; } = State.MainMenu;
        
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

        public static void AddScore()
        {
            _ = GameDifficulty switch
            {
                Difficulty.Easy => Score++,
                Difficulty.Normal => Score += 2,
                _ => Score += 3
            };
        }

        public static void RefreshDifficulty()
        {
            MovementTimer!.Interval = GetDifficulty();
            FoodTimer!.Interval = GetDifficulty();
        }

        private static void MovementTimer_Tick(object? sender, EventArgs e)
        {
            if (CollisionEvent != null)
            {
                UIThread.Invoke(CollisionEvent);
            }

            if (MovementEvent != null && GameState != State.GameOver)
            {
                UIThread.Invoke(MovementEvent);
            }

            MoveDirection = MovementDirection.None;

            if (GameState == State.GameOver)
            {
                Debug.WriteLine("Resetting Game");
                Snake.Reset();
                MovementTimer!.Stop();
                FoodTimer!.Stop();
                Debug.WriteLine("Game Reset");
                UIThread.Invoke(new Action(() => MainWindow!.UpdateContent(new GameOverScreen(Score))));
            }
        }

        private static void FoodTimer_Tick(object? sender, EventArgs e)
        {
            if (foodSpawnCounter == 20 && FoodEvent != null)
            {
                foodSpawnCounter = 0;
                UIThread.Invoke(FoodEvent);
            }
            foodSpawnCounter++;
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

        public static void SetGameOver()
        {
            GameState = State.GameOver;
        }
    }
}
