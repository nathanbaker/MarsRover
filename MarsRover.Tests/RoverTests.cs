using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Tests
{
    [TestClass]
    public class RoverTests
    {
        [TestMethod]
        public void MoveRoverOneSpaceWhenNorth()
        {
            var rover = new Rover();
            rover.PositionX = 0;
            rover.PositionY = 0;
            rover.Direction = "N";

            rover.MoveForward(5, 5); // Plateau Limits

            Assert.IsTrue(rover.PositionX == 0);
            Assert.IsTrue(rover.PositionY == 1);
        }

        [TestMethod]
        public void MoveRoverOneSpaceWhenSouth()
        {
            var rover = new Rover(); // Rover 1
            rover.PositionX = 2;
            rover.PositionY = 2;
            rover.Direction = "S";
            
            rover.MoveForward(5, 5);  // Plateau Limits

            Assert.IsTrue(rover.PositionX == 2);
            Assert.IsTrue(rover.PositionY == 1);
        }
    }
}
