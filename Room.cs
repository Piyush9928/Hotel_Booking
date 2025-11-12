using System;
using MySqlConnector;

namespace HotelBookingSystem
{
    public class Room
    {
        public static void AddRoom(string type, decimal price)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Rooms (RoomType, Price, IsAvailable) VALUES (@type, @price, TRUE)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.ExecuteNonQuery();
                Console.WriteLine("✅ Room added successfully!");
            }
        }

        public static void ViewRooms()
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Rooms";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("\n--- Available Rooms ---");
                while (reader.Read())
                {
                    Console.WriteLine($"RoomID: {reader["RoomID"]}, Type: {reader["RoomType"]}, Price: {reader["Price"]}, Available: {reader["IsAvailable"]}");
                }
            }
        }
    }
}
