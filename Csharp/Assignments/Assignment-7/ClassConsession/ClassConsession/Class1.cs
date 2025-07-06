using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassConsession
{
    public class Class1
    {
        public void CalculateConcession(double TotalFare,string Name,int age)
        {
            if(age<=5)
            {
                Console.WriteLine("Little Champs-Free Ticket");
            }
            else if(age>60)
            {
                double res = 0.70 * TotalFare; //30% Concession
                Console.WriteLine("Senior Citizen-Total Fare: {0}", res);
            }
            else
            {
                Console.WriteLine("Print Ticket Booked -Total Fare: {0}", TotalFare);
            }
        }
    }
}
