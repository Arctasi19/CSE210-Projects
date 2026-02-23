class Activity
{
    private string _activityName;
    private string _activityDescription;
    private int _activityDuration;
    public Activity(string activityName, string activityDescription) //Constructor
    {
        _activityName = activityName;
        _activityDescription = activityDescription;
    } 
    public int GetDuration() //Retrieves the set duration value
    {
        return _activityDuration;
    }
    public void SetDuration() //Sets the duration value. Called within the StartMessage() function since each activity uses this to start.
    {
        Console.Write("How long, in seconds, would you like for your session? ");
        int userDuration = int.Parse(Console.ReadLine());
        _activityDuration = userDuration;
    }
    public void StartMessage() //Common Start Message, calling SetDuration()
    {
        Console.WriteLine($"Welcome to the {_activityName}.");
        Console.WriteLine(_activityDescription);
        SetDuration();
    }
    public void EndMessage() //Common End Message
    {
        Console.WriteLine("Well done!");
        Console.WriteLine($"You have completed another {_activityDuration} seconds of the {_activityName}.");
        PauseSpinner(5);
        Console.Clear();
    }
    public void PauseSpinner(int pauseDuration) //Creates a spinner animation in accordance with a given length of time
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
    public void PauseTimer(int pauseDuration) //Creates a countdown animation in accordance with a given length of time
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
    public string GetRandomString(List<string> prompts) //Given a list of strings, will return a random string from within the given list.
    {
        Random random = new Random();
        int index = random.Next(prompts.Count);
        string randomString = prompts[index];
        return randomString;
    }
}