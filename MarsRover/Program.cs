using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputData = new List<string>() { "5 5", "1 2 N", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM" };

            var nasa = new NasaMission(inputData);

            nasa.Rovers.Add(new Rover()); // Rover 1
            nasa.Rovers.Add(new Rover()); // Rover 2

            var responses = nasa.SendDataAndReturnPositions();

            foreach (var response in responses)
            {
                Console.WriteLine(response);
            }

        }
    }
}
