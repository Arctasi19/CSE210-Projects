/* The submission instructions in Canvas say to submit the comment through there in I-Learn, but due to instruction
from my professor, I will include it here as well. 
To exceed requirements, I added a randomizer class that allows for a random scripture to be selected each time from a set list of scriptures and their references.*/

using System;

class Program
{
    static void Main()
    {
        ScriptureGenerator scriptures = new ScriptureGenerator();
        Scripture scripture = scriptures.GetRandomScripture();
        while (true)
        {
            scripture.Display();
            string input = Console.ReadLine();

            if (input.ToLower() == "quit" || scripture.AllHidden())
                break;

            scripture.HideRandomWords();
        }
    }
}