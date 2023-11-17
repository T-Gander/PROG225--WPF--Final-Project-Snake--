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
        public int XLocation { get; set; } = 0;
        public int YLocation { get; set; } = 0;
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
        }

    }
}
