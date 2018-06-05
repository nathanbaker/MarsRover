using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Rover
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public string Direction { get; set; }

        public void Rotate90Degrees(char rotateDirection)
        {

            if (rotateDirection == 'L')
            {
                switch (Direction)
                {
                    case "N": Direction = "W"; break;
                    case "E": Direction = "N"; break;
                    case "S": Direction = "E"; break;
                    case "W": Direction = "S"; break;
                }
            }
            else if (rotateDirection == 'R')
            {
                switch (Direction)
                {
                    case "N": Direction = "E"; break;
                    case "E": Direction = "S"; break;
                    case "S": Direction = "W"; break;
                    case "W": Direction = "N"; break;
                }
            }
        }

        public void MoveForward(int limitx, int limity)
        {
            //Assume that the square directly North from (x, y) is (x, y+1).        

            switch (Direction)
            {
                case "N": if (PositionY < limitx) { PositionY++; } break;
                case "E": if (PositionX < limity) { PositionX++; } break;
                case "S": if (PositionY > 0) { PositionY--; } break;
                case "W": if (PositionX > 0) { PositionX--; } break;
            }
        }

    }
}
