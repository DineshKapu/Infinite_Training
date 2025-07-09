using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    Question-1:
    Write a program to find the Sum and the Average points scored by the teams in the IPL. 
    Create a Class called CricketTeam that has a function called Pointscalculation(int no_of_matches) that takes no.of matches as input 
    and accepts that many scores from the user. 
    The function should then return the Count of Matches, Average and Sum of the scores.
 */

namespace CC3
{
    public class Cricket
    {
        public (int, int, double) CalculatePoints(int No_Of_Matches)
        {
            var Scores = new List<int>();

            for (int i = 1; i <= No_Of_Matches; i++)
            {
                Console.Write($"Enter Score for Match {i}: ");

                if (int.TryParse(Console.ReadLine(), out int score))
                {
                    Scores.Add(score);
                }
                else
                {
                    Console.WriteLine("Invalid Input. Please Enter a Valid Integer Score.");
                    i--; // Retry current match
                }
            }

            int TotalScore = 0;
            foreach (int score in Scores)
            {
                TotalScore += score;
            }

            double AverageScore = No_Of_Matches > 0 ? (double)TotalScore / No_Of_Matches : 0;

            //Console.WriteLine($"The Count of Matches:{No_Of_Matches} ");
            //Console.WriteLine($"Total Score: {TotalScore}");
            //Console.WriteLine($"Average Score: {averageScore:F3}"); //It Displays Output Upto 3 Decimals.Eg:3.333

            return (No_Of_Matches, TotalScore, AverageScore);
        }
    }
    class Question1
    {
        public static void Main(string[] args)
        {

            Check: //label
            Console.Write("Enter the number of matches: ");
            if (int.TryParse(Console.ReadLine(), out int No_Of_Matches) && No_Of_Matches >= 0)
            {
                Cricket team = new Cricket();
                (int No_Of_Matches, int TotalScore, double AverageScore) res = team.CalculatePoints(No_Of_Matches);
                Console.WriteLine($"The Count of Matches:{res.No_Of_Matches} ");
                Console.WriteLine($"Total Score: {res.TotalScore}");
                Console.WriteLine($"Average Score: {res.AverageScore:F3}"); //It Displays Output Upto 3 Decimals.Eg:3.333

            }
            else
            {
                Console.WriteLine("Invalid Number of Matches.Try Again!..");
                goto Check; //goto statement
            }

            Console.WriteLine("Press Any Key to exit...");
            Console.Read();
        }
    }
}
