using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.DAL
{
    public class SiteSqlDAL
    {
        //private string connectionString;

        //// Single Parameter Constructor
        //public SiteSqlDAL(string dbConnectionString)
        //{
        //    connectionString = dbConnectionString;
        //}

        //public bool MakeReservation(int parkId, int campgroundId, DateTime desiredStart, DateTime desiredEnd)
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
