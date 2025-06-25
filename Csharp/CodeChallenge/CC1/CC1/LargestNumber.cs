using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
3. Write a C# Sharp program to check the largest number among three given integers.
 
Sample Input:
1,2,3
1,3,2
1,1,1
1,2,2
Expected Output:
3
3
1
2
*/
namespace CC1
{
    class LargestNumber
    {
        public static void Main(string[] args)
        {
            //Taking Input From the User
            int x, y, z;
            Console.WriteLine("Enter First Number");
            x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Second Number");
            y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Third Number");
            z = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("The Largest Number Among three Numbers is:" +Largest(x,y,z));

            //Assigning  Values Directly
            Console.WriteLine(Largest(1, 2, 3));//3
            Console.WriteLine(Largest(1, 3, 2));//3
            Console.WriteLine(Largest(1, 1, 1));//1
            Console.WriteLine(Largest(1, 2, 2));//2
            Console.ReadLine();
        }

        static int Largest(int x, int y, int z)
        {
            return Math.Max(x,Math.Max(y,z));
        }
    }
}
