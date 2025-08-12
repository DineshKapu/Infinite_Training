using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Mini_Project.Services
{
    public class AuthenticationService
    {
        private readonly string _connectionString;

        public AuthenticationService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public (int?, string) AuthenticateUser(string username, string password)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
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
            catch(SqlException ex)
            {
                Console.WriteLine("Authentication Failed"+ex.Message);
                return (null, null);
            }
        }

        public void RegisterUser()
        {
            try
            {
                Console.Write("Enter Username: ");
                string username = Console.ReadLine();
                Console.Write("Enter Password: ");
                string password = Console.ReadLine();
                string role = "user";

                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Users (username, password, roles) VALUES (@username, @password, @roles)", con);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@roles", role);
                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    con.Close();
                    Console.WriteLine(rowsAffected > 0 ? "Registration successful. You can now login." : "Registration failed.");
                }
            }
            catch(SqlException ex)
            {
                Console.WriteLine("Exception Caught in Register User Function"+ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception Caught"+ex.Message);
            }
        }
    }
}