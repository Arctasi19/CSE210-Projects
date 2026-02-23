class ReflectionActivity : Activity
{
    private List<string> _promptsList = [
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    ];
    private List<string> _reflectionQuestionsList = [
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    ];
    public ReflectionActivity() : base(
        "Reflecting Activity",
        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life."
    )
    {
        
    }
    public void Run()
    {
        StartMessage();
        Console.WriteLine("Get Ready...\n");
        PauseSpinner(5);
        Console.Clear();

        Console.WriteLine("Consider the following prompt:\n");
        string prompt = GetRandomString(_promptsList);
        Console.WriteLine($"--- {prompt} ---\n");
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.Clear();

        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in...");
        PauseTimer(3);
        Console.WriteLine();

        int duration = GetDuration();
        int timer = duration * 1000;
        while (timer > 0)
        {
            string question = GetRandomString(_reflectionQuestionsList);
            Console.Write($"> {question}\n");
            PauseSpinner(10);
            timer -= 10000;
        }
        EndMessage();
    }
}