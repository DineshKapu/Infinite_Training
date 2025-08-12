using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mini_Project.Services;
namespace Mini_Project.UI
{
    public class AdminMenu
    {
        private readonly AdminService _adminService;

        public AdminMenu(AdminService adminService)
        {
            _adminService = adminService;
        }

        public void ShowMenu()
        {
            _adminService.DisplayTrainDetails();

            while (true)
            {
                Console.WriteLine("\nAdmin Menu");
                Console.WriteLine("1. View Bookings");
                Console.WriteLine("2. View Cancellations");
                Console.WriteLine("3. Add Train");
                Console.WriteLine("4. Update Train");
                Console.WriteLine("5. Delete Train");
                Console.WriteLine("6. View Deleted Trains");
                Console.WriteLine("7.ViewAndRestoreDeletedTrains");
                Console.WriteLine("8.View Trains");
                Console.WriteLine("9. Logout");
                Console.Write("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        _adminService.ViewBookings();
                        break;
                    case 2:
                        _adminService.ViewCancellations();
                        break;
                    case 3:
                        _adminService.AddTrain();
                        break;
                    case 4:
                        _adminService.UpdateTrain();
                        break;
                    case 5:
                        _adminService.DeleteTrain();
                        break;
                    case 6:
                        _adminService.ViewDeletedTrains();
                        break;
                    case 7:
                        _adminService.ViewAndRestoreDeletedTrains();
                        break;
                    case 8:
                        _adminService.DisplayTrainDetails();
                        break;
                    case 9:
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}
