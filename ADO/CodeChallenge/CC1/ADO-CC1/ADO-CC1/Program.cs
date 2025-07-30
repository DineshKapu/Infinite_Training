using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

/*Question-1:
 Write a stored Procedure that inserts records in the Employee_Details table
The procedure should generate the EmpId automatically to insert and should return the generated value to the user
Also the Salary Column is a calculated column (Salary is givenSalary - 10%)
Table: Employee_Details(Empid, Name, Salary, Gender)
Hint(User should not give the EmpId)
Test the Procedure using ADO classes and show the generated Empid and Salary
 
Question-2:
Write a procedure that takes empid as input and outputs the updated salary as current salary + 100 for the give employee.
Test the procedure using ADO classes and display the Employee details of that employee whose salary has been updated
*/

namespace ADO_CC1
{

        class Program
        {
            public static SqlConnection con;
            public static SqlCommand cmd;
            public static SqlDataReader dr;

            static void Main(string[] args)
            {
                while (true)
                {
                    Console.WriteLine("Choose action: [add] Add Employee, [update] Update Salary, [exit] Quit:");
                    string input = Console.ReadLine().Trim().ToLower();

                    if (input == "exit")
                        break;
                    else if (input == "add") 
                    {
                        Console.WriteLine("----------{Question-1}------------");
                        InsertEmployee();
                        Console.WriteLine("\nDisplaying Employee_Details Table:(Before Updation)\n");
                        DisplayEmployees();
                    }
                   
                    else if (input == "update") 
                    {
                        Console.WriteLine("----------{Question-2}------------");
                        UpdateEmployeeSalary();
                        Console.WriteLine("\nDisplaying Employee_Details Table:(After Updation)\n");
                        DisplayEmployees();
                    }
                    else
                        Console.WriteLine("Invalid choice. Try again.");
                }

                Console.Read();
            }

            private static SqlConnection GetConnection()
            {
                con = new SqlConnection("data source = ICS-LT-10Z3D64\\SQLEXPRESS; initial catalog = CodeChallenge; User ID = sa; Password = Dineshkapu@180703");
                con.Open();
                return con;
            }
            //Question-1:
            public static void InsertEmployee()
            {
                con = GetConnection(); 

                Console.WriteLine("Enter employee details:");

                Console.Write("Name: ");
                string empName = Console.ReadLine();

                Console.Write("Given Salary: ");
                float empSalary = float.Parse(Console.ReadLine());

                Console.Write("Gender (Male/Female): ");
                string empGender = Console.ReadLine();

                cmd = new SqlCommand("AddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpName", empName);
                cmd.Parameters.AddWithValue("@Empsal", empSalary);
                cmd.Parameters.AddWithValue("@EmpGender", empGender);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Employee added successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to add employee.");
                }

                con.Close();
            }

            //Question-2:
            public static void UpdateEmployeeSalary()
            {
                con = GetConnection(); 

                Console.Write("Enter Empno to update salary: ");
                int empId = int.Parse(Console.ReadLine());
                cmd = new SqlCommand("UpdateSalary", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Empid", empId);
                SqlParameter updatedSalOut = new SqlParameter("@UpdatedSalary", SqlDbType.Float)
                {
                    Direction = ParameterDirection.Output
                };

                cmd.Parameters.Add(updatedSalOut);

                cmd.ExecuteNonQuery();

                Console.WriteLine($"Salary Updated! New Salary: {updatedSalOut.Value:F2}");

                con.Close();
            }

            public static void DisplayEmployees()
            {
                con = GetConnection(); 
                cmd = new SqlCommand("SELECT * FROM Employee_Details", con);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Console.WriteLine($"Empno      : {dr["Empno"]}");
                    Console.WriteLine($"EmpName    : {dr["EmpName"]}");
                    Console.WriteLine($"Empsal     : {dr["Empsal"]}");
                    Console.WriteLine($"EmpGender  : {dr["EmpGender"]}");
                    Console.WriteLine($"NetSalary  : {dr["NetSalary"]}");
                    Console.WriteLine("----------------------------------");
                }

                dr.Close();
                con.Close();
            }
        }
    
}
