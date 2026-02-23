// For the exceeding requirements and showing creativity, I chose to add another activity labelled as a stretching activity. This functions similarly to its relative activities,
//displaying a common start and end message, and going through a gradual step by step of randomized stretches.

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear(); //Clear the terminal for fresh start
        int userChoice = -1;
        while (userChoice != 5) //provides menu options
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Stretching Activity");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            userChoice = int.Parse(Console.ReadLine()); //retrieves user input

            //BELOW - matches user input to an activity. If not found, the loop will simply run again, prompting them once more.
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
            else if (userChoice == 4) //EXCEEDING REQUIREMENTS stretching activity
            {
                StretchingActivity stretching = new StretchingActivity();
                stretching.Run();
            }
            else if (userChoice == 5) // Quit and Exit Message
            {
                Console.WriteLine("Goodbye!");
                break;
            }
        }
    }
}