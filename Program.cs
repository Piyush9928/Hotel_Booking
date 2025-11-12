using System;

namespace HotelBookingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine("\n--- Hotel Booking System ---");
                Console.WriteLine("1. Add Room");
                Console.WriteLine("2. View Rooms");
                Console.WriteLine("3. Add Customer");
                Console.WriteLine("4. Book Room");
                Console.WriteLine("5. View Bookings");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Room Type: ");
                        string type = Console.ReadLine();
                        Console.Write("Enter Price: ");
                        decimal price = Convert.ToDecimal(Console.ReadLine());
                        Room.AddRoom(type, price);
                        break;

                    case 2:
                        Room.ViewRooms();
                        break;

                    case 3:
                        Console.Write("Enter Customer Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Phone: ");
                        string phone = Console.ReadLine();
                        Customer.AddCustomer(name, phone);
                        break;

                    case 4:
                        Console.Write("Enter Room ID: ");
                        int roomId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Customer ID: ");
                        int custId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Check-In Date (yyyy-mm-dd): ");
                        DateTime inDate = Convert.ToDateTime(Console.ReadLine());
                        Console.Write("Enter Check-Out Date (yyyy-mm-dd): ");
                        DateTime outDate = Convert.ToDateTime(Console.ReadLine());
                        Booking.BookRoom(roomId, custId, inDate, outDate);
                        break;

                    case 5:
                        Booking.ViewBookings();
                        break;

                    case 6:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            } while (choice != 6);
        }
    }
}
