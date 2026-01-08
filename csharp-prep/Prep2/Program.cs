using System;
using System.Diagnostics.Tracing;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade? ");
        string strNumberGrade = Console.ReadLine();
        int numberGrade = int.Parse(strNumberGrade);
        string letterGrade = "";
        int secondDigit = 0;

        if (numberGrade >= 90 && numberGrade > 89)
        {
            letterGrade = "A";
        }
        else if (numberGrade >= 80 && numberGrade < 90)
        {
            letterGrade = "B";
        }
        else if (numberGrade >= 70 && numberGrade < 80)
        {
            letterGrade = "C";
        }
        else if (numberGrade >= 60 && numberGrade < 70)
        {
            letterGrade = "D";
        }
        else
        {
            letterGrade = "F";
        }

        secondDigit = numberGrade % 10;
        if (letterGrade != "F")
        {
            if (letterGrade != "A" && secondDigit >= 7)
            {
                letterGrade = letterGrade + "+";
            }
            else if (secondDigit <= 3)
            {
                letterGrade = letterGrade + "-";
            }
        }

        Console.WriteLine($"Your Letter Grade is {letterGrade}");


        if (numberGrade >= 70)
        {
            Console.WriteLine("You Passed!");
        }
        else
        {
            Console.WriteLine("You Failed!");
        }
    }
}