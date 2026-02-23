class Activity
{
    private string _activityName;
    private string _activityDescription;
    private int _activityDuration;
    public Activity(string activityName, string activityDescription)
    {
        _activityName = activityName;
        _activityDescription = activityDescription;
    }
    public int GetDuration()
    {
        return _activityDuration;
    }
    public void SetDuration()
    {
        Console.Write("How long, in seconds, would you like for your session? ");
        int userDuration = int.Parse(Console.ReadLine());
        _activityDuration = userDuration;
    }
    public void StartMessage()
    {
        Console.WriteLine($"Welcome to the {_activityName}.");
        Console.WriteLine(_activityDescription);
        SetDuration();
    }
    public void EndMessage()
    {
        Console.WriteLine("Well done!");
        Console.WriteLine($"You have completed another {_activityDuration} seconds of the {_activityName}.");
        PauseSpinner(5);
        Console.Clear();
    }
    public void PauseSpinner(int pauseDuration)
    {
        int timer = pauseDuration * 1000;
        while (timer > 0)
        {
            Console.Write("|");
            Thread.Sleep(250);
            Console.Write("\b \b");

            Console.Write("/"); 
            Thread.Sleep(250);
            Console.Write("\b \b"); 

            Console.Write("-");
            Thread.Sleep(250);
            Console.Write("\b \b");

            Console.Write("\\"); 
            Thread.Sleep(250);
            Console.Write("\b \b"); 
            timer -= 1000;
        }
    }
    public void PauseTimer(int pauseDuration)
    {
        int internaTimer = pauseDuration * 1000;
        for (int i = pauseDuration; i > 0; i--)
        {
            if (i >= 10)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b\b  \b\b");
                internaTimer -= 1000;
            }
            else
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
                internaTimer -= 1000;
            }
        }
    }
    public string GetRandomString(List<string> prompts)
    {
        Random random = new Random();
        int index = random.Next(prompts.Count);
        string randomString = prompts[index];
        return randomString;
    }
}