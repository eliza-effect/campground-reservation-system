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
        private decimal dailyFee = 0.00M;

        // Single Parameter Constructor
        public SiteSqlDAL(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public decimal GetFee(DateTime desiredStart, DateTime desiredEnd)
        {
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

                    //SqlCommand cmd = new SqlCommand($"SELECT site.* FROM site INNER JOIN reservation ON reservation.site_id = site.site_id WHERE (site.campground_id = {campgroundId} AND (reservation.from_date >= '{desiredEnd.ToString()}' OR reservation.to_date <= '{desiredStart.ToString()}'));", conn);
                    SqlCommand cmd = new SqlCommand($"SELECT TOP 5 site.*, campground.daily_fee FROM site INNER JOIN reservation ON reservation.site_id = site.site_id INNER JOIN campground on campground.campground_id = site.campground_id WHERE (site.campground_id = {campgroundId} AND (reservation.from_date > '{desiredEnd.ToString()}' OR reservation.to_date < '{desiredStart.ToString()}')) ORDER BY site_id;", conn);


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
                        temp.DailyFee = Convert.ToDecimal(reader["daily_fee"]);
                        siteList.Add(site);
                    }
                    dailyFee = temp.DailyFee;
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
