using PROG225__Final_Project_Snake__.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace PROG225__Final_Project_Snake__
{
    public static class GameController
    {
        public delegate void MovementManager();
        public static event MovementManager? MovementEvent;

        public static object? CurrentContent { get; set; } = new MainMenu();
        public static Window? MainWindow { get; set; }
        public static Brush GameBackground { get; set; } = Brushes.DimGray;
        public static DispatcherTimer? MovementTimer;

        public enum Difficulty { Easy, Normal, Hard }

        public static Difficulty GameDifficulty { get; set; } = Difficulty.Normal;

        private static TimeSpan GetDifficulty()
        {
            switch (GameDifficulty)
            {
                case Difficulty.Easy:
                    return new TimeSpan(1500);

                case Difficulty.Hard:
                    return new TimeSpan(500);

                default:
                    return new TimeSpan(1000);
            }
        }

        public static void CreateTimer()
        {
            MovementTimer = new DispatcherTimer();
            MovementTimer.Interval = GetDifficulty();
            MovementTimer.Tick += MovementTimer_Tick;
            MovementTimer.Start();
        }

        private static void MovementTimer_Tick(object? sender, EventArgs e)
        {
            if (MovementEvent != null)
            {
                Application.Current.Dispatcher.Invoke(MovementEvent);
            }
        }

        public static void UpdateContent() 
        {
            MainWindow!.Content = CurrentContent;
        }

        public static Grid BuildGameGrid()
        {
            Grid newGrid = new Grid();
            int n = 100;
            for (int i = 0; i < n; ++i)
            {
                newGrid.ColumnDefinitions.Add(new ColumnDefinition());
                newGrid.RowDefinitions.Add(new RowDefinition());
            }

            newGrid.Background = Brushes.DimGray;


            return newGrid;
        }
    }
}
