using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mini_Project.Services;
using System.Data.SqlClient;
using Mini_Project.UI;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace MiniProject_Testing
{
    [TestFixture]
    public class AuthenticationTest
    {
        public string cstr = "data source = ICS-LT-10Z3D64\\SQLEXPRESS; initial catalog = MiniProject; User ID = sa; Password = Dineshkapu@180703";
        [Test]
        public void TrueAuthUser()
        {
            var uname = "jaya";
            var pwd = "jaya@123";
            AuthenticationService auth = new AuthenticationService(cstr);
            var value = auth.AuthenticateUser(uname, pwd);
            ClassicAssert.AreEqual(value, (11, "user"));
        }
        //[Test]
        //public void FalseAuthUser()
        //{
        //    var uname = "dinesh123";
        //    var pwd = "jaya@123";
        //    AuthenticationService auth = new AuthenticationService(cstr);
        //    var value = auth.AuthenticateUser(uname, pwd);
        //    ClassicAssert.AreEqual(value, (9, "user"));
        //}

        [TestCase("jaya", "jaya@123")] //pass 
        [TestCase("admin", "admin@123")] //fail  
        [TestCase("dinesh", "dinesh@123")]//pass
        public void TrueAuthUser_DataCheck(string uname,string pwd)
        {
            //string uname = "dines";
            //string pwd = "dinesh@123";
            AuthenticationService auth = new AuthenticationService(cstr);
            var actual = auth.AuthenticateUser(uname, pwd);
            int? expectedUserId = null;
            string expectedRole = null;

            using (SqlConnection con = new SqlConnection(cstr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT userid, roles FROM Users WHERE username = @username AND password = @password", con);
                cmd.Parameters.AddWithValue("@username", uname);
                cmd.Parameters.AddWithValue("@password", pwd);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    expectedUserId = (int)reader["userid"];
                    expectedRole = reader["roles"].ToString();
                }
            }

            // Fail the test if user is not found
            ClassicAssert.IsNotNull(expectedUserId, "User not found in database.");
            ClassicAssert.AreEqual((expectedUserId, expectedRole), actual);
        }

    }
}
