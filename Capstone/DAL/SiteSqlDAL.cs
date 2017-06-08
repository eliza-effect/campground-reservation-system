using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Capstone.DAL;
using Capstone.Models;

namespace Capstone.DAL
{
    public class SiteSqlDAL
    {
        private string connectionString;

        // Single Parameter Constructor
        public SiteSqlDAL(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        public List<Site> MakeReservation(int campgroundId, DateTime desiredStart, DateTime desiredEnd)
        {
            List<Site> siteList = new List<Site>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // open connection
                    conn.Open();

                    // create command object
                    SqlCommand cmd = new SqlCommand($"SELECT * from site where campground_id = {campgroundId} and site_id = (SELECT site_id FROM reservation WHERE from_date <= {desiredEnd.ToString()} OR to_date >= {desiredStart.ToString()};", conn);

                    // execute command
                    int rowsAffected = cmd.ExecuteNonQuery();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Site site = new Site();
                        site.SiteID = Convert.ToInt32(reader["site_id"]);
                        site.CampgroundID = campgroundId;
                        site.SiteNumber = Convert.ToInt32(reader["site_number"]);
                        site.MaxOccupancy = Convert.ToInt32(reader["max_occupancy"]);
                        site.Accessible = Convert.ToBoolean(reader["accessible"]);
                        site.MaxRVLength = Convert.ToInt32(reader["max_rv_length"]);
                        site.Utilities = Convert.ToBoolean(reader["utilities"]);
                        siteList.Add(site);
                    }
                }
            }
            catch (SqlException e)
            {
                throw;
            }
            return siteList;

        }
    }
}
