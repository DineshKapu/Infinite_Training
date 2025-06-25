using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*2. Write a C# Sharp program to exchange the first and last characters in a given string and return the new string.
 
Sample Input:
"abcd"
"a"
"xy"
Expected Output: 
dbca
a
yx
*/
namespace CC1
{
    class Exchange
    {
        public static void Main(string[] args)
        {
            //Taking Input From the User
            Console.WriteLine("Enter String:");
            string s = Console.ReadLine();
            Console.WriteLine("After Exhanging First and Last: "+ExchangeFirstLast(s));

            //Assigning  Values Directly
            Console.WriteLine(ExchangeFirstLast("abcd"));//dbca
            Console.WriteLine(ExchangeFirstLast("a"));//a
            Console.WriteLine(ExchangeFirstLast("xy"));//yx
            Console.ReadLine();
        }
        static string ExchangeFirstLast(string str)
        {
            if (str.Length <= 1)
            {
                return str;
            }
            char[] charArray = str.ToCharArray();
            char temp = charArray[0];
            charArray[0] = charArray[charArray.Length - 1];
            charArray[charArray.Length - 1] = temp;

            return new string(charArray);
        }
    }
}
