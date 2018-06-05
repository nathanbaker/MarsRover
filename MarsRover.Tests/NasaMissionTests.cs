using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRover.Tests
{
    [TestClass]
    public class NasaMissionTests
    {
        [TestMethod]
        public void SendDataToRovers()
        {
            var inputData = new List<string>() { "5 5", "1 2 N", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM" };

            var nasaMission = new NasaMission(inputData);
            nasaMission.Rovers.Add(new Rover()); // Rover 1
            nasaMission.Rovers.Add(new Rover()); // Rover 2

            var response = nasaMission.SendDataAndReturnPositions();

            Assert.IsTrue(response[0] == "1 3 N");
            Assert.IsTrue(response[1] == "5 1 E");

        }

        [TestMethod]
        public void SetInitialRoverPosition()
        {
            var inputData = new List<string>() { "5 5", "1 2 N", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM" };
            var nasaMission = new NasaMission(inputData);
            nasaMission.Rovers.Add(new Rover()); // Rover 1
            nasaMission.Rovers.Add(new Rover()); // Rover 2

            nasaMission.SetRoverInitialPosition(0, "1 2 N");
            nasaMission.SetRoverInitialPosition(1, "3 3 E");

            Assert.IsTrue(nasaMission.Rovers[0].PositionX == 1);
            Assert.IsTrue(nasaMission.Rovers[0].PositionY == 2);
            Assert.IsTrue(nasaMission.Rovers[0].Direction == "N");

            Assert.IsTrue(nasaMission.Rovers[1].PositionX == 3);
            Assert.IsTrue(nasaMission.Rovers[1].PositionY == 3);
            Assert.IsTrue(nasaMission.Rovers[1].Direction == "E");
        }
    }
}
