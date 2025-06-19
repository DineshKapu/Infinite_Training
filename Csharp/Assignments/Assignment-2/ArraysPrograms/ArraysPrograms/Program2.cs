using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysPrograms
{
    class Program2
    {
        public static void Main()
        {
            int[] marks = new int[10];
            Console.WriteLine("Enter the 10 Subjects Marks:");
            for(int i=0;i<10;i++)
            {
                marks[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Total Marks: {0}",marks.Sum());
            Console.WriteLine("Average Marks: {0}", marks.Average());
            Console.WriteLine("Minimum Marks: {0}", marks.Min());
            Console.WriteLine("Maximum Marks: {0}", marks.Max());
            Array.Sort(marks);
            Console.WriteLine("Marks in Ascending order:");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(marks[i]+" ");
            }
            Console.WriteLine();
            Console.WriteLine("Marks in Descending order:");
            for (int i = 9; i>=0; i--)
            {
                Console.Write(marks[i] + " ");
            }
            Console.WriteLine();
            Console.Read();


        }
    }
}
