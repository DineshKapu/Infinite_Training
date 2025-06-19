using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralPrograms
{
    class Program1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("_____________Swapping of Two Numbers__________");
            int num1, num2;
            Console.WriteLine("Enter First Number:");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Second Number:");
            num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Before Swapping: num1: {0} and num2: {1}",num1,num2);

            int temp;
            temp = num1;
            num1 = num2;
            num2 = temp;

            Console.WriteLine("After Swapping: num1: {0} and num2: {1}", num1, num2);
            Console.Read();


        }
    }
}
