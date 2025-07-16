using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace cc1
{
    public class Employees
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public string City { get; set; }
    }
    class CSharp_Question_1
    {
        static void Main()
        {
            Console.WriteLine("Enter the No.of Employees: ");
            int n = Convert.ToInt32(Console.ReadLine());
            List<Employees> employees = new List<Employees>();
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Enter Details for the Employee-{0}", i + 1);
                Console.Write("Enter Employee Id: ");
                int Id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Employee First Name: ");
                string fName = Console.ReadLine().ToUpper();
                Console.Write("Enter Employee Last Name: ");
                string lName = Console.ReadLine().ToUpper();
                Console.Write("Enter Title /Designation of Employee : ");
                string title = Console.ReadLine().ToUpper();
                Console.WriteLine("Enter Employee Date Of Birth (yyyy-mm-dd):");
                DateTime dob = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter Employee Date Of Joining (yyyy-mm-dd):");
                DateTime doj = DateTime.Parse(Console.ReadLine());
                Console.Write("Enter Employee City: ");
                string city = Console.ReadLine().ToUpper();

                employees.Add(new Employees { EmployeeID = Id, FirstName = fName, LastName = lName, Title = title, DOB = dob, DOJ = doj, City = city });
            }

            Console.WriteLine("a. Display detail of all the employee:");
            DisplayEmployees(employees);

            Console.WriteLine("b. Display details of all the employee whose location is not Mumbai:");
            var nonMumbaiEmployees = employees.Where(e => e.City != "MUMBAI");
            DisplayEmployees(nonMumbaiEmployees);

            Console.WriteLine("c. Display details of all the employee whose title is AsstManager:");
            var asstManagers = employees.Where(e => e.Title == "ASSTMANAGER");
            DisplayEmployees(asstManagers);

            Console.WriteLine("d.Display details of all the employee whose Last Name start with S");
            var lastNameStartsWithS = employees.Where(e => e.LastName.StartsWith("S"));
            DisplayEmployees(lastNameStartsWithS);

            Console.WriteLine("Press Any Key to Exist");
            Console.Read();
        }
        static void DisplayEmployees(IEnumerable<Employees> employees)
        {
            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.EmployeeID},{emp.FirstName},{emp.LastName},{emp.Title},{emp.DOB.ToShortDateString()},{emp.DOJ.ToShortDateString()},{emp.City}");
            }
        }
    }
}

