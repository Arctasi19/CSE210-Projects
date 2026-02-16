using System;

class Program
{
    
    static void Main(string[] args)
    {
        MathAssignment firstThing = new MathAssignment("92.5", "3-8", "Harry Potter", "Mathing");
        Console.WriteLine(firstThing.GetSummary());
        Console.WriteLine(firstThing.GetHomeworkList());
        WritingAssignment secondThing = new WritingAssignment("The Great British Baking Show Cookbook", "Hermione Granger", "Writing About Potions");
        Console.WriteLine(secondThing.GetSummary());
        Console.WriteLine(secondThing.GetWritingInformation());
    }
}