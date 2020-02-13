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
                rover = new RoverEngine(Convert.ToInt32(maxSize.Split(' ')[0]), Convert.ToInt32(maxSize.Split(' ')[0]));
            }

            Console.WriteLine("Please put the first rover position!:");
            String firstPosition = Console.ReadLine();
            if (!checkPositionRequirements(firstPosition))
                return;

            int firstX = Convert.ToInt32(firstPosition.Trim().Split(' ')[0].ToString());
            int firstY = Convert.ToInt32(firstPosition.Trim().Split(' ')[1].ToString());
            int firstFace = faceDictionary[firstPosition.Trim().Split(' ')[2]];


            rover.setPosition(firstX, firstY, firstFace);
            Console.WriteLine("Please put the first rovers' moves!:");
            string firstMoves = Console.ReadLine();

            try
            {
                rover.processCommands(firstMoves);
                Console.WriteLine("The last position of the first rover should be: " + rover.getPosition());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Press any key to quit...");
                Console.ReadKey();
                return;
            }


            Console.WriteLine("Please put the second rover position!:");
            String secondPosition = Console.ReadLine();
            if (!checkPositionRequirements(secondPosition))
                return;

            int secondX = Convert.ToInt32(secondPosition.Trim().Split(' ')[0].ToString());
            int secondY = Convert.ToInt32(secondPosition.Trim().Split(' ')[1].ToString());
            int secondFace = faceDictionary[secondPosition.Trim().Split(' ')[2]];

            rover.setPosition(secondX, secondY, secondFace);
            Console.WriteLine("Please put the first rovers' moves!:");
            string secondMoves = Console.ReadLine();

            try
            {
                rover.processCommands(secondMoves);
                Console.WriteLine("The last position of the second rover should be: " + rover.getPosition());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Press any key to quit...");
            Console.ReadLine();
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
