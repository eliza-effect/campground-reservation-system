using Capstone.DAL;
using Capstone.Models;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Capstone
{
    public class CampgroundCLI
    {
        int parkID;
        readonly string DatabaseConnection = ConfigurationManager.ConnectionStrings["Campground"].ConnectionString;

        public CampgroundCLI (int parkID)
        {
            this.parkID = parkID;
        }

        public void RunCampgroundCLI()
        {
            PrintHeader();
            PrintMenu();

            while (true)
            {
                string command = Console.ReadLine();

                Console.Clear();

                if (command == "1")
                {
                    GetAllCampgrounds();
                }
                else if (command == "2")
                {
                    MakeReservations();
                }
                else if (command == "3")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("The command provided was not a valid command, please try again.");
                    break;
                }

                PrintMenu();
            }
        }


        private void PrintHeader()
        {
            ParkSqlDAL pIO = new ParkSqlDAL(DatabaseConnection);
            DisplayParkInfo();
        }

        private void PrintMenu()
        {
            Console.WriteLine("Select a Command");
            Console.WriteLine("1) View Campgrounds");
            Console.WriteLine("2) Search for Reservation");
            Console.WriteLine("3) Return to Previous Menu");
            Console.WriteLine();
        }


        private void DisplayParkInfo()
        {
            ParkSqlDAL dal = new ParkSqlDAL(DatabaseConnection);
            Park p = dal.GetParkInfo(parkID);

            Console.WriteLine(p);
        }

        public void GetAllCampgrounds()
        {
            CampgroundSqlDAL dal = new CampgroundSqlDAL(DatabaseConnection);
            List<Campground> campgrounds = dal.DisplayAllCampgrounds(parkID);

            if (campgrounds.Count > 0)
            {
                campgrounds.ForEach(c =>
                {
                    Console.WriteLine(c);
                });
            }
            else
            {
                Console.WriteLine("**** NO RESULTS ****");
            }
        }


        //private void SearchReservations()
        //{
        //    int resID = CLIHelper.GetInteger("Please enter the reservation ID you are searching for: ");
        //    ReservationSqlDAL res = new ReservationSqlDAL(DatabaseConnection);
        //    Reservation found = res.FindReservation(resID);

        //    if (found.ReservationID == resID)
        //    {
        //        Console.WriteLine(res);  //reservation details go here
        //    }
        //    else
        //    {
        //        Console.WriteLine("Reservation not found. Please enter a valid ID");
        //    }
        //}

        private void MakeReservations()
        {
            ReservationCLI r = new ReservationCLI(parkID);
            r.Display();
        }


    }
}
