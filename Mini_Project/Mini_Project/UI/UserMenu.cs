using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mini_Project.Services;
namespace Mini_Project.UI
{
    public class UserMenu
    {
        private readonly UserService _bookingService;

        public UserMenu(UserService bookingService)
        {
            _bookingService = bookingService;
        }

        public void ShowMenu(int userId)
        {
            _bookingService.DisplayTrainDetails();

            while (true)
            {
                Console.WriteLine("\nUser Menu");
                Console.WriteLine("1. Book Tickets");
                Console.WriteLine("2. Cancel Tickets");
                Console.WriteLine("3.View My Bookings");
                Console.WriteLine("4.View My Cancellations");
                Console.WriteLine("5.View Trains");
                Console.WriteLine("6. Logout");
                Console.Write("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        _bookingService.BookTickets(userId);
                        break;
                    case 2:
                        _bookingService.CancelTickets(userId);
                        break;
                    case 3:
                        _bookingService.ViewMyBookings(userId);
                        break;
                    case 4:
                        _bookingService.ViewMyCancellations(userId);
                        break;
                    case 5:
                        _bookingService.DisplayTrainDetails();
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}
