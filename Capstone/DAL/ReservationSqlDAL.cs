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
    public class ReservationSqlDAL
    {
        private string connectionString;

        // Single Parameter Constructor
        public ReservationSqlDAL(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Reservation FindReservation(int resID)
        {
            Reservation res = new Reservation();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // open connection
                    conn.Open();

                    // create command object
                    SqlCommand cmd = new SqlCommand($"SELECT * FROM reservation WHERE reservation_id = {resID}", conn);

                    // execute command
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        res.ReservationID = Convert.ToInt32(reader["reservation_id"]);
                        res.SiteID = Convert.ToInt32(reader["site_id"]);
                        res.Name = Convert.ToString(reader["name"]);
                        res.FromDate = Convert.ToDateTime(reader["from_date"]);
                        res.ToDate = Convert.ToDateTime(reader["to_date"]);
                        res.CreateDate = Convert.ToDateTime(reader["create_date"]);
                    }

                    return res;
                }
            }
            catch (SqlException e)
            {
                throw;
            }
        }
        // public bool MakeReservation(int parkId, int campgroundId, DateTime desiredStart, DateTime desiredEnd)
        //{
        //    Reservation r = new Reservation();
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            // open connection
        //            conn.Open();

            //            // create command object
            //            SqlCommand cmd = new SqlCommand($"INSERT INTO reservation VALUES () where site_id = (SELECT site_id FROM reservation WHERE from_date <= {desiredEnd.ToString()} OR to_date >= {desiredStart.ToString()};", conn);

            //            // execute command
            //            int rowsAffected = cmd.ExecuteNonQuery();

            //            return (rowsAffected > 0);
            //        }
            //    }
            //    catch (SqlException e)
            //    {
            //        throw;
            //    }

        }
}

