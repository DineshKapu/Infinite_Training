using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mini_Project.Services;
using Mini_Project.UI;
using System.Data.SqlClient;
namespace Mini_Project
{
    class Program
    {
        static string connectionString = "data source = ICS-LT-10Z3D64\\SQLEXPRESS; initial catalog = MiniProject; User ID = sa; Password = Dineshkapu@180703";

        static void Main(string[] args)
        {
            AuthenticationService authService = new AuthenticationService(connectionString);
            AdminService adminService = new AdminService(connectionString);
            UserService bookingService = new UserService(connectionString);

            MainMenu mainMenu = new MainMenu(authService, adminService, bookingService);
            mainMenu.Run();
        }
    }
}
