using System;

class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        int userChoice = -1;

        Console.WriteLine("Welcome to the Journal Program!");

        while (userChoice != 5)
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            userChoice = int.Parse(Console.ReadLine());

            if (userChoice == 1)
            {
                string prompt = promptGenerator.Prompt();
                Console.WriteLine(prompt);
                Console.Write("> ");
                string userResponse = Console.ReadLine();

                Console.Write("What was your general mood today? ");
                string mood = Console.ReadLine();

                string date = DateTime.Now.ToShortDateString();

                Entry newEntry = new Entry();
                newEntry._date = date;
                newEntry._promptText = prompt;
                newEntry._entryText = userResponse;
                newEntry._mood = mood;

                myJournal.AddEntry(newEntry);
            }
            else if (userChoice == 2)
            {
                myJournal.DisplayAll();
            }
            else if (userChoice == 3)
            {
                Console.Write("Load from what filename? ");
                string fileName = Console.ReadLine();
                myJournal.LoadFromFile(fileName);
            }
            else if (userChoice == 4)
            {
                Console.Write("Save to what filename? ");
                string fileName = Console.ReadLine();
                myJournal.SaveToFile(fileName);
            }
        }
    }
}