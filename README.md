# 🏨 Hotel Booking System (C# + MySQL)

A **Hotel Booking Management System** built using **C# (.NET)** and **MySQL**.  
This console-based project helps hotels manage **rooms, customers, and bookings** efficiently.

---

## 🚀 Features

✅ Add new rooms (type, price, availability)  
✅ Register new customers  
✅ Book rooms for customers  
✅ View current bookings  
✅ Cancel or manage room availability  
✅ MySQL database integration  

---

## 🧱 Project Structure

```
HotelBookingSystem/
 ┣ 📄 Program.cs
 ┣ 📄 DatabaseHelper.cs
 ┣ 📄 Room.cs
 ┣ 📄 Customer.cs
 ┣ 📄 Booking.cs
 ┣ 📄 README.md
```

---

## ⚙️ Technologies Used

- **C# (.NET 8.0 / .NET Framework)**
- **MySQL**
- **MySql.Data** (NuGet package)
- **Visual Studio / VS Code**

---

## 🧩 Database Setup (MySQL)

Run the following script in MySQL Workbench or phpMyAdmin:

```sql
CREATE DATABASE hotel_db;
USE hotel_db;

CREATE TABLE Rooms (
    RoomID INT AUTO_INCREMENT PRIMARY KEY,
    RoomType VARCHAR(50),
    Price DECIMAL(10,2),
    IsAvailable BOOLEAN DEFAULT TRUE
);

CREATE TABLE Customers (
    CustomerID INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(100),
    Phone VARCHAR(15)
);

CREATE TABLE Bookings (
    BookingID INT AUTO_INCREMENT PRIMARY KEY,
    RoomID INT,
    CustomerID INT,
    CheckInDate DATE,
    CheckOutDate DATE,
    FOREIGN KEY (RoomID) REFERENCES Rooms(RoomID),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);
```

---

## 🛠️ Setup Instructions

1. Clone or download this repository  
   ```bash
   git clone https://github.com/your-username/HotelBookingSystem.git
   ```
2. Open the project in **Visual Studio** or **VS Code**
3. Install the **MySql.Data** package:
   ```bash
   dotnet add package MySql.Data
   ```
4. Update your MySQL credentials inside `DatabaseHelper.cs`:
   ```csharp
   string connectionString = "server=localhost;database=hotel_db;uid=root;pwd=;";
   ```
5. Build and run the project:
   ```bash
   dotnet run
   ```

---

## 🧠 Usage Menu

```
--- Hotel Booking System ---
1. Add Room
2. View Rooms
3. Add Customer
4. Book Room
5. View Bookings
6. Exit
```

---

## 📸 Preview

🖥️ Console Interface Example:

```
Enter Room Type: Deluxe
Enter Price: 2500
✅ Room added successfully!
```

---

## 📄 License

This project is **open-source** and available under the [MIT License](LICENSE).

---

## 👨‍💻 Developed By

**Piyush Singh**  
🚀 Passionate C# Developer | Data & Software Enthusiast  
📧 Contact: [ps1521155@gmail.com]
🌐 GitHub: [Piyush9928](https://github.com/Piyush9928)
