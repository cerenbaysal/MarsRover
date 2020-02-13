using System;
using System.Collections.Generic;
using System.Text;

namespace RoverBusiness
{
    public class RoverEngine
    {
        public static int N = 1;
        public static int E = 2;
        public static int S = 3;
        public static int W = 4;

        int x = 0;
        int y = 0;
        int facing = 1;
        int[,] plateau;

        public RoverEngine(int x, int y)
        {
            plateau = new int[x,y];
        }

        public void setPosition(int x, int y, int facing)
        {
            this.x = x;
            this.y = y;
            this.facing = facing;
        }

        public string getPosition()
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

        public void processCommands(String commands)
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
                turnLeft();
            }
            else if (command == 'R')
            {
                turnRight();
            }
            else if (command == 'M')
            {
                move();
            }
            else
            {
                throw new Exception(
                        "The moves are not understandable for the rover! Try again later.");
            }
        }

        private void turnLeft()
        {
            facing = (facing - 1) < N ? W : facing - 1;
        }
        private void turnRight()
        {
            facing = (facing + 1) > W ? N : facing + 1;
        }

        private void move()
        {
            // we should check the facing
            if (facing == N)
            {
                this.y++;
            }
            else if (facing == E)
            {
                this.x++;
            }
            else if (facing == S)
            {
                this.y--;
            }
            else if (facing == W)
            {
                this.x--;
            }
        }
    }
}
