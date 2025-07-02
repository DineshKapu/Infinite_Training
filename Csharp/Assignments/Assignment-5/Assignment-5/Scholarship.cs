using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Exception Handling :  
    Question-2:
    Create a class called Scholarship which has a function Public void Merit() that takes marks and fees as an input. 
    If the given mark is >= 70 and <=80, then calculate scholarship amount as 20% of the fees
    If the given mark is > 80 and <=90, then calculate scholarship amount as 30% of the fees
    If the given mark is >90, then calculate scholarship amount as 50% of the fees.
    In all the cases return the Scholarship amount, else throw an user exception
 */
namespace Assignment_5
{

    public class ScholarshipNotEligibleException : ApplicationException
    {
        public ScholarshipNotEligibleException(string message) : base(message) { }
    }

    public class Scholarship
    {
        public double Merit(int marks, double fees)
        {
            double scholarshipAmount = 0;

            if (marks >= 70 && marks <= 80)
            {
                scholarshipAmount = 0.2* fees;
            }
            else if (marks > 80 && marks <= 90)
            {
                scholarshipAmount = 0.3 * fees;
            }
            else if (marks > 90)
            {
                scholarshipAmount = 0.5* fees;
            }
            else
            {
                throw new ScholarshipNotEligibleException("Student does not qualify for scholarship based on marks.");
            }

            return scholarshipAmount;
        }

        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter Marks:");
                int marks = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Fees:");
                double fees = Convert.ToDouble(Console.ReadLine());

                Scholarship s = new Scholarship();
                double result = s.Merit(marks, fees);
                Console.WriteLine($"Scholarship Amount:{result}");
            }
            catch (ScholarshipNotEligibleException ex)
            {
                Console.WriteLine($"Eligibility Error: {ex.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Input was not in correct format. Please enter numeric values for marks and fees.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Entered value is too large.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error occurred: {ex.Message}");
            }
            Console.Read();
        }
    }
}
