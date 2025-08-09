using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mini_Project.Services;
namespace Mini_Project.UI
{
    public class MainMenu
    {
        private readonly AuthenticationService _authService;
        private readonly AdminMenu _adminMenu;
        private readonly UserMenu _userMenu;

        public MainMenu(AuthenticationService authService, AdminService adminService, UserService bookingService)
        {
            _authService = authService;
            _adminMenu = new AdminMenu(adminService);
            _userMenu = new UserMenu(bookingService);
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("Welcome to the Railway Reservation System");
                Console.WriteLine("1. Login as Admin");
                Console.WriteLine("2. Login as User");
                Console.WriteLine("3. Register as new User");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    Login("admin");
                }
                else if (choice == 2)
                {
                    Login("user");
                }
                else if (choice == 3)
                {
                    _authService.RegisterUser();
                }
                else if (choice == 4)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Try again.");
                }
            }
        }

        private void Login(string expectedRole)
        {
            Console.Write($"Enter {expectedRole} username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            var (userid, role) = _authService.AuthenticateUser(username, password);

            if (role == "admin")
            {
                Console.WriteLine($"Login successful. Welcome, {username} (Admin) | User ID: {userid}");
                _adminMenu.ShowMenu();
            }
            else if (role == "user")
            {
                Console.WriteLine($"Login successful. Welcome, {username} (User) | User ID: {userid}");
                _userMenu.ShowMenu(userid.Value);
            }
            else
            {
                Console.WriteLine("Invalid username, password, or role.");
            }
        }
    }
}
