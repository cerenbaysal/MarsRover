using System;
using System.Collections.Generic;
using System.Text;

namespace RoverBusiness
{
    interface IRover
    {
        string GetPosition();

        void ProcessCommands(String commands);

        void TurnLeft();

        void TurnRight();

        void Move();
    }
}
