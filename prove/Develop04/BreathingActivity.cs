class BreathingActivity : Activity
{
    public BreathingActivity() : base(
        "Breathing Activity",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing."
    ) //Constructor
    {
        
    }
    public void Run() //Core Program
    {  
        //Starts program
        StartMessage();
        Console.WriteLine("Get Ready...\n");
        PauseSpinner(5);

        //Runs a loop of messages prompting the user to breathe in or out until time expires
        int duration = GetDuration();
        int timer = duration * 1000;
        while (timer > 0)
        {
            Console.Write("Breathe in...");
            PauseTimer(5);
            Console.WriteLine("\n");

            Console.Write("Now breathe out...");
            PauseTimer(5);
            Console.WriteLine("\n");
            timer -= 10000;
        }
        
        //Ends the program with common end message
        EndMessage();
    }
}