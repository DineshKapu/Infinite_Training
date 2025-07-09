using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    Question-4:
    Write a console program that uses delegate object as an argument to call Calculator Functionalities 
    like 1. Addition, 2. Subtraction and 3. Multiplication by taking 2 integers and returning the output to the user. 
    You should display all the return values accordingly.
 */
namespace CC3
{
    class Question4
    {
        public delegate int Calculator(int x, int y);
        public static void Main(string[] args)
        {
            Calculator add = new Calculator(Add);
            Calculator subtract = new Calculator(Subtract);
            Calculator multiply = new Calculator(Multiply);

            Console.Write("Enter First Number:");
            int n1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Second Number:");
            int n2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Addition: {add(n1, n2)}");
            Console.WriteLine($"Subtraction: {subtract(n1, n2)}");
            Console.WriteLine($"Multiplication: {multiply(n1, n2)}");
            Console.Read();

        }
        public static int Add(int x, int y)
        {
            return x + y;
        }
        public static int Subtract(int x, int y)
        {
            return x - y;
        }
        public static int Multiply(int x, int y)
        {
            return x * y;
        }
    }

}
