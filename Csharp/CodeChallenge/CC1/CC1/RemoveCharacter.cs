using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
     1. Write a C# Sharp program to remove the character at a given position in the string. The given position will be in the range 0..(string length -1) inclusive.
 
        Sample Input:
        "Python", 1
        "Python", 0
        "Python", 4
        Expected Output:
        Pthon
        ython
        Pythn
 
     */

namespace CC1
{

   
    class RemoveCharacter
    {
        static void Main(string[] args)
        {
            //Taking Input From the User
            Console.WriteLine("Enter String:");
            string s=Console.ReadLine();
            Console.WriteLine("Enter Position To Remove:");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("After removing the Character from the position {0}"+" "+"The String is:{1}",CharacterRemoval(s, n));

            //Assigning  Values Directly
            Console.WriteLine(CharacterRemoval("python", 1));//pthon
            Console.WriteLine(CharacterRemoval("python", 0));//ython
            Console.WriteLine(CharacterRemoval("python", 4));//pythn
            Console.Read();
        }
        static string CharacterRemoval(string str, int position)
        {
            if (position < 0 || position >= str.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(position));
            }
            return str.Remove(position, 1);

        }
    }
}
