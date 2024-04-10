using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class Program
    {
        public static void Main()
        {
            Run();
        }

        internal static void Run()
        {
            Garage garage = new Garage();
            bool showOptions = true;
            int userChoice;

            Console.WriteLine("Hi, welcome to our garage! First, produce a vehicle.");
            while (showOptions)
            {
                Console.WriteLine(
@"Please choose your action (by number):
1 - Go to garage
2 - Exit");
                while (!int.TryParse(Console.ReadLine(), out userChoice) || userChoice < 1 || userChoice > 3)
                {
                    Console.Write("The choice's number can be 1-2. Try again: ");
                }

                if (userChoice == 1)
                {
                    Console.Clear();
                    GarageUI.ShowGarageOptions(garage);
                }
                else
                {
                    Console.WriteLine("GoodBye. Enjoy your day!");
                    showOptions = false;
                }
            }
        }
    }
}
