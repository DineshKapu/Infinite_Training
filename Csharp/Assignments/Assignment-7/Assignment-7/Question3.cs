using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Create a list of employees with following property EmpId, EmpName, EmpCity, EmpSalary. Populate some data
    Write a program for following requirement
    a.	To display all employees data
    b.	To display all employees data whose salary is greater than 45000
    c.	To display all employees data who belong to Bangalore Region
    d.	To display all employees data by their names is Ascending order
 */
namespace Assignment_7
{
    class Employees
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpCity { get; set; }
        public double EmpSalary { get; set; }
    }
    class Question3
    {
        static void Main()
        {
            Console.WriteLine("Enter the No.of Employees: " );
            int n = Convert.ToInt32(Console.ReadLine());
            List<Employees> employees = new List<Employees>();
            for(int i=0;i<n;i++)
            {
                Console.WriteLine("Enter Details for the Employee-{0}", i + 1);
                Console.Write("Enter Employee Id: ");
                int Id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Employee Name: ");
                string Name = Console.ReadLine();
                Console.Write("Enter Employee City: ");
                string City = Console.ReadLine();
                Console.Write("Enter Employee Salary: ");
                double Salary = Convert.ToDouble(Console.ReadLine());
                employees.Add(new Employees {EmpId=Id,EmpName=Name,EmpCity=City,EmpSalary=Salary });
            }

            Console.WriteLine("--- a) Displaying all Employees Data ---");
            var allEmployees = from emp in employees
                               select emp;
            foreach (var i in allEmployees)
                Console.WriteLine($"Employee Id: {i.EmpId}  Employee Name: {i.EmpName}  Employee City: {i.EmpCity}  Employee Salary: {i.EmpSalary} ");

            Console.WriteLine("--- b) Displaying all Employees Data whose Salary is greater than 45000 ---");
            var HighSalary= from emp in employees
                            where emp.EmpSalary>45000
                               select emp;
            foreach (var i in HighSalary)
                Console.WriteLine($"Employee Id: {i.EmpId}  Employee Name: {i.EmpName}  Employee City: {i.EmpCity}  Employee Salary: {i.EmpSalary} ");

            Console.WriteLine("--- c) Displaying all Employees Data who belong to Bangalore Region ---");
            var FromBangalore = from emp in employees
                               where emp.EmpCity.Equals("Banglore", StringComparison.OrdinalIgnoreCase)
                               select emp;
            foreach (var i in FromBangalore)
                Console.WriteLine($"Employee Id: {i.EmpId}  Employee Name: {i.EmpName}  Employee City: {i.EmpCity}  Employee Salary: {i.EmpSalary} ");

            Console.WriteLine("--- d) Displaying all employees data by their names is Ascending order ---");
            var SortedByName = from emp in employees
                               orderby emp.EmpName
                               select emp;
            foreach (var i in SortedByName)
                Console.WriteLine($"Employee Id: {i.EmpId}  Employee Name: {i.EmpName}  Employee City: {i.EmpCity}  Employee Salary: {i.EmpSalary} ");

            Console.Read();
        }
    }
}
