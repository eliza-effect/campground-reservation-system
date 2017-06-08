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
    public class CampgroundSqlDAL
    {
        private string connectionString;

        // Single Parameter Constructor
        public CampgroundSqlDAL(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<Campground> DisplayAllCampgrounds(int parkId)
        {
            List<Campground> allCampgrounds = new List<Campground>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // open connection
                    conn.Open();

                    // create command object
                    SqlCommand cmd = new SqlCommand($"SELECT * FROM campground where park_id = {parkId};", conn);

                    // execute command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // populate list

                    while (reader.Read())
                    {
                        //read in value, reference by index or column name
                        Campground c = new Campground();
                        c.CampgroundID = Convert.ToInt32(reader["campground_id"]);
                        c.ParkID = parkId;
                        c.Name = Convert.ToString(reader["name"]);
                        c.OpenFrom = Convert.ToInt32(reader["open_from_mm"]);
                        c.OpenTo = Convert.ToInt32(reader["open_to_mm"]);
                        c.DailyFee = Convert.ToDecimal(reader["daily_fee"]);
                      


                        allCampgrounds.Add(c);
                    }

                }
            }
            catch (SqlException e)
            {
                throw;
            }

            return allCampgrounds;

        }

    }
}
