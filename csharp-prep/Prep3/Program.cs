using System;
using System.Dynamic;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        List<string> noValues = new List<string> {"no","n","No","N"};
        string exitResponse = "";
        do 
        {
            Random randomGenerator = new Random();
            int randomNumber = randomGenerator.Next(1,100);
            bool successKey = false;
            int guessTotal = 0;
            
            
            while (successKey == false)
            {
                Console.Write("What is the magic number? ");
                string response = Console.ReadLine();
                int intResponse = int.Parse(response);
                guessTotal++;

                if (intResponse > randomNumber)
                {
                    Console.Write("Try lower!\n");
                }
                else if (intResponse < randomNumber)
                {
                    Console.Write("Try higher!\n");
                }
                else if (intResponse == randomNumber)
                {
                    successKey = true;
                    Console.Write("That is correct!!!\n");
                    Console.Write($"You made {guessTotal} guesses.\n");
                    Console.Write("Would you like to play again? (y/n)");
                    exitResponse = Console.ReadLine();
                }
            }
        } while (!noValues.Contains(exitResponse));
    }
}