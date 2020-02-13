using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoverBusiness;

namespace RoverApplication
{
    class Program
    {
        public static Dictionary<string, int> faceDictionary = new Dictionary<string, int>();

        static void Main(string[] args)
        {
            faceDictionary.Add("N", 1);
            faceDictionary.Add("E", 2);
            faceDictionary.Add("S", 3);
            faceDictionary.Add("W", 4);

            RoverEngine rover;

            Console.WriteLine("Please put the max size of plateau: ");
            String maxSize = Console.ReadLine();
            if (!checkPlateauRequirements(maxSize))
                return;
            else
            {
                List<int> maxSizeList = new List<int>();
                maxSizeList.Add(Convert.ToInt32(maxSize.Split(' ')[0]));
                maxSizeList.Add(Convert.ToInt32(maxSize.Split(' ')[1]));
                rover = new RoverEngine(maxSizeList);
            }

            Console.WriteLine("Please put the rover position!:");
            String position = Console.ReadLine();
            if (!checkPositionRequirements(position))
                return;

            try
            {
                int facing = faceDictionary[position.Trim().Split(' ')[2]];
            }
            catch (Exception ex)
            {
                Console.WriteLine("You can not put the facing parameter like this. Try again later.");
                return;
            }

            rover.setPosition(
                Convert.ToInt32(position.Trim().Split(' ')[0].ToString())
                , Convert.ToInt32(position.Trim().Split(' ')[1].ToString())
                , faceDictionary[position.Trim().Split(' ')[2]]);

            Console.WriteLine("Please put the rovers' moves!:");
            string moves = Console.ReadLine();

            try
            {
                rover.processCommands(moves);
                Console.WriteLine("The last position of the rover should be: " + rover.getPosition());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                return;
            }

            Console.ReadKey();
        }

        static bool checkPositionRequirements(string position)
        {
            bool check = true;
            if (position.Split(' ').Length != 3)
            {
                Console.WriteLine("You can not put the position like this: " + position + " . Try again later.");
                check = false;
                Console.ReadKey();
            }

            return check;
        }

        static bool checkPlateauRequirements(string plateau)
        {
            bool check = true;
            if (plateau.Split(' ').Length != 2)
            {
                Console.WriteLine("You can not put the size of plateau like this: " + plateau + " . Try again later.");
                check = false;
                Console.ReadKey();
            }

            return check;
        }
    }
}
