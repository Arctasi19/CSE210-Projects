using System;
using System.Runtime.Intrinsics.Arm;

class Program
{
    static void Main(string[] args)
    {
        int userInput = 0;
        string userResponse = "";
        List<int> userNumbers = [];

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        do
        {
            Console.Write("Enter a number: ");
            userResponse = Console.ReadLine();
            int intResponse = int.Parse(userResponse);
            userNumbers.Add(intResponse);
            userInput = intResponse;
        } while (userInput != 0);

        int sum = 0;
        int largest = 0;
        int smallest = 100000;
        foreach (int i in userNumbers)
        {
            sum += i;
            if (i > largest)
            {
                largest = i;
            }
            if (i < smallest && i > 0)
            {
                smallest = i;
            }
        }
        Console.WriteLine($"\nSum of numbers: {sum}");

        int length = userNumbers.Count;
        int average = sum / length;
        Console.WriteLine($"Average of numbers: {average}");

        Console.WriteLine($"Largest Number: {largest}");

        Console.WriteLine($"Smallest Positive Number: {smallest}");
    
        Console.WriteLine("Sorted List:");
        userNumbers.Sort();
        foreach (int i in userNumbers)
        {
            Console.WriteLine(i);
        }
        
        
    }
}