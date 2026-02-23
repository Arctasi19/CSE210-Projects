using System.Formats.Asn1;
using System.Runtime.InteropServices.Marshalling;

class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts = [
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
        ];
    public ListingActivity() : base(
        "Listing Activity",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."
    )
    {
        
    }
    public void Run()
    {
        StartMessage();
        Console.WriteLine("Get Ready...\n");
        PauseSpinner(5);

        Console.WriteLine("List as many responses as you can to the following prompt:");
        string prompt = GetRandomString(_prompts);
        Console.WriteLine($"--- {prompt} ---\n");

        Console.Write("You may begin in...");
        PauseTimer(5);
        Console.WriteLine();
        
        GetListFromUser();
        Console.WriteLine($"You listed {_count} items!\n");

        EndMessage();
    }
    private void GetListFromUser()
    {
        List<string> userList = new List<string> {};

        int duration = GetDuration();
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(duration);
        
        DateTime currentTime = DateTime.Now;
        while (currentTime < futureTime)
        {
            Console.Write("> ");
            string userItem = Console.ReadLine();
            userList.Add(userItem);
            currentTime = DateTime.Now;
        }
        int counter = userList.Count;
        _count = counter;
    }
}