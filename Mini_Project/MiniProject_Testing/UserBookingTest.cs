using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Legacy;
using NUnit.Framework;
using Mini_Project.Services;
using Mini_Project.UI;
using System.Data.SqlClient;
namespace MiniProject_Testing
{

    [TestFixture]
    public class UserBookingTest
    {
        private readonly string cstr = "data source = ICS-LT-10Z3D64\\SQLEXPRESS; initial catalog = MiniProject; User ID = sa; Password = Dineshkapu@180703";

        [TestCase("arthi", "arthi@123")]//pass
        [TestCase("din", "dinesh@123")]//fail
        public void User_Should_See_Only_Their_Bookings(string username, string password)
        {
          
            AuthenticationService auth = new AuthenticationService(cstr);
            var (userid, role) = auth.AuthenticateUser(username, password);

            ClassicAssert.IsNotNull(userid, $"User '{username}' not found or password incorrect.");

           
            using (SqlConnection con = new SqlConnection(cstr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT booking_id, tno, seats_booked, booking_date FROM Bookings WHERE userid = @userid AND seats_booked > 0", con);
                cmd.Parameters.AddWithValue("@userid", userid);
                SqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine($"\nBookings for user '{username}' (UserID: {userid}):");
                if (!reader.HasRows)
                {
                    Console.WriteLine("No active bookings found.");
                }
                else
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Booking ID: {reader["booking_id"]}, Train No: {reader["tno"]}, Seats: {reader["seats_booked"]}, Date: {reader["booking_date"]}");
                    }
                }
            }

           
            UserService userService = new UserService(cstr);
            Console.WriteLine("\nOutput from UserService:");
            userService.ViewMyBookings(userid.Value);
        }


    }
}
