using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

            if(XLocation > GameScreen.GameGrid.ColumnDefinitions.Count ||  YLocation > GameScreen.GameGrid.RowDefinitions.Count
                || XLocation < 0 || YLocation < 0)
            {
                GameController.GameOver();
            }

            Grid.SetColumn(SnakeBounds, XLocation);
            Grid.SetRow(SnakeBounds, YLocation);
        }
    }
}
