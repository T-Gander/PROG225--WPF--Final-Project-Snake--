using PROG225__Final_Project_Snake__.Pages;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Media;

namespace PROG225__Final_Project_Snake__
{
    public class SnakeBase
    {
        public int XLocation { get; set; }
        public int YLocation { get; set; }
        public int XSpeed { get; set; } = 1;
        public int YSpeed { get; set; } = 0;
        public Grid? SnakeBounds { get; set; }
        public Brush SnakeColor { get; set; } = Brushes.Green;

        protected Grid BuildBody()
        {
            Grid body = new Grid();
            body.Background = SnakeColor;
            return body;
        }

        public SnakeBase() 
        {
            SnakeBounds = BuildBody();
            GameController.MovementEvent += Move;
        }

        protected virtual void Move()
        {
            XLocation += XSpeed;
            YLocation += YSpeed;

            Grid.SetColumn(SnakeBounds, XLocation);
            Grid.SetRow(SnakeBounds, YLocation);
            Grid.SetZIndex(SnakeBounds, 1);
        }
    }
}
