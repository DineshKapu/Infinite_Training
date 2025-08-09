using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Mini_Project.Services
{
    public class AdminService
    {
        private readonly string _connectionString;

        public AdminService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void DisplayTrainDetails()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Trains", con);
                SqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("\nAvailable Trains:");
                Console.WriteLine("--------------------------------------------------");
                while (reader.Read())
                {
                    Console.WriteLine($"Train No: {reader["tno"]}, Name: {reader["tname"]}, From: {reader["from"]}, To: {reader["dest"]}, Price: {reader["price"]}, Class: {reader["class_of_travel"]}, Status: {reader["train_status"]}, Seats: {reader["seats_available"]}");
                }
                Console.WriteLine("--------------------------------------------------\n");
            }
        }

        public void ViewBookings()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Bookings WHERE deleted = 0", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"Booking ID: {reader["booking_id"]}, Train No: {reader["tno"]}, User ID: {reader["userid"]}, Seats: {reader["seats_booked"]}, Date: {reader["booking_date"]}");
                }
            }
        }

        public void ViewCancellations()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Cancellations WHERE deleted = 0", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"Cancellation ID: {reader["cancellation_id"]}, Booking ID: {reader["booking_id"]}, Seats Cancelled: {reader["seats_cancelled"]}, Date: {reader["cancellation_date"]}");
                }
            }
        }

        public void AddTrain()
        {
            Console.Write("Enter Train Number: ");
            int trainNumber = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Train Name: ");
            string trainName = Console.ReadLine();
            Console.Write("Enter From Station: ");
            string from = Console.ReadLine();
            Console.Write("Enter Destination Station: ");
            string dest = Console.ReadLine();
            Console.Write("Enter Price: ");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.Write("Enter Class of Travel: ");
            string classOfTravel = Console.ReadLine();
            Console.Write("Enter Train Status (active/inactive): ");
            string trainStatus = Console.ReadLine();
            Console.Write("Enter Number of Seats Available: ");
            int seatsAvailable = Convert.ToInt32(Console.ReadLine());

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Trains (tno, tname, [from], dest, price, class_of_travel, train_status, seats_available) VALUES (@tno, @tname, @from, @dest, @price, @class_of_travel, @train_status, @seats_available)", con);
                cmd.Parameters.AddWithValue("@tno", trainNumber);
                cmd.Parameters.AddWithValue("@tname", trainName);
                cmd.Parameters.AddWithValue("@from", from);
                cmd.Parameters.AddWithValue("@dest", dest);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@class_of_travel", classOfTravel);
                cmd.Parameters.AddWithValue("@train_status", trainStatus);
                cmd.Parameters.AddWithValue("@seats_available", seatsAvailable);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Console.WriteLine("Train added successfully.");
            }
        }

        public void UpdateTrain()
        {
            Console.Write("Enter Train Number to update: ");
            int trainNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("What would you like to update?");
            Console.WriteLine("1. Train Name");
            Console.WriteLine("2. From Station");
            Console.WriteLine("3. Destination Station");
            Console.WriteLine("4. Price");
            Console.WriteLine("5. Class of Travel");
            Console.WriteLine("6. Train Status");
            Console.WriteLine("7. Seats Available");
            Console.Write("Enter your choice (1-7): ");
            int choice = Convert.ToInt32(Console.ReadLine());

            string column = "";
            object newValue;

            switch (choice)
            {
                case 1:
                    column = "tname";
                    Console.Write("Enter new Train Name: ");
                    newValue = Console.ReadLine();
                    break;
                case 2:
                    column = "[from]";
                    Console.Write("Enter new From Station: ");
                    newValue = Console.ReadLine();
                    break;
                case 3:
                    column = "dest";
                    Console.Write("Enter new Destination Station: ");
                    newValue = Console.ReadLine();
                    break;
                case 4:
                    column = "price";
                    Console.Write("Enter new Price: ");
                    newValue = decimal.Parse(Console.ReadLine());
                    break;
                case 5:
                    column = "class_of_travel";
                    Console.Write("Enter new Class of Travel: ");
                    newValue = Console.ReadLine();
                    break;
                case 6:
                    column = "train_status";
                    Console.Write("Enter new Train Status (active/inactive): ");
                    newValue = Console.ReadLine();
                    break;
                case 7:
                    column = "seats_available";
                    Console.Write("Enter new Number of Seats Available: ");
                    newValue = Convert.ToInt32(Console.ReadLine());
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    return;
            }

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = $"UPDATE Trains SET {column} = @newValue WHERE tno = @tno";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@newValue", newValue);
                cmd.Parameters.AddWithValue("@tno", trainNumber);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                Console.WriteLine(rowsAffected > 0 ? "Train updated successfully." : "Train update failed.");
            }
        }

        public void DeleteTrain()
        {
            Console.Write("Enter Train Number to delete: ");
            int trainNumber = Convert.ToInt32(Console.ReadLine());

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand fetchCmd = new SqlCommand("SELECT * FROM Trains WHERE tno = @tno", con);
                fetchCmd.Parameters.AddWithValue("@tno", trainNumber);
                SqlDataReader reader = fetchCmd.ExecuteReader();

                if (reader.Read())
                {
                    SqlCommand insertCmd = new SqlCommand("INSERT INTO DeletedTrains (tno, tname, [from], dest, price, class_of_travel, train_status, seats_available, deleted_on) VALUES (@tno, @tname, @from, @dest, @price, @class_of_travel, @train_status, @seats_available, @deleted_on)", con);
                    insertCmd.Parameters.AddWithValue("@tno", reader["tno"]);
                    insertCmd.Parameters.AddWithValue("@tname", reader["tname"]);
                    insertCmd.Parameters.AddWithValue("@from", reader["from"]);
                    insertCmd.Parameters.AddWithValue("@dest", reader["dest"]);
                    insertCmd.Parameters.AddWithValue("@price", reader["price"]);
                    insertCmd.Parameters.AddWithValue("@class_of_travel", reader["class_of_travel"]);
                    insertCmd.Parameters.AddWithValue("@train_status", reader["train_status"]);
                    insertCmd.Parameters.AddWithValue("@seats_available", reader["seats_available"]);
                    insertCmd.Parameters.AddWithValue("@deleted_on", DateTime.Now);
                    reader.Close();
                    insertCmd.ExecuteNonQuery();
                    SqlCommand deleteCmd = new SqlCommand("DELETE FROM Trains WHERE tno = @tno", con);
                    deleteCmd.Parameters.AddWithValue("@tno", trainNumber);
                    deleteCmd.ExecuteNonQuery();
                    Console.WriteLine("Train deleted and archived successfully.");
                }
                else
                {
                    Console.WriteLine("Train not found.");
                }
            }
        }

        public void ViewDeletedTrains()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM DeletedTrains", con);
                SqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("\nDeleted Trains:");
                Console.WriteLine("--------------------------------------------------");
                while (reader.Read())
                {
                    Console.WriteLine($"Train No: {reader["tno"]}, Name: {reader["tname"]}, From: {reader["from"]}, To: {reader["dest"]}, Price: {reader["price"]}, Class: {reader["class_of_travel"]}, Status: {reader["train_status"]}, Seats: {reader["seats_available"]}, Deleted On: {reader["deleted_on"]}");
                }
                Console.WriteLine("--------------------------------------------------\n");
            }
        }
    }
}
