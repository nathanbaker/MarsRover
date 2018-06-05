using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class NasaMission
    {
   
        public List<Rover> Rovers;

        public Plateau Plateau;

        private readonly IList<string> _inputData;

        const char space = ' ';


        public NasaMission(IList<string> inputData)
        {
            if (inputData.Any())
            {
                _inputData = inputData;

                Rovers = new List<Rover>();

                AssignPlateauLimits();
            }
            else
            {
                throw new Exception("No input data received");
            }
        }

        public void SetRoverInitialPosition(int roverIndex, string commandline)
        {
            var commands = commandline.Split(space);

            var x = Convert.ToInt32(commands[0]);
            var y = Convert.ToInt32(commands[1]);

            if (x <= Plateau.LimitX && y <= Plateau.LimitY && x>=0 && y>=0)
            {
                // first command - initial co-ordinates eg. 1 2 N                
                Rovers[roverIndex].PositionX = x;
                Rovers[roverIndex].PositionY = y;
                Rovers[roverIndex].Direction = commands[2];
            }
            else
            {
                throw new Exception("Position is out of bands of Plateau Limits");
            }
        }

        public void ProcessRoverActions(int roverIndex, string commandline)
        {
            var numberOfCommands = commandline.Length;

            for (int x = 0; x < numberOfCommands; x++)
            {
                var commands = commandline.ToCharArray();
                char command = commands[x];

                if (command == 'L' || command == 'R')
                {
                    Rovers[roverIndex].Rotate90Degrees(command);
                }
                else if (command == 'M')
                {
                    //'M' means move forward one grid point, and maintain the same heading.
                    Rovers[roverIndex].MoveForward(Plateau.LimitX, Plateau.LimitY);
                }
            }
        }

        /// <summary>
        /// Setup plateau first line of commandset are the plateau co-ordinates 
        /// </summary>
        public void AssignPlateauLimits()
        {
            var commands = _inputData[0].Split(space);
            Plateau = new Plateau(Convert.ToInt32(commands[0]), Convert.ToInt32(commands[1]));
        }


        public List<string> SendDataAndReturnPositions()
        {
            var output = new List<string>();

            var commandIndex = 1; // Start at index 1 (Rover commands)

            for (var i = 0; i < this.Rovers.Count; i++)
            {

                if (!string.IsNullOrWhiteSpace(_inputData[commandIndex]))
                {
                    var commandline = _inputData[commandIndex];
                    SetRoverInitialPosition(i, commandline);
                }

                commandIndex++; // Increment to next set of commands

                if (!string.IsNullOrWhiteSpace(_inputData[commandIndex]))
                {
                    var commandline = _inputData[commandIndex];
                    ProcessRoverActions(i, commandline);
                }

                commandIndex++;

                var result = string.Format("{0} {1} {2}", Rovers[i].PositionX, Rovers[i].PositionY, Rovers[i].Direction);

                output.Add(result);
            }

            return output;
        }
    }
}
