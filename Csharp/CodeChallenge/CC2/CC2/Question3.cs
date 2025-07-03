using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Question-3:
    Write a C# program to implement a method that takes an integer as input and throws an exception if the number is negative. Handle the exception in the calling code.
 */
namespace CC2
{
    class Question3
    {
        public static void CheckNumber(int num)
        {
            if (num < 0)
            {
                throw new ArgumentException("The Given Number is Negative so Cannot Accept");
            }
            else if (num > 0)
            {
                Console.WriteLine("Number " + num + " is valid.");
            }
            else if (num == 0)
            {
                Console.WriteLine($"{num} is neither Positive nor Negative");
            }
        }
        static void Main(string[] args)
        {
            try
            {
                int num;
                Console.WriteLine("Enter Number:");
                num = Convert.ToInt32(Console.ReadLine());
                CheckNumber(num);
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine("Exception Caught:" + ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Given input is wrong:It should be an Interger Type only"); //If we enter other than integer type value like{String,character,float..}  ,this exception will Occur.
            }
            catch (Exception)
            {
                Console.WriteLine("Unexpected error"); //If any Exceptions Occur Other than the Above Mentioned Exceptions ,This Exception will Occur.
            }
            Console.Read();
        }
    }
}
