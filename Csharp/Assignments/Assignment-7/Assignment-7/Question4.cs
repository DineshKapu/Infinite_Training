﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassConsession;

/*
    Question-4:
    Create a class library with a function CalculateConcession()  that takes age as an input and calculates concession for travel as below:
    If age <= 5 then “Little Champs - Free Ticket” should be displayed
    If age > 60 then calculate 30% concession on the totalfare(Which is a constant Eg:500/-) and Display “ Senior Citizen” + Calculated Fare
    Else “Print Ticket Booked” + Fare. 
    Create a Console application with a Class called Program which has TotalFare as Constant, Name, Age.  
    Accept Name, Age from the user and call the CalculateConcession() function to test the Classlibrary functionality
 */
namespace Assignment_7
{
    class Question4
    {
        static void Main()
        {
            Console.WriteLine("Enter The Name of the Person: ");
            string Name = Console.ReadLine();
            Console.WriteLine("Enter The Age of the Person: ");
            int Age = Convert.ToInt32(Console.ReadLine());
            const double TotalFare = 500;
            Class1 c1 = new Class1();
            c1.CalculateConcession(TotalFare, Name, Age);
            Console.Read();

        }
    }
}
