using KartBookingSession.Repositories;

namespace KartBookingSession
{
    public class Program
    {
        private static StorageManager storageManager;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=KartBookingSession;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";


            storageManager = new StorageManager
                (connectionString);
        }
    }
}
