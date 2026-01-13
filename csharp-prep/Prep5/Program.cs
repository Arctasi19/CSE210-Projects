using System;
using System.Net.NetworkInformation;
using System.Reflection.Metadata;

class Program
{
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please Enter Your Name: ");
        string userName = Console.ReadLine();
        return userName;
    }

    static int SquareNumber(int input)
    {
        int numberSquared = input * input;
        return numberSquared;
    }

    static void DisplayResult(string name, int square, int birthYear)
    {
        int presentYear = 2026;
        int userAge = presentYear - birthYear;

        Console.WriteLine($"{name}, the square of your number is {square}.");
        Console.WriteLine($"{name}, you will be {userAge} this year.");
    }
    static int GetNumber(string prompt)
    {
        bool success = false;
        int endResult = 0;

        while (success == false)
        {
            try
            {
                Console.Write(prompt);
                string result = Console.ReadLine();
                int resultingNumber = int.Parse(result);
                endResult = resultingNumber;
                success = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Exception Occurred, please try again");
                Console.WriteLine("Exception message: " + ex.Message);
            }
        }
        return endResult;
        
    }
    static void PromptUserBirthYear(out int year)
    {
        year = GetNumber("Please enter your birth year: ");
    }
    static void Main(string[] args)
    {
        DisplayWelcome();

        string userName = PromptUserName();

        int favoriteNumber = GetNumber("Please enter your favorite number: ");
        int birthYear = 0;
        PromptUserBirthYear(out birthYear);

        int squared = SquareNumber(favoriteNumber);
        
        DisplayResult(userName, squared, birthYear);

    }
}