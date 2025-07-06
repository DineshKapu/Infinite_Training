using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Question-1:
    Write a query that returns list of numbers and their squares only if square is greater than 20 
    Example input: [7, 2, 30]  
    Expected output:
    → 7 - 49, 30 - 900
 */
namespace Assignment_7
{
    class Question1
    {
        static void Main(string[] args)
        {
            int n;
            Console.WriteLine("Enter the No.of Values:");
            n = Convert.ToInt32(Console.ReadLine());
            List<int> nums = new List<int>();
            for(int i=0;i<n;i++)
            {
                Console.WriteLine($"Enter the Value-{i+1}:");
                int num1= Convert.ToInt32(Console.ReadLine());
                nums.Add(num1);
            }
            //Query Expression
            var res = from num in nums
                      let square = num * num
                      where square > 20
                      select $"{num}-{square}";
            Console.WriteLine("--- 'To Display The Square Of The Numbers,Whose Number Square is Greater than 20' ---");
            foreach (var i in res)
                Console.WriteLine(i);
            Console.Read();
        }
    }
}
