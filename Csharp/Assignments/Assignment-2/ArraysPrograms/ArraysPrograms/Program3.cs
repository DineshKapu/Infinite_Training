using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysPrograms
{
    class Program3
    {
        public static void Main()
        {
            int n;
            Console.WriteLine("Enter the number of Elements:");
            n = Convert.ToInt32(Console.ReadLine());
            int[] arr1 = new int[n];
            Console.WriteLine("Enter the Elements:");
            for (int i = 0; i < n; i++)
            {
                arr1[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("The original Array:");
            for (int i = 0; i < n; i++)
            {
                Console.Write(arr1[i] + " ");
            }
            Console.WriteLine();

            int[] arr2 = new int[arr1.Length];
            for (int i = 0; i < arr2.Length; i++)
            {
                arr2[i] = arr1[i];
            }
            Console.WriteLine("The copied Array is:");
            for (int i = 0; i < arr2.Length; i++)
            {
                Console.Write(arr2[i]+" ");
            }
            Console.WriteLine();
            Console.Read();



        }
    }
}
