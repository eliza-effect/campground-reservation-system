
using Capstone.DAL;
using Capstone.Models;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone
{
    public class MainCLI
    {
        int numParks = 0;
        readonly string DatabaseConnection = ConfigurationManager.ConnectionStrings["Campground"].ConnectionString;

        public void RunCLI()
        {
            PrintHeader();
            PrintMenu();

            while (true)
            {
                string command = Console.ReadLine();

                Console.Clear();

                if (command.ToLower() == "q")
                {
                    Console.WriteLine("Thank you for using the campground reservation system");
                    return;
                }
                else if (int.Parse(command) <= numParks && int.Parse(command) > 0)
                {
                    CampgroundCLI cli = new CampgroundCLI(int.Parse(command));
                    cli.RunCampgroundCLI();
                }
                else
                {
                    Console.WriteLine("The command provided was not a valid command, please try again.");
                    break;
                }

                PrintMenu();
            }
        }

        private void DisplayParkNames()
        {
            ParkSqlDAL pIO = new ParkSqlDAL(DatabaseConnection);
            List<Park> parks = pIO.GetParks();
            numParks = parks.Count;

            if (parks.Count > 0)
            {
                for (int i = 0; i < parks.Count; i++)
                {
                    Console.WriteLine((i+1) + ") " + parks[i].Name);
                }
            }
            else
            {
                Console.WriteLine("**** NO RESULTS FOUND ****");
            }
        }


        private void PrintHeader()
        {
            Console.WriteLine("WELCOME TO THE CAMPGROUND RESERVATION SYSTEM");
        }

        private void PrintMenu()
        {
            Console.WriteLine("Select a Park for Further Details");
            DisplayParkNames();
            Console.WriteLine();
            Console.WriteLine("Q) - Quit");
            Console.WriteLine();
        }

    }
}
