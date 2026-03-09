using System;
using System.Security.Cryptography.X509Certificates;
//For my extra credit option I added the ability to delete a goal as well as some user functionality and protection options.
//Some of these include "user proofing" some of the data entry points and securing what used to be a few
//potential crash points for if a user tried to load files that were nonexistent or not formatted correctly.
class Program
{
    static void Main(string[] args)
    {
        GoalManager GM = new GoalManager();

        int userChoice = -1;
        while (userChoice != 6) 
        {
            Console.WriteLine();

            GM.DisplayUserInfo();

            Console.WriteLine("\nMenu Options");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Delete A Goal");
            Console.WriteLine("7. Quit");

            userChoice = GM.GetInt("Select a choice from the menu:"); //retrieves user input

            //BELOW - matches user input to a menu option
            if (userChoice == 1) //Create new goal
            {
                GM.CreateGoal();
            }
            else if (userChoice == 2) //List Goals
            {
               GM.DisplayGoalsInfo();
            }
            else if (userChoice == 3) //Save Goals
            {
                string filename = GM.GetString("What is the filename for the goal file?");
                GM.SaveGoals(filename);
            }
            else if (userChoice == 4) //Load Goals
            {
                string filename = GM.GetString("What is the filename you would like to load from? ");
                GM.LoadGoals(filename);
            }
            else if (userChoice == 5) //Record Event
            {
                GM.RecordEvent();
            }
            else if (userChoice == 6) //Delete A Goal
            {
                GM.DeleteGoal();
            }
            else if (userChoice == 7) //Quit and exit message
            {
                Console.WriteLine("Goodbye!");
                break;
            }
        }
    }
}