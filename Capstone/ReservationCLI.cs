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
                else
                {
                    Console.WriteLine("Please try again");
                }
            }
        }

        private void MakeReservation()
        {
            List<Site> availableSites = new List<Site>();
            int campgroundId = CLIHelper.GetInteger("Which campground (ID number) would you like to reserve? Enter (0) to cancel.");

            if (campgroundId == 0)
            {
                return;
            }

            DateTime desiredStartDate = CLIHelper.GetDateTime("What is your desired arrival date? (__/__/____)");
            DateTime desiredEndDate = CLIHelper.GetDateTime("What is your desired departure date? (__/__/____)");

            SiteSqlDAL dal = new SiteSqlDAL(DatabaseConnection);
            List<Site> sites = dal.SearchReservation(campgroundId, desiredStartDate, desiredEndDate);

            decimal totalFee = dal.GetFee(campgroundId, desiredStartDate, desiredEndDate);

            if (sites.Count > 0)
            {
                Console.WriteLine("Results Matching Your Search Criteria");
                Console.WriteLine("Site No.".PadRight(10) + "Max. Occup.".PadRight(15) + "Accessible?".PadRight(15) + "Max. RV Length".PadRight(15) + "Utility".PadRight(15) + "Cost");

                sites.ForEach(s =>
                {
                    Console.WriteLine(s + "    $" + Math.Round(totalFee, 2));
                });
            }
            else
            {
                Console.WriteLine("**** NO RESULTS ****");
                return;
            }

            int siteNumber = CLIHelper.GetInteger("Which site would you like to reserve? (Enter 0 to cancel)");
            int tempSiteID = 0;

            sites.ForEach(s =>
            {
                if (s.SiteNumber == siteNumber)
                {
                    tempSiteID = s.SiteID;
                }
            });

            if (siteNumber == 0)
            {
                return;
            }

            string reservationName = CLIHelper.GetString("What name should the reservation be made under?");

            ReservationSqlDAL res = new ReservationSqlDAL(DatabaseConnection);
            bool result = res.MakeReservation(reservationName, tempSiteID, desiredStartDate, desiredEndDate);

            if (result)
            {
                Console.WriteLine($"Your reservation has been created under the name {reservationName}.");
            }
            else
            {
                Console.WriteLine("Error. Reservation not created. Please try again.");
            }
        }
    }
}

