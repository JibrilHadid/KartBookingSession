using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace KartBookingSession.Repositories
{
    public class StorageManager
    {
        private SqlConnection conn;

        public StorageManager(string connectionString)
        {
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                Console.WriteLine("Coneection successful");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Connection NOT successful\n");
                Console.WriteLine(e.Message);
                throw;
            }

            catch (Exception ex)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(ex.Message);
            }
        }

        public List<Karts> GetAllKarts()
        {
            List<Karts> karts = new List<Karts>();
            string sqlString = "SELECT * FROM booking.KARTS";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {

            }
        }


    }
}
