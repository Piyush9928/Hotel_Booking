using MySqlConnector;

namespace HotelBookingSystem
{
    public static class DatabaseHelper
    {
        public static MySqlConnection GetConnection()
        {
            string connectionString = "server=localhost;database=hotel_db;uid=root;pwd=piyush;";
            return new MySqlConnection(connectionString);
        }
    }
}
