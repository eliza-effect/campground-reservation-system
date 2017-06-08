using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone
{
    public class ReservationCLI
    {
        public void Display()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("SubMenu 1");
                Console.WriteLine("1] >> Submenu Option 1");
                Console.WriteLine("2] >> Submenu Option 2");
                Console.WriteLine("Q] >> Return to Main Menu");

                Console.Write("What option do you want to select? ");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    Console.WriteLine("Performing submenu option 1");
                }
                else if (input == "2")
                {
                    Console.WriteLine("Performing submenu option 2");
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

        //private void MakeReservation()
        //{
        //    int campgroundId = CLIHelper.GetInteger("Which campground would you like to reserve? (Provide campground ID)");
        //    DateTime desiredStartDate = CLIHelper.GetDateTime("What is your desired arrival date?");
        //    DateTime desiredEndDate = CLIHelper.GetDateTime("What is your desired departure date?");

        //    Site s = new Site
        //    {
        //        CampgroundID = campgroundId


        //    };
        //    Reservation res = new Reservation();



        //    ReservationSqlDAL resIO = new ReservationSqlDAL(DatabaseConnection);
        //    //{
            //    Id = departmentId,
            //    Name = updatedName
            //};
            //DepartmentSqlDAL dal = new DepartmentSqlDAL(DatabaseConnection);
            //bool result = dal.UpdateDepartment(updatedDepartment);

            //if (result)
            //{
            //    Console.WriteLine("*** SUCCESS ***");
            //}
            //else
            //{
            //    Console.WriteLine("*** DID NOT UPDATE ***");
            //}
        //}
    }
}
