using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.DAL;
using Capstone.Models;
using System.Data.SqlClient;

namespace Capstone.DAL
{
    public class ParkSqlDAL
    {
        private string connectionString;

        // Single Parameter Constructor
        public ParkSqlDAL(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Park GetParkInfo(int parkID)
        {

            Park p = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // open connection
                    conn.Open();

                    // create command object
                    SqlCommand cmd = new SqlCommand($"SELECT * FROM park WHERE park_id = {parkID};", conn);

                    // execute command
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        p = new Park();
                        p.ParkID = Convert.ToInt32(reader["park_id"]);
                        p.Name = Convert.ToString(reader["name"]);
                        p.Location = Convert.ToString(reader["location"]);
                        p.EstablishDate = Convert.ToDateTime(reader["establish_date"]);
                        p.Area = Convert.ToInt32(reader["area"]);
                        p.Visitors = Convert.ToInt32(reader["visitors"]);
                        p.Description = Convert.ToString(reader["description"]);
                    }
                }

            }
            catch (SqlException e)
            {
                throw;
            }

            return p;

        }


        public List<Park> GetParks()
        {
            List<Park> allParks = new List<Park>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // open connection
                    conn.Open();

                    // create command object
                    SqlCommand cmd = new SqlCommand("SELECT * FROM park;", conn);

                    // execute command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // populate list

                    while (reader.Read())
                    {
                        Park p = new Park();
                        p.ParkID = Convert.ToInt32(reader["park_id"]);
                        p.Name = Convert.ToString(reader["name"]);
                        p.Location = Convert.ToString(reader["location"]);
                        p.EstablishDate = Convert.ToDateTime(reader["establish_date"]);
                        p.Area = Convert.ToInt32(reader["area"]);
                        p.Visitors = Convert.ToInt32(reader["visitors"]);
                        p.Description = Convert.ToString(reader["description"]);


                        allParks.Add(p);
                    }

                }
            }
            catch (SqlException e)
            {
                throw;
            }

            return allParks;

        }
    }
}
