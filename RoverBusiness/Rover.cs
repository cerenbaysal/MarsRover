using System;
using System.Collections.Generic;
using System.Text;

namespace RoverBusiness
{
    class Rover : IRover
    {
        public static int N = 1;
        public static int E = 2;
        public static int S = 3;
        public static int W = 4;

        int x = 0;
        int y = 0;
        int facing = 1;
        List<int> maxSize;

        public Rover(List<int> maxSizeArray, int x, int y, int facing)
        {
            maxSize = maxSizeArray;
            this.x = x;
            this.y = y;
            this.facing = facing;
        }

        public string GetPosition()
        {
            char direction = 'N';
            if (facing == 1)
            {
                direction = 'N';
            }
            else if (facing == 2)
            {
                direction = 'E';
            }
            else if (facing == 3)
            {
                direction = 'S';
            }
            else if (facing == 4)
            {
                direction = 'W';
            }

            return x + " " + y + " " + direction;
        }

        public void Move()
        {
            bool check = true;
            // we should check the facing
            if (facing == N)
            {
                this.y++;
                if (this.y > maxSize[1]) check = false;
            }
            else if (facing == E)
            {
                this.x++;
                if (this.x > maxSize[0]) check = false;
            }
            else if (facing == S)
            {
                this.y--;
                if (this.y < 0) check = false;
            }
            else if (facing == W)
            {
                this.x--;
                if (this.x < 0) check = false;
            }

            if (!check)
                throw new Exception(
                            "This move exceeded the border of the plateau. Try again later.");
        }

        public void ProcessCommands(string commands)
        {
            for (int i = 0; i < commands.Length; i++)
            {
                process(commands[i]); // apply the commands sequentially
            }
        }

        private void process(Char command)
        {
            if (command == 'L')
            {
                TurnLeft();
            }
            else if (command == 'R')
            {
                TurnRight();
            }
            else if (command == 'M')
            {
                Move();
            }
            else
            {
                throw new Exception(
                        "The moves are not understandable for the rover! Try again later.");
            }
        }

        public void TurnLeft()
        {
            facing = (facing - 1) < N ? W : facing - 1;
        }

        public void TurnRight()
        {
            facing = (facing + 1) > W ? N : facing + 1;
        }
    }
}
