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
            try
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
            catch(SqlException ex)
            {
                Console.WriteLine("Exception in Admin DisplayTrainDetails Function:"+ex.Message);
            }
        }

        public void ViewBookings()
        {
            try
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
            catch (SqlException ex)
            {
                Console.WriteLine("Exception in View Bookings Function:" + ex.Message);
            }
        }

        public void ViewCancellations()
        {
            try
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
            catch (SqlException ex)
            {
                Console.WriteLine("Exception in View Cancellation Function:" + ex.Message);
            }
        }

        public void AddTrain()
        {
            try
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
                //Console.Write("Enter Train Status (active/inactive): ");
                //string trainStatus = Console.ReadLine();
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
                    cmd.Parameters.AddWithValue("@train_status", "active");
                    cmd.Parameters.AddWithValue("@seats_available", seatsAvailable);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Console.WriteLine("Train added successfully.");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Exception in AddTrain Function:" + ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception Caught:"+ex.Message);
            }
        }

        public void UpdateTrain()
        {
            try
            {
                Console.Write("Enter Train Number to update: ");
                int trainNumber = Convert.ToInt32(Console.ReadLine());

                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();

                    // Check if train is active
                    SqlCommand statusCheckCmd = new SqlCommand("SELECT train_status FROM Trains WHERE tno = @tno", con);
                    statusCheckCmd.Parameters.AddWithValue("@tno", trainNumber);
                    string status = statusCheckCmd.ExecuteScalar()?.ToString();

                    if (status == null)
                    {
                        Console.WriteLine("Train not found.");
                        return;
                    }

                    if (status.ToLower() != "active")
                    {
                        Console.WriteLine("Cannot update. Train status is inactive.");
                        return;
                    }

                    Console.WriteLine("What would you like to update?");
                    Console.WriteLine("1. Train Name");
                    Console.WriteLine("2. From Station");
                    Console.WriteLine("3. Destination Station");
                    Console.WriteLine("4. Price");
                    Console.WriteLine("5. Class of Travel");
                    Console.WriteLine("6. Seats Available");
                    Console.Write("Enter your choice (1-6): ");
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
                            column = "seats_available";
                            Console.Write("Enter new Number of Seats Available: ");
                            newValue = Convert.ToInt32(Console.ReadLine());
                            break;
                        default:
                            Console.WriteLine("Invalid choice.");
                            return;
                    }

                    string query = $"UPDATE Trains SET {column} = @newValue WHERE tno = @tno";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@newValue", newValue);
                    cmd.Parameters.AddWithValue("@tno", trainNumber);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    Console.WriteLine(rowsAffected > 0 ? "Train updated successfully." : "Train update failed.");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Exception in UpdateTrain Function: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Caught: " + ex.Message);
            }
        }


        public void DeleteTrain()
        {
            try
            {
                Console.Write("Enter Train Number to delete: ");
                int trainNumber = Convert.ToInt32(Console.ReadLine());

                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();

                    SqlCommand checkSeatsCmd = new SqlCommand(
                        "SELECT SUM(seats_booked) FROM Bookings WHERE tno = @tno ", con);
                    checkSeatsCmd.Parameters.AddWithValue("@tno", trainNumber);
                    object result = checkSeatsCmd.ExecuteScalar();
                    int seatsBooked = result != DBNull.Value ? Convert.ToInt32(result) : 0;

                    if (seatsBooked > 0)
                    {
                        Console.WriteLine("Cannot delete this train because you have booked seats on it.");
                        return;
                    }


                    SqlCommand updateStatusCmd = new SqlCommand("UPDATE Trains SET train_status = 'inactive' WHERE tno = @tno", con);
                    updateStatusCmd.Parameters.AddWithValue("@tno", trainNumber);
                    updateStatusCmd.ExecuteNonQuery();


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
                        insertCmd.Parameters.AddWithValue("@train_status", "inactive");
                        insertCmd.Parameters.AddWithValue("@seats_available", reader["seats_available"]);
                        insertCmd.Parameters.AddWithValue("@deleted_on", DateTime.Now);
                        reader.Close();
                        insertCmd.ExecuteNonQuery();

                        Console.WriteLine("Train status set to inactive and archived successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Train not found.");
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Exception in DeleteTrain Function:" + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Caught:" + ex.Message);
            }
        }



        public void ViewDeletedTrains()
        {
            try
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
            catch (SqlException ex)
            {
                Console.WriteLine("Exception in  ViewDeletedTrains Function:" + ex.Message);
            }
        }

        public void ViewAndRestoreDeletedTrains()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM DeletedTrains", con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    Console.WriteLine("\nDeleted Trains:");
                    Console.WriteLine("--------------------------------------------------");
                    List<int> trainNumbers = new List<int>();
                    while (reader.Read())
                    {
                        int tno = (int)reader["tno"];
                        trainNumbers.Add(tno);
                        Console.WriteLine($"Train No: {reader["tno"]}, Name: {reader["tname"]}, From: {reader["from"]}, To: {reader["dest"]}, Price: {reader["price"]}, Class: {reader["class_of_travel"]}, Status: {reader["train_status"]}, Seats: {reader["seats_available"]}, Deleted On: {reader["deleted_on"]}");
                    }
                    reader.Close();
                    Console.WriteLine("--------------------------------------------------\n");

                    if (trainNumbers.Count == 0)
                    {
                        Console.WriteLine("No deleted trains found.");
                        return;
                    }

                    Console.Write("Enter Train Number to restore to active status (or 0 to cancel): ");
                    int selectedTrain = Convert.ToInt32(Console.ReadLine());

                    if (selectedTrain == 0 || !trainNumbers.Contains(selectedTrain))
                    {
                        Console.WriteLine("No train restored.");
                        return;
                    }

                    SqlCommand updateCmd = new SqlCommand("UPDATE Trains SET train_status = 'active' WHERE tno = @tno", con);
                    updateCmd.Parameters.AddWithValue("@tno", selectedTrain);
                    int rowsAffected = updateCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        SqlCommand deleteCmd = new SqlCommand("DELETE FROM DeletedTrains WHERE tno = @tno", con);
                        deleteCmd.Parameters.AddWithValue("@tno", selectedTrain);
                        deleteCmd.ExecuteNonQuery();

                        Console.WriteLine("Train status updated to active and removed from DeletedTrains.");
                    }
                    else
                    {
                        Console.WriteLine("Failed to update train status.");
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Exception in ViewAndRestoreDeletedTrains Function:" + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Caught:" + ex.Message);
            }
        }

    }
}