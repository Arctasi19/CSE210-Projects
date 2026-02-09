using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

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