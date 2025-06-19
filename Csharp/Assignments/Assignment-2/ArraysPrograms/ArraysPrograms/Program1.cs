using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysPrograms
{
    class Program1
    {
        public static void Main(string[] args)
        {
            int n;
            Console.WriteLine("Enter the number of Elements:");
            n = Convert.ToInt32(Console.ReadLine());
            int[] arr=new int[n];
            Console.WriteLine("Enter the Elements:");
            for(int i=0;i<n;i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("The Average Value of an Array Elements is : {0}", arr.Average());
            Console.WriteLine("The Minimum Value of an Array is : {0}",arr.Min());
            Console.WriteLine("The Maximum Value of an Array is : {0}",arr.Max());
            Console.Read();
        }
    }
}
