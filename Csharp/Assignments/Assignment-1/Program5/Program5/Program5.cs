using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program5
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1, num2;
            Console.WriteLine("Input first number:");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input second number:");
            num2 = Convert.ToInt32(Console.ReadLine());
            int sum = num1 + num2;
            if (num1 == num2)
            {
                Console.WriteLine($"The triplet of the sum of {num1} and {num2} is {3 * sum}");
            }
            else
                Console.WriteLine($"The Sum of {num1} and {num2} is {sum}");
            Console.Read();
        }
    }
}
