using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG225__Final_Project_Snake__
{
    public class SnakeHead : SnakeBase
    {
        public SnakeHead() 
        {
            SnakeBounds = BuildBody();
        }

    }
}
