using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Plateau
    {
        public int LimitX { get; set; }
        public int LimitY { get; set; }

        public Plateau(int x, int y)
        {
            LimitX = x;
            LimitY = y;
        }

    }
}
