using System;
using MySqlConnector;

namespace HotelBookingSystem
{
    public class Customer
    {
        public static int AddCustomer(string name, string phone)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Customers (Name, Phone) VALUES (@name, @phone)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.ExecuteNonQuery();

                long id = cmd.LastInsertedId;
                Console.WriteLine($"✅ Customer added successfully! ID: {id}");
                return (int)id;
            }
        }
    }
}
