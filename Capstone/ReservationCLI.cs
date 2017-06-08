using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using Capstone.DAL;
using Capstone.Models;

namespace Capstone
{
    public class ReservationCLI
    {
        int parkID;
        readonly string DatabaseConnection = ConfigurationManager.ConnectionStrings["Campground"].ConnectionString;

        public ReservationCLI(int parkID)
        {
            this.parkID = parkID;
        }

        public void Display()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Select Command");
                Console.WriteLine("1] >> Search for Available Reservation");
                Console.WriteLine("2] >> Return to Previous Screen");
                Console.WriteLine("Q] >> Return to Main Menu");

                Console.Write("What option do you want to select? ");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    Console.WriteLine("Searching for an Available Reservation");
                    CampgroundCLI campground = new CampgroundCLI(parkID);
                    campground.GetAllCampgrounds();
                    MakeReservation();
                }
                else if (input == "2")
                {
                    Console.WriteLine("Returning to Previous Screen");
                    break;
                }
                else if (input == "Q")
                {
                    Console.WriteLine("Returning to main menu");
                    break;
                }
                else
                {
                    Console.WriteLine("Please try again");
                }
            }
        }

        private void MakeReservation()
        {
            List<Site> availableSites = new List<Site>();
            int campgroundId = CLIHelper.GetInteger("Which campground would you like to reserve? Enter (0) to cancel. (Provide campground ID)");
            DateTime desiredStartDate = CLIHelper.GetDateTime("What is your desired arrival date?");
            DateTime desiredEndDate = CLIHelper.GetDateTime("What is your desired departure date?");
           if (campgroundId == 0)
            {
                return;
            }
           else
            {
                SiteSqlDAL dal = new SiteSqlDAL(DatabaseConnection);
                List<Site> sites = dal.MakeReservation(campgroundId, desiredStartDate, desiredEndDate);
                if (sites.Count > 0)
                {
                    sites.ForEach(s =>
                    {
                        Console.WriteLine(s);
                    });
                }
                else
                {
                    Console.WriteLine("**** NO RESULTS ****");
                }
            }

        }



        }
}
