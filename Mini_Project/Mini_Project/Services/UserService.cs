using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Mini_Project.Services
{
    public class UserService
    {
        private readonly string _connectionString;

        public UserService(string connectionString)
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
                Console.WriteLine("Exception in User Display Train Details Function:"+ex.Message);
            }
        }

        public void BookTickets(int userid)
        {
            try
            {
                Console.Write("Enter Train Number: ");
                int trainNumber = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter The  Date of Travel(yyyy-mm-dd):");
                string date = Console.ReadLine();
                if (DateTime.Parse(date) < DateTime.Now)
                {
                    Console.WriteLine("You Cannot Enter past Date");
                    return;
                }
                Console.Write("Enter number of seats to book (max 3): ");
                int seatsToBook = Convert.ToInt32(Console.ReadLine());
                if (seatsToBook > 3)
                {
                    Console.WriteLine("Cannot book more than 3 seats at a time.");
                    return;
                }

                using (SqlConnection con = new SqlConnection(_connectionString))
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
                        SqlCommand getPrice = new SqlCommand("select price from Trains where tno=@tno", con);
                        getPrice.Parameters.AddWithValue("@tno", trainNumber);
                        float price = Convert.ToSingle(getPrice.ExecuteScalar());
                        float totalamount = price * seatsToBook;
                        SqlCommand bookCmd = new SqlCommand("INSERT INTO Bookings (tno, userid, seats_booked, booking_date,total_amount) VALUES (@tno, @userid, @seats_booked, @booking_date,@total_amount)", con);
                        bookCmd.Parameters.AddWithValue("@tno", trainNumber);
                        bookCmd.Parameters.AddWithValue("@userid", userid);
                        bookCmd.Parameters.AddWithValue("@seats_booked", seatsToBook);
                        bookCmd.Parameters.AddWithValue("@booking_date", DateTime.Parse(date));
                        bookCmd.Parameters.AddWithValue("@total_amount", totalamount);
                        bookCmd.ExecuteNonQuery();

                        SqlCommand updateCmd = new SqlCommand("UPDATE Trains SET seats_available = seats_available - @seats_booked WHERE tno = @tno", con);
                        updateCmd.Parameters.AddWithValue("@seats_booked", seatsToBook);
                        updateCmd.Parameters.AddWithValue("@tno", trainNumber);
                        updateCmd.ExecuteNonQuery();

                        Console.WriteLine("Booking successful.");

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
                            Console.WriteLine($"Date of Travel: {bookingReader["booking_date"]}");
                            Console.WriteLine($"Total Amount: {bookingReader["total_amount"]}");
                        }
                        bookingReader.Close();
                    }
                    else
                    {
                        Console.WriteLine("Train not found or inactive.");
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Exception in Book Details Function:" + ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception Caught:"+ex.Message);
            }
        }

        public void CancelTickets(int userid)
        {
            try
            {
                Console.Write("Enter Booking ID: ");
                int bookingId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter number of seats to cancel: ");
                int seatsToCancel = Convert.ToInt32(Console.ReadLine());

                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    SqlCommand checkCmd = new SqlCommand("SELECT tno, seats_booked, booking_date FROM Bookings WHERE booking_id = @booking_id and userid=@userid", con);
                    checkCmd.Parameters.AddWithValue("@booking_id", bookingId);
                    checkCmd.Parameters.AddWithValue("@userid", userid);
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

                        SqlCommand getPrice = new SqlCommand("select price from Trains where tno=@tno", con);
                        getPrice.Parameters.AddWithValue("@tno", trainNumber);
                        float ticketprice = Convert.ToSingle(getPrice.ExecuteScalar());
                        TimeSpan timeBeforeTravel = bookingDate - DateTime.Now;
                        float refundRate = 0;
                        if (timeBeforeTravel.TotalDays > 90) refundRate = 0.50f;
                        else if (timeBeforeTravel.TotalDays > 30) refundRate = 0.25f;
                        else refundRate = 0.00f;
                        float refundAmount = ticketprice * refundRate * seatsToCancel;

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
                    else
                    {
                        Console.WriteLine("Booking not found.");
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Exception in Cancel Ticket Function:" + ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception Caught:",ex.Message);
            }
        }
        public void ViewMyBookings(int userid)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Bookings WHERE userid = @userid AND seats_booked > 0", con);
                    cmd.Parameters.AddWithValue("@userid", userid);
                    SqlDataReader reader = cmd.ExecuteReader();

                    Console.WriteLine("\nYour Bookings:");
                    Console.WriteLine("--------------------------------------------------");
                    if (!reader.HasRows)
                    {
                        Console.WriteLine("You have no active bookings.");
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Booking ID: {reader["booking_id"]}, Train No: {reader["tno"]}, Seats: {reader["seats_booked"]}, Date of Travel: {reader["booking_date"]}, Total Amount: {reader["total_amount"]}");
                        }
                    }
                    Console.WriteLine("--------------------------------------------------\n");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Exception in View my Bookings Function:" + ex.Message);
            }
        }

        public void ViewMyCancellations(int userid)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT c.cancellation_id, c.booking_id, c.seats_cancelled, c.cancellation_date, b.tno FROM Cancellations c INNER JOIN Bookings b ON c.booking_id = b.booking_id WHERE b.userid = @userid", con);
                    cmd.Parameters.AddWithValue("@userid", userid);
                    SqlDataReader reader = cmd.ExecuteReader();

                    Console.WriteLine("\nYour Cancellations:");
                    Console.WriteLine("--------------------------------------------------");
                    if (!reader.HasRows)
                    {
                        Console.WriteLine("You have no cancellations.");
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Cancellation ID: {reader["cancellation_id"]}, Booking ID: {reader["booking_id"]}, Train No: {reader["tno"]}, Seats Cancelled: {reader["seats_cancelled"]}, Date: {reader["cancellation_date"]}");
                        }
                    }
                    Console.WriteLine("--------------------------------------------------\n");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Exception in View my Cancellation Function:" + ex.Message);
            }
        }
            
    }
}