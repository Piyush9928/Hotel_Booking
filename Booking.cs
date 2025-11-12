using System;
using MySqlConnector;

namespace HotelBookingSystem
{
    public class Booking
    {
        public static void BookRoom(int roomId, int customerId, DateTime checkIn, DateTime checkOut)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string checkAvailability = "SELECT IsAvailable FROM Rooms WHERE RoomID=@id";
                MySqlCommand checkCmd = new MySqlCommand(checkAvailability, conn);
                checkCmd.Parameters.AddWithValue("@id", roomId);
                object result = checkCmd.ExecuteScalar();

                if (result == null || !(bool)result)
                {
                    Console.WriteLine("❌ Room not available!");
                    return;
                }

                string insertBooking = "INSERT INTO Bookings (RoomID, CustomerID, CheckInDate, CheckOutDate) VALUES (@room, @cust, @in, @out)";
                MySqlCommand cmd = new MySqlCommand(insertBooking, conn);
                cmd.Parameters.AddWithValue("@room", roomId);
                cmd.Parameters.AddWithValue("@cust", customerId);
                cmd.Parameters.AddWithValue("@in", checkIn);
                cmd.Parameters.AddWithValue("@out", checkOut);
                cmd.ExecuteNonQuery();

                string updateRoom = "UPDATE Rooms SET IsAvailable=FALSE WHERE RoomID=@id";
                MySqlCommand updateCmd = new MySqlCommand(updateRoom, conn);
                updateCmd.Parameters.AddWithValue("@id", roomId);
                updateCmd.ExecuteNonQuery();

                Console.WriteLine("✅ Room booked successfully!");
            }
        }

        public static void ViewBookings()
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"SELECT b.BookingID, c.Name, r.RoomType, b.CheckInDate, b.CheckOutDate 
                                 FROM Bookings b 
                                 JOIN Customers c ON b.CustomerID = c.CustomerID 
                                 JOIN Rooms r ON b.RoomID = r.RoomID";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("\n--- Current Bookings ---");
                while (reader.Read())
                {
                    Console.WriteLine($"BookingID: {reader["BookingID"]}, Customer: {reader["Name"]}, Room: {reader["RoomType"]}, From: {reader["CheckInDate"]}, To: {reader["CheckOutDate"]}");
                }
            }
        }
    }
}
