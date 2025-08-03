using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Miniproject
{
    class Program
    {

        static string connectionString = "data source = ICS-LT-10Z3D64\\SQLEXPRESS; initial catalog = MiniProject; User ID = sa; Password = Dineshkapu@180703";

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Welcome to the Railway Reservation System");
                Console.WriteLine("1. Login as Admin");
                Console.WriteLine("2. Login as User");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1) Login("admin");
                else if (choice == 2) Login("user");
                else if (choice == 3) break;
                else Console.WriteLine("Invalid choice. Try again.");
            }
        }

        static void Login(string expectedRole)
        {
            Console.Write($"Enter {expectedRole} username: ");
            string username = Console.ReadLine().ToLower();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            var (userid, role) = AuthenticateUser(username, password);
            if (role == "admin")
            {
                Console.WriteLine($"Login successful. Welcome, {username} (Admin) | User ID: {userid}");
                AdminMenu();
            }
            else if (role == "user")
            {
                Console.WriteLine($"Login successful. Welcome, {username} (User) | User ID: {userid}");
                UserMenu(userid.Value); // Pass userid to UserMenu
            }
            else
            {
                Console.WriteLine("Invalid username, password, or role.");
            }

        }

        static (int?, string) AuthenticateUser(string username, string password)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT userid, roles FROM Users WHERE username = @username AND password = @password", con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int userid = (int)reader["userid"];
                    string role = reader["roles"].ToString();
                    return (userid, role);
                }
                else
                {
                    return (null, null);
                }
            }
        }

        static void DisplayTrainDetails()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
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


        static void AdminMenu()
        {
            DisplayTrainDetails();
            while (true)
            {
                Console.WriteLine("\nAdmin Menu");
                Console.WriteLine("1. View Bookings");
                Console.WriteLine("2. View Cancellations");
                Console.WriteLine("3. Add Train");
                Console.WriteLine("4. Update Train");
                Console.WriteLine("5. Delete Train");
                Console.WriteLine("6. View Deleted Trains");
                Console.WriteLine("7. Logout");
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1: ViewBookings(); break;
                    case 2: ViewCancellations(); break;
                    case 3: AddTrain(); break;
                    case 4: UpdateTrain(); break;
                    case 5: DeleteTrain(); break;
                    case 6: ViewDeletedTrains(); break;
                    case 7: return;
                    default: Console.WriteLine("Invalid choice."); break;
                }
            }
        }

        static void UserMenu(int userid)
        {
            DisplayTrainDetails(); // Show trains after login

            while (true)
            {
                Console.WriteLine("\nUser Menu");
                Console.WriteLine("1. Book Tickets");
                Console.WriteLine("2. Cancel Tickets");
                Console.WriteLine("3. Logout");
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1: BookTickets(userid); break;
                    case 2: CancelTickets(); break;
                    case 3: return;
                    default: Console.WriteLine("Invalid choice."); break;
                }
            }
        }


        static void ViewBookings()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
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

        static void ViewCancellations()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
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

        static void AddTrain()
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

            using (SqlConnection con = new SqlConnection(connectionString))
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


        static void UpdateTrain()
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

            using (SqlConnection con = new SqlConnection(connectionString))
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

        static void DeleteTrain()
        {
            Console.Write("Enter Train Number to delete: ");
            int trainNumber = Convert.ToInt32(Console.ReadLine());

            using (SqlConnection con = new SqlConnection(connectionString))
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

        static void ViewDeletedTrains()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
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

        static void BookTickets(int userid)
        {
            Console.Write("Enter Train Number: ");
            int trainNumber = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter number of seats to book (max 3): ");
            int seatsToBook = Convert.ToInt32(Console.ReadLine());

            if (seatsToBook > 3)
            {
                Console.WriteLine("Cannot book more than 3 seats at a time.");
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand checkCmd = new SqlCommand("SELECT seats_available FROM Trains WHERE tno = @tno AND train_status = 'active'", con);
                checkCmd.Parameters.AddWithValue("@tno", trainNumber);
                SqlDataReader reader = checkCmd.ExecuteReader();

                if (reader.Read())
                {
                    int seatsAvailable = (int)reader["seats_available"];
                    reader.Close();

                    if (seatsAvailable < seatsToBook)
                    {
                        Console.WriteLine("Not enough seats available.");
                        return;
                    }

                    SqlCommand bookCmd = new SqlCommand("INSERT INTO Bookings (tno, userid, seats_booked, booking_date) VALUES (@tno, @userid, @seats_booked, @booking_date)", con);
                    bookCmd.Parameters.AddWithValue("@tno", trainNumber);
                    bookCmd.Parameters.AddWithValue("@userid", userid);
                    bookCmd.Parameters.AddWithValue("@seats_booked", seatsToBook);
                    bookCmd.Parameters.AddWithValue("@booking_date", DateTime.Now);
                    bookCmd.ExecuteNonQuery();

                    SqlCommand updateCmd = new SqlCommand("UPDATE Trains SET seats_available = seats_available - @seats_booked WHERE tno = @tno", con);
                    updateCmd.Parameters.AddWithValue("@seats_booked", seatsToBook);
                    updateCmd.Parameters.AddWithValue("@tno", trainNumber);
                    updateCmd.ExecuteNonQuery();

                    Console.WriteLine("Booking successful.");

                    // Show booking details
                    SqlCommand lastBookingCmd = new SqlCommand("SELECT TOP 1 * FROM Bookings WHERE userid = @userid ORDER BY booking_id DESC", con);
                    lastBookingCmd.Parameters.AddWithValue("@userid", userid);
                    SqlDataReader bookingReader = lastBookingCmd.ExecuteReader();

                    if (bookingReader.Read())
                    {
                        Console.WriteLine("\nBooking Details:");
                        Console.WriteLine($"Booking ID: {bookingReader["booking_id"]}");
                        Console.WriteLine($"Train No: {bookingReader["tno"]}");
                        Console.WriteLine($"User ID: {bookingReader["userid"]}");
                        Console.WriteLine($"Seats Booked: {bookingReader["seats_booked"]}");
                        Console.WriteLine($"Booking Date: {bookingReader["booking_date"]}");
                    }
                    bookingReader.Close();
                }
                else
                {
                    Console.WriteLine("Train not found or inactive.");
                }
            }
        }


        static void CancelTickets()
        {
            Console.Write("Enter Booking ID: ");
            int bookingId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter number of seats to cancel: ");
            int seatsToCancel = Convert.ToInt32(Console.ReadLine());

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand checkCmd = new SqlCommand("SELECT tno, seats_booked, booking_date FROM Bookings WHERE booking_id = @booking_id", con);
                checkCmd.Parameters.AddWithValue("@booking_id", bookingId);
                SqlDataReader reader = checkCmd.ExecuteReader();

                if (reader.Read())
                {
                    int trainNumber = (int)reader["tno"];
                    int seatsBooked = (int)reader["seats_booked"];
                    DateTime bookingDate = (DateTime)reader["booking_date"];
                    reader.Close();

                    if (seatsToCancel > seatsBooked)
                    {
                        Console.WriteLine("Cannot cancel more seats than booked.");
                        return;
                    }

                    TimeSpan timeBeforeTravel = bookingDate - DateTime.Now;
                    decimal refundRate = 0;
                    if (timeBeforeTravel.TotalDays > 90) refundRate = 0.50m;
                    else if (timeBeforeTravel.TotalDays > 30) refundRate = 0.25m;
                    else refundRate = 0.00m;

                    decimal refundAmount = seatsToCancel * refundRate * 100;

                    SqlCommand cancelCmd = new SqlCommand("INSERT INTO Cancellations (booking_id, seats_cancelled, cancellation_date) VALUES (@booking_id, @seats_cancelled, @cancellation_date)", con);
                    cancelCmd.Parameters.AddWithValue("@booking_id", bookingId);
                    cancelCmd.Parameters.AddWithValue("@seats_cancelled", seatsToCancel);
                    cancelCmd.Parameters.AddWithValue("@cancellation_date", DateTime.Now);
                    cancelCmd.ExecuteNonQuery();

                    SqlCommand updateTrainCmd = new SqlCommand("UPDATE Trains SET seats_available = seats_available + @seats_cancelled WHERE tno = @tno", con);
                    updateTrainCmd.Parameters.AddWithValue("@seats_cancelled", seatsToCancel);
                    updateTrainCmd.Parameters.AddWithValue("@tno", trainNumber);
                    updateTrainCmd.ExecuteNonQuery();

                    SqlCommand updateBookingCmd = new SqlCommand("UPDATE Bookings SET seats_booked = seats_booked - @seats_cancelled WHERE booking_id = @booking_id", con);
                    updateBookingCmd.Parameters.AddWithValue("@seats_cancelled", seatsToCancel);
                    updateBookingCmd.Parameters.AddWithValue("@booking_id", bookingId);
                    updateBookingCmd.ExecuteNonQuery();

                    Console.WriteLine($"Cancellation successful. Refund Amount: {refundAmount}");
                }
                else Console.WriteLine("Booking not found.");
            }
        }
    }
}
