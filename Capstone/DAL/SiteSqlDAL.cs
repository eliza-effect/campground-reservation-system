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

        public decimal GetFee(int campgroundId, DateTime desiredStart, DateTime desiredEnd)
        {
            decimal dailyFee = 0.00M;
            try
            {
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    // open connection
                    connect.Open();

                    // create command object

                    SqlCommand cmd2 = new SqlCommand($"SELECT daily_fee FROM campground WHERE campground_id = @campground_id;", connect);
                    cmd2.Parameters.AddWithValue("@campground_id", campgroundId);

                    // execute
                    SqlDataReader reader2 = cmd2.ExecuteReader();

                    if (reader2.Read())
                    {
                        dailyFee = Convert.ToDecimal(reader2["daily_fee"]);
                    }
                }
            }
            catch (SqlException e)
            {
                throw;
            }
            return dailyFee * (decimal)((desiredEnd - desiredStart).TotalDays);
        }



        public List<Site> SearchReservation(int campgroundId, DateTime desiredStart, DateTime desiredEnd)
        {
            List<Site> siteList = new List<Site>();
            Campground temp = new Campground();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // open connection
                    conn.Open();

                    // create command object

                   SqlCommand cmd = new SqlCommand($"SELECT TOP 5 site.* FROM site WHERE (site.campground_id = @campground_id AND site.site_id NOT IN (SELECT reservation.site_id FROM reservation WHERE from_date BETWEEN @start AND @end OR to_date BETWEEN @start and @end OR (from_date > @start AND to_date < @end))) ORDER BY site.site_id;", conn);
                    cmd.Parameters.AddWithValue("@campground_id", campgroundId);
                    cmd.Parameters.AddWithValue("@start", desiredStart);
                    cmd.Parameters.AddWithValue("@end", desiredEnd);


                    // execute command
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
