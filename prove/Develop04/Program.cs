using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        int userChoice = -1;
        while (userChoice != 4)
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("What would you like to do? ");

            userChoice = int.Parse(Console.ReadLine());

            if (userChoice == 1) //Breathing Activity
            {
                BreathingActivity breathing = new BreathingActivity();
                breathing.Run();
            }
            else if (userChoice == 2) //Reflection Activity
            {
               ReflectionActivity reflection = new ReflectionActivity();
               reflection.Run();
            }
            else if (userChoice == 3) //Listing Activity
            {
                ListingActivity listing = new ListingActivity();
                listing.Run();
            }
            else if (userChoice == 4) // Quit and Exit Message
            {
                Console.WriteLine("Goodbye!");
                break;
            }
        }
    }
}