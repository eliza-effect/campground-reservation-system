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

        public bool MakeReservation(string name, int siteId, DateTime desiredStart, DateTime desiredEnd)
        {
            //Reservation r = new Reservation();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // open connection
                    conn.Open();

                    // create command object

                    SqlCommand cmd = new SqlCommand($"INSERT INTO reservation VALUES ({siteId}, '{name}', '{desiredStart}', '{desiredEnd}', GetDate());", conn);

                    // execute command
                    int rowsAffected = cmd.ExecuteNonQuery();

                    return (rowsAffected > 0);
                }
            }
            catch (SqlException e)
            {
                throw;
            }
        }
    }
}

