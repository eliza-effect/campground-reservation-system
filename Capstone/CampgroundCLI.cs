
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
    public class CampgroundCLI
    {
        const string Command_AllParks = "1";
        const string Command_AllCampgrounds = "2";
        const string Command_MakeReservation = "3";
        const string Command_EmployeesWithoutProjects = "4";
        const string Command_ProjectList = "5";
        const string Command_CreateDepartment = "6";
        const string Command_UpdateDepartment = "7";
        const string Command_CreateProject = "8";
        const string Command_AssignEmployeeToProject = "9";
        const string Command_RemoveEmployeeFromProject = "10";
        const string Command_DisplayAssignedProjects = "11";
        const string Command_Quit = "q";
        readonly string DatabaseConnection = ConfigurationManager.ConnectionStrings["Campground"].ConnectionString;

        public void RunCLI()
        {
            PrintHeader();
            PrintMenu();

            while (true)
            {
                string command = Console.ReadLine();

                Console.Clear();

                switch (command.ToLower())
                {
                    case Command_AllParks:
                        GetAllParks();
                        break;

                    case Command_AllCampgrounds:
                        GetAllCampgrounds();
                        break;

                    case Command_MakeReservation:
                        SearchDates();
                        break;

                    case Command_Quit:
                        Console.WriteLine("Thank you for using the campground reservation system");
                        return;

                    default:
                        Console.WriteLine("The command provided was not a valid command, please try again.");
                        break;

                }

                PrintMenu();
            }
        }

        private void GetAllCampgrounds()
        {
            int parkId = CLIHelper.GetInteger("Select park ID to show campgrounds: ");

            CampgroundSqlDAL dal = new CampgroundSqlDAL(DatabaseConnection);
            List<Campground> campgrounds = dal.DisplayAllCampgrounds(parkId);

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

        //private void RemoveEmployeeFromProject()
        //{
        //    int projectId = CLIHelper.GetInteger("Which project id is the employee removed from:");
        //    int employeeId = CLIHelper.GetInteger("Which employee is getting removed:");

        //    ProjectSqlDAL dal = new ProjectSqlDAL(DatabaseConnection);
        //    bool result = dal.RemoveEmployeeFromProject(projectId, employeeId);

        //    if (result)
        //    {
        //        Console.WriteLine("*** SUCCESS ***");
        //    }
        //    else
        //    {
        //        Console.WriteLine("*** DID NOT CREATE ***");
        //    }

        //}

        //private void AssignEmployeeToProject()
        //{
        //    int projectId = CLIHelper.GetInteger("Which project id is the employee getting assigned to:");
        //    int employeeId = CLIHelper.GetInteger("Which employee is getting added:");

        //    ProjectSqlDAL dal = new ProjectSqlDAL(DatabaseConnection);
        //    bool result = dal.AssignEmployeeToProject(projectId, employeeId);

        //    if (result)
        //    {
        //        Console.WriteLine("*** SUCCESS ***");
        //    }
        //    else
        //    {
        //        Console.WriteLine("*** DID NOT CREATE ***");
        //    }
        //}

        //private void CreateProject()
        //{
        //    string projectName = CLIHelper.GetString("Provide a name for the project:");
        //    DateTime startDate = CLIHelper.GetDateTime("Provide a start date for the project:");
        //    DateTime endDate = CLIHelper.GetDateTime("Provide an end date for the project");

        //    Project newProj = new Project()
        //    {
        //        Name = projectName,
        //        StartDate = startDate,
        //        EndDate = endDate
        //    };

        //    ProjectSqlDAL dal = new ProjectSqlDAL(DatabaseConnection);
        //    bool result = dal.CreateProject(newProj);

        //    if (result)
        //    {
        //        Console.WriteLine("*** SUCCESS ***");
        //    }
        //    else
        //    {
        //        Console.WriteLine("*** DID NOT CREATE ***");
        //    }
        //}

        private void SearchDates()
        {
            int campgroundId = CLIHelper.GetInteger("Which campground would you like to reserve? (Provide campground ID)");
            DateTime desiredStartDate = CLIHelper.GetDateTime("What is your desired arrival date?");
            DateTime desiredEndDate = CLIHelper.GetDateTime("What is your desired departure date?");
            
            {
                Id = departmentId,
                Name = updatedName
            };
            DepartmentSqlDAL dal = new DepartmentSqlDAL(DatabaseConnection);
            bool result = dal.UpdateDepartment(updatedDepartment);

            if (result)
            {
                Console.WriteLine("*** SUCCESS ***");
            }
            else
            {
                Console.WriteLine("*** DID NOT UPDATE ***");
            }
        }

        //private void CreateDepartment()
        //{
        //    string departmentName = CLIHelper.GetString("Provide a name for the new department:");
        //    Department newDept = new Department
        //    {
        //        Name = departmentName
        //    };
        //    DepartmentSqlDAL dal = new DepartmentSqlDAL(DatabaseConnection);

        //    bool result = dal.CreateDepartment(newDept);

        //    if (result)
        //    {
        //        Console.WriteLine("*** SUCCESS ***");
        //    }
        //    else
        //    {
        //        Console.WriteLine("*** DID NOT CREATE ***");
        //    }
        //}

        private void GetAllParks()
        {
            ParkSqlDAL pIO = new ParkSqlDAL(DatabaseConnection);
            List<Park> parks = pIO.GetParks();


            if (parks.Count > 0)
            {
                parks.ForEach(p =>
                {
                    Console.WriteLine(p);
                });
            }
            else
            {
                Console.WriteLine("**** NO RESULTS ****");
            }
        }

        //private void GetAllEmployees()
        //{
        //    EmployeeSqlDAL dal = new EmployeeSqlDAL(DatabaseConnection);
        //    List<Employee> employees = dal.GetAllEmployees();

        //    if (employees.Count > 0)
        //    {
        //        employees.ForEach(emp =>
        //        {
        //            Console.WriteLine(emp);
        //        });
        //    }
        //    else
        //    {
        //        Console.WriteLine("**** NO RESULTS ****");
        //    }
        //}

        //private void EmployeeSearch()
        //{
        //    string firstname = CLIHelper.GetString("Enter the first name:");
        //    string lastname = CLIHelper.GetString("Enter the last name:");

        //    EmployeeSqlDAL dal = new EmployeeSqlDAL(DatabaseConnection);
        //    List<Employee> employees = dal.Search(firstname, lastname);

        //    if (employees.Count > 0)
        //    {
        //        employees.ForEach(emp =>
        //        {
        //            Console.WriteLine(emp);
        //        });
        //    }
        //    else
        //    {
        //        Console.WriteLine("**** NO RESULTS ****");
        //    }
        //}

        //private void GetEmployeesWithoutProjects()
        //{
        //    EmployeeSqlDAL dal = new EmployeeSqlDAL(DatabaseConnection);
        //    List<Employee> employees = dal.GetEmployeesWithoutProjects();

        //    if (employees.Count > 0)
        //    {
        //        employees.ForEach(emp =>
        //        {
        //            Console.WriteLine(emp);
        //        });
        //    }
        //    else
        //    {
        //        Console.WriteLine("**** NO RESULTS ****");
        //    }
        //}

        //private void GetAllProjects()
        //{
        //    ProjectSqlDAL dal = new ProjectSqlDAL(DatabaseConnection);
        //    List<Project> projects = dal.GetAllProjects();

        //    if (projects.Count > 0)
        //    {
        //        projects.ForEach(proj =>
        //        {
        //            Console.WriteLine(proj);
        //        });
        //    }
        //    else
        //    {
        //        Console.WriteLine("**** NO RESULTS ****");
        //    }
        //}

        private void PrintHeader()
        {
            Console.WriteLine(@" ______                 _                           _____           _           _       _____  ____  ");
            Console.WriteLine(@"|  ____|               | |                         |  __ \         (_)         | |     |  __ \|  _ \ ");
            Console.WriteLine(@"| |__   _ __ ___  _ __ | | ___  _   _  ___  ___    | |__) | __ ___  _  ___  ___| |_    | |  | | |_) |");
            Console.WriteLine(@"|  __| | '_ ` _ \| '_ \| |/ _ \| | | |/ _ \/ _ \   |  ___/ '__/ _ \| |/ _ \/ __| __|   | |  | |  _ < ");
            Console.WriteLine(@"| |____| | | | | | |_) | | (_) | |_| |  __/  __/   | |   | | | (_) | |  __/ (__| |_    | |__| | |_) |");
            Console.WriteLine(@"|______|_| |_| |_| .__/|_|\___/ \__, |\___|\___|   |_|   |_|  \___/| |\___|\___|\__|   |_____/|____/ ");
            Console.WriteLine(@"                 | |             __/ |                            _/ |                               ");
            Console.WriteLine(@"                 |_|            |___/                            |__/                                ");
            Console.WriteLine();
            Console.WriteLine();
        }

        private void PrintMenu()
        {
            Console.WriteLine("Main Menu Please type in a command");
            Console.WriteLine(" 1 - Show all parks");
            Console.WriteLine(" 2 - Show all campgrounds in the park");

            Console.WriteLine(" Q - Quit");
            Console.WriteLine();

        }

    }
}
